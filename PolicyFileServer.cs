using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PCGPS
{
	/// <summary>
	/// crossdomain.xml 形式の、アクセス許可情報を取得するためのサーバ
	/// デフォルトポート : 843
	/// </summary>
	class PolicyFileServer
	{
		/// <summary>
		/// 待ち受けポート
		/// </summary>
		//const int Port = 843;
		const int Port = 3210;

		/// <summary>
		/// ポリシーファイル
		/// </summary>
		string Policy = "";

		/// <summary>
		/// TCP 待ち受けオブジェクト
		/// </summary>
		TcpListener tcpListener;

		/// <summary>
		/// 接続してきたクライアントの情報
		/// </summary>
		List<ClientContext> clients;

		/// <summary>
		/// 待ち受けスレッド
		/// ブロッキングモードで動作するので、
		/// 別スレッドで起動
		/// </summary>
		Thread listenerThread;

		/// <summary>
		/// サーバ停止フラグ
		/// </summary>
		bool StopFlag;

		/// <summary>
		/// メッセージ通知用デリゲート
		/// </summary>
		TcpServerEvent tcpServerEvent;
		
		// --------------------------------------------------------------------

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PolicyFileServer()
		{
			clients = new List<ClientContext>();
		}

		/// <summary>
		/// サーバのメッセージを伝えるイベントを呼び出す
		/// </summary>
		/// <param name="message"></param>
		private void invokeServerEvent(string message)
		{
			if (tcpServerEvent != null)
				tcpServerEvent(message);
		}

		/// <summary>
		/// ポリシーファイルの内容を取得する
		/// </summary>
		private void GetPolicyFile()
		{
			string path = "crossdomain.xml";

			if (!File.Exists(path))
			{
				Policy = "";
				return;
			}

			Policy = File.ReadAllText(path);
		}

		/// <summary>
		/// クライアントを切断する
		/// </summary>
		/// <param name="context"></param>
		private void CloseClient(ClientContext context)
		{
			context.tcpClient.Close();
			clients.Remove(context);
			invokeServerEvent("クライアントの接続を閉じました。");
			invokeServerEvent("現在の接続数: " + clients.Count);
		}

		/// <summary>
		/// サーバ開始
		/// </summary>
		public void Start()
		{
			if (listenerThread != null)
				return;

			StopFlag = false;

			// ポリシーファイルの内容を取得する
			GetPolicyFile();
			if (Policy == "")
			{
				invokeServerEvent("crossdomain.xml ファイルの読み取りに失敗しました。" +
									"Exe と同じディレクトリに、 crossdomain.xml ファイルを" +
									"配置してください。");
			}

			// サーバ待ち受けスレッドを開始する
			listenerThread = new Thread(new ThreadStart(Listen));
			listenerThread.Start();

			invokeServerEvent("PolicyFileServer : サーバが開始されました。");
		}

		/// <summary>
		/// TCP サーバのメッセージを受け取るイベントハンドラの登録
		/// </summary>
		/// <param name="method"></param>
		public void RegisterTcpServerEvent(TcpServerEvent method)
		{
			tcpServerEvent = method;
		}

		/// <summary>
		/// サーバ停止
		/// </summary>
		public void Stop()
		{
			StopFlag = true;

			// クラアントとの接続を全て閉じる
			foreach (ClientContext context in clients)
			{
				context.tcpClient.Close();
				context.StopFlag = true;
				context.thread.Join();
			}

			// 待ち受けを停止する
			if (tcpListener != null)
				tcpListener.Stop();

			// 待ち受けスレッドを停止する
			if (listenerThread != null)
			{
				listenerThread.Join();
				listenerThread = null;
			}

			invokeServerEvent("PolicyFileServer : サーバが停止されました。");
		}

		/// <summary>
		/// クライアントに文字列のメッセージを送信する
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="message"></param>
		private void SendMessage(ClientContext context, string message)
		{
			Stream stream = context.tcpClient.GetStream();
			BinaryWriter writer = new BinaryWriter(stream);

			byte[] byteArray = Encoding.UTF8.GetBytes(message);

			try
			{
				writer.Write(byteArray);
				writer.Flush();
			}
			catch (IOException e)
			{
				invokeServerEvent("SendMessage() で例外が発生しました。クライアントを切断します。");
				invokeServerEvent(e.ToString());
				CloseClient(context);
			}
		}

		/// <summary>
		/// サーバ待ち受けループ
		/// </summary>
		private void Listen()
		{
			try
			{
				tcpListener = new TcpListener(IPAddress.Any, Port);
				tcpListener.Start();

				invokeServerEvent("接続を待っています。");

				while (!StopFlag)
				{
					if (tcpListener.Pending())
					{
						Thread thread = new Thread(new ParameterizedThreadStart(ClientLoop));

						TcpClient client = tcpListener.AcceptTcpClient();
						ClientContext context = new ClientContext(client, thread);
						clients.Add(context);
						thread.Start(context);

						if (client.Client.Connected == true)
							invokeServerEvent("クライアントが接続しました。 : " + client.Client.RemoteEndPoint.ToString());

						invokeServerEvent("現在の接続数: " + clients.Count);

						continue;
					}
					Thread.Sleep(10);
				}
			}
			catch (SocketException e)
			{
				invokeServerEvent("エラー (SocketException) : " + e.ToString());
			}
			finally
			{
				tcpListener.Stop();
			}
		}

		/// <summary>
		/// クライアントからのデータを待つループ
		/// </summary>
		/// <param name="param"></param>
		private void ClientLoop(Object param)
		{
			ClientContext context = (ClientContext)param;
			TcpClient client = context.tcpClient;
			//Byte[] bytes = new Byte[256];

			NetworkStream stream = client.GetStream();

			while (!context.StopFlag)
			{
				// 接続チェック
				if (!client.Client.Connected)
				{
					CloseClient(context);
					break;
				}

				if (stream.DataAvailable)
				{
					ReadStream(context, stream);
				}

				// 10 ミリ秒待つ
				Thread.Sleep(10);
			}
			client.Close();
		}

		/// <summary>
		/// データ受信
		/// </summary>
		/// <param name="context"></param>
		/// <param name="stream"></param>
		private void ReadStream(ClientContext context, NetworkStream stream)
		{
			BinaryReader reader = new BinaryReader(stream);

			// 受信タイムアウト時間の設定
			//stream.ReadTimeout = 1000;

			// ブロッキングモードでデータを受信
			while (stream.DataAvailable)
			{
				List<byte> byteList = new List<byte>();

				// 1 文字ずつ、 \0 が出現するまで読み取る
				// 例外が出たときも読み取り終了
				while (true)
				{
					byte buffer;
					try
					{
						buffer = (byte)stream.ReadByte();
					}
					catch (IOException)
					{
						break;
					}

					if (buffer == 0)
						break;
					byteList.Add(buffer);
				}

				// 読み取ったデータをストリング型に変換
				string message = Encoding.UTF8.GetString(byteList.ToArray());
				byteList.Clear();

				try
				{
					// 受信したデータが、<policy-file-request/> だった時
					if (message == "<policy-file-request/>")
					{
						invokeServerEvent("PolicyFileServer : ポリシーファイルを送信します。");
						SendMessage(context, Policy);
						CloseClient(context);
						break;
					}
				}
				catch (EndOfStreamException)
				{
					invokeServerEvent("PolicyFileServer : ReadStream() で例外が発生しました。クライアントを切断します。");
					context.StopFlag = true;
					CloseClient(context);
					break;
				}
				catch (IOException e)
				{
					// タイムアウト
					invokeServerEvent("PolicyFileServer : ReadStream() で例外が発生しました。クライアントを切断します。");
					invokeServerEvent(e.ToString());
					context.StopFlag = true;
					CloseClient(context);
					break;

				}
			}
		}

	}
}
