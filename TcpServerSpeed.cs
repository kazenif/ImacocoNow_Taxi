using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PCGPS
{
	/// <summary>
	/// TCP サーバのメッセージを受け取るイベント用デリゲート
	/// </summary>
	/// <param name="message"></param>
	public delegate void TcpServerEvent(string message);

	/// <summary>
	/// TCP サーバ
	/// </summary>
	class TcpServerSpeed
	{
		/// <summary>
		/// 待ち受けポート
		/// </summary>
		const int Port = 3200;

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
		public TcpServerSpeed()
		{
			tcpListener = null;
			clients = new List<ClientContext>();
			StopFlag = false;
			listenerThread = null;
			tcpServerEvent = null;
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

			invokeServerEvent("サーバが停止されました。");
		}

		/// <summary>
		/// サーバ開始
		/// </summary>
		public void Start()
		{
			if (listenerThread != null)
				return;

			StopFlag = false;

			// サーバ待ち受けスレッドを開始する
			listenerThread = new Thread(new ThreadStart(Listen));
			listenerThread.Start();

			invokeServerEvent("サーバが開始されました。");
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
		/// クライアントを切断する
		/// </summary>
		/// <param name="context"></param>
		private void CloseClient(ClientContext context)
		{
			clients.Remove(context);
			//invokeServerEvent("クライアントの接続を閉じました。 : " + context.tcpClient.Client.RemoteEndPoint.ToString());
			invokeServerEvent("クライアントの接続を閉じました。");
			invokeServerEvent("現在の接続数: " + clients.Count);
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
			stream.ReadTimeout = 1000;

			// ブロッキングモードでデータを受信
			while (stream.DataAvailable)
			{
				try
				{
					byte type = reader.ReadByte();

					switch (type)
					{
						case 2:
							int size = reader.ReadInt32();
							byte[] byteArray = reader.ReadBytes(size);
							string str = Encoding.UTF8.GetString(byteArray);

							if (context.tcpClient.Client.Connected == false)
								break;

							string message = context.tcpClient.Client.RemoteEndPoint.ToString() + " : " + str;
							invokeServerEvent(message);
							SendMessageAll(message);

							break;
					}
				}
				catch (EndOfStreamException)
				{
					invokeServerEvent("ReadStream() で例外が発生しました。クライアントを切断します。");
					context.StopFlag = true;
					CloseClient(context);
					break;
				}
				catch (IOException)
				{
					// タイムアウト
					invokeServerEvent("ReadStream() で例外が発生しました。クライアントを切断します。");
					context.StopFlag = true;
					CloseClient(context);
					break;

				}
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
			int loopCount = 0;

			if (client.Connected == false)
				return;

			NetworkStream stream = client.GetStream();

			while (!context.StopFlag)
			{
				loopCount++;

				// 接続チェック
                //if (loopCount > 100)
                //{
                //    loopCount = 0;
                //    BinaryWriter writer = new BinaryWriter(stream);
                //    try {
                //        byte packetType = 0;
                //        writer.Write(packetType); 
                //    }
                //    catch (IOException)
                //    {
                //        invokeServerEvent("ClientLoop() で例外が発生しました。クライアントを切断します。");
                //        CloseClient(context);
                //        break;
                //    }
                //}

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
				writer.Write(byteArray.Length);
				writer.Write(byteArray);
				writer.Flush();
			}
			catch (IOException)
			{
				invokeServerEvent("SendMessage() で例外が発生しました。クライアントを切断します。");
				CloseClient(context);
			}
		}

		/// <summary>
		/// 全てのクライアントに文字列のメッセージを送信する
		/// </summary>
		/// <param name="message"></param>
		public void SendMessageAll(string message)
		{
            if (clients != null)
            {
                try
                {
                    foreach (ClientContext context in clients)
                    {
                        SendMessage(context, message);
                    }
                }catch(Exception)
                {
                }
            }
		}


		/// <summary>
		/// サーバ待ち受けループ
		/// </summary>
		private void Listen()
		{
			tcpListener = new TcpListener(IPAddress.Any, Port);
			tcpListener.Start();

			invokeServerEvent("接続を待っています。");

			while (!StopFlag)
			{

				if (tcpListener.Pending())
				{
					try
					{
						Thread thread = new Thread(new ParameterizedThreadStart(ClientLoop));

						TcpClient client = tcpListener.AcceptTcpClient();
						ClientContext context = new ClientContext(client, thread);
						clients.Add(context);

						if (context.tcpClient.Connected == false)
						{
							CloseClient(context);
							continue;
						}

                        //SendMessage(context, "サーバからのメッセージ : 接続しました");

						thread.Start(context);

						invokeServerEvent("クライアントが接続しました。 : " + client.Client.RemoteEndPoint.ToString());
						invokeServerEvent("現在の接続数: " + clients.Count);
					}
					catch (SocketException e)
					{
						invokeServerEvent("エラー (SocketException) : " + e.ToString());
						continue;
					}
				}
				Thread.Sleep(10);
			}
			tcpListener.Stop();
		}

	}
}
