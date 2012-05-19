using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace PCGPS
{
    public class BouyomiChanClient
    {
        public static byte bCode = 0;
        public static Int16 iVoice = 1;
        public static Int16 iVolume = -1;
        public static Int16 iSpeed = -1;
        public static Int16 iTone = -1;
        public static Int16 iCommand = 0x0001;
 
        public static bool Talk(string text)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient("127.0.0.1", 50001);
                byte[] bMessage = Encoding.UTF8.GetBytes(text);
                Int32 iLength = bMessage.Length;

                //メッセージ送信
                using (NetworkStream ns = client.GetStream())
                {
                    using (BinaryWriter bw = new BinaryWriter(ns))
                    {
                        bw.Write(iCommand); //コマンド（ 0:メッセージ読み上げ）
                        bw.Write(iSpeed);   //速度    （-1:棒読みちゃん画面上の設定）
                        bw.Write(iTone);    //音程    （-1:棒読みちゃん画面上の設定）
                        bw.Write(iVolume);  //音量    （-1:棒読みちゃん画面上の設定）
                        bw.Write(iVoice);   //声質    （ 0:棒読みちゃん画面上の設定、1:女性1、2:女性2、3:男性1、4:男性2、5:中性、6:ロボット、7:機械1、8:機械2）
                        bw.Write(bCode);    //文字列のbyte配列の文字コード(0:UTF-8, 1:Unicode, 2:Shift-JIS)
                        bw.Write(iLength);  //文字列のbyte配列の長さ
                        bw.Write(bMessage); //文字列のbyte配列
                    }
                }

                //切断
                client.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
