using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PCGPS
{
	/// <summary>
	/// TCP サーバに接続するクライアント 1 件分の情報
	/// </summary>
	class ClientContext
	{
		/// <summary>
		/// TCP クライアント
		/// </summary>
		public TcpClient tcpClient;

		/// <summary>
		/// データ受信待ちスレッド
		/// </summary>
		public Thread thread;

		/// <summary>
		/// 停止フラグ
		/// </summary>
		public bool StopFlag;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="tcpClient"></param>
		/// <param name="thread"></param>
		public ClientContext(TcpClient tcpClient, Thread thread)
		{
			this.tcpClient = tcpClient;
			this.thread = thread;
			StopFlag = false;
		}
	}
}
