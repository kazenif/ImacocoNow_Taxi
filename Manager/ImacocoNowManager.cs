using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace PCGPS.Manager
{
    public class ImacocoNowManager
    {
        public static string version = "";

#if DEBUG
        const string AddressURI = "http://localhost:8080/api/getaddress";
        const string PostURI = "http://localhost:8080/api/post";
        const string DelPostURI = "http://localhost:8080/api/delpost";
#else
        const string AddressURI = "http://imakoko-gps.appspot.com/api/getaddress";
        const string PostURI = "http://imakoko-gps.appspot.com/api/post";
        const string DelPostURI = "http://imakoko-gps.appspot.com/api/delpost";
#endif

        public static string PostLocation(GPSTrackPoint location, string icon)
        {
            string result = "";
            
            // HTTP用WebRequestの作成
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(PostURI);
            req.Method = WebRequestMethods.Http.Post;
            req.Credentials = new NetworkCredential(Properties.Settings.Default.User, Properties.Settings.Default.Password);
            req.PreAuthenticate = true;
            req.Timeout = 6000;
            req.ContentType = "application/x-www-form-urlencoded";
            req.UserAgent = version + " " + Properties.Settings.Default.User;
            if (Properties.Settings.Default.ProxyServer.Length > 0)
            {
                req.Proxy = new WebProxy(string.Format("http://{0}:{1}", Properties.Settings.Default.ProxyServer, Properties.Settings.Default.ProxyPort));
            }

            // HTTPで送信するデータ
            string body = location.GetHttpParameter() + "&save=" + (Properties.Settings.Default.ServerSave ? "1" : "0") +"&t=" + Util.GetIconType(icon);

            // 送信データを書き込む
            req.ContentLength = body.Length;
            using (StreamWriter sw = new StreamWriter(req.GetRequestStream()))
            {
                sw.Write(body);
            }

            // レスポンスを取得
            WebResponse res = req.GetResponse();
            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                result = sr.ReadLine();
                if (result == null)
                {
                    result = "null result.";
                }
            }
            if (Properties.Settings.Default.SoundPost != "")
            {
                Util.PlaySEFromFile(Properties.Settings.Default.SoundPost);
            }
            else
            {
                Util.PlaySE("PCGPS.Resources.b_067.wav");
            }
            return result;
        }


        public static string DeleteLocation()
        {
            string result = "";
            // HTTP用WebRequestの作成
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(DelPostURI);
            req.Method = WebRequestMethods.Http.Get;
            req.Credentials = new NetworkCredential(Properties.Settings.Default.User, Properties.Settings.Default.Password);
            req.PreAuthenticate = true;
            req.UserAgent = version + " " + Properties.Settings.Default.User;
            req.Timeout = 6000;
            if (Properties.Settings.Default.ProxyServer.Length > 0)
            {
                req.Proxy = new WebProxy(string.Format("http://{0}:{1}", Properties.Settings.Default.ProxyServer, Properties.Settings.Default.ProxyPort));
            }

            // レスポンスを取得
            WebResponse res = req.GetResponse();
            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                result = sr.ReadLine();
                if (result == null)
                {
                    result = "null result.";
                }
            }
            return result;
        }
    }
}
