using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Xml;

using PCGPS.OAuth;

namespace PCGPS.Manager
{
    public class TwitterManager
    {
        public static string Tweet(string status, GPSTrackPoint location)
        {
            string result;
            string url = "http://twitter.com/statuses/update.xml";

            Dictionary<string, string> postData = new Dictionary<string, string>();
            //postData.Add("status", Util.URLEncode(status));
            postData.Add("status", status);
            if (Properties.Settings.Default.LocationTwit)
            {
                postData.Add("lat", Math.Round(location.Latitude, 6).ToString());
                postData.Add("long", Math.Round(location.Longitude, 6).ToString());
            }

            Dictionary<string, string> headers = TwitterOAuth.getInstance().createOAuthHeader("POST", url, postData);
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (string key in postData.Keys)
            {
                if (!first)
                {
                    sb.Append("&");
                }
                else
                {
                    first = false;
                }
                sb.Append(String.Format("{0}={1}", key, Util.URLEncode( postData[key] )));
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ServicePoint.Expect100Continue = false;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = WebRequestMethods.Http.Post;
            request.Timeout = 8000;
            foreach (string key in headers.Keys)
            {
                request.Headers.Add(key, headers[key]);
            }

            if (Properties.Settings.Default.ProxyServer.Length > 0)
            {
                request.Proxy = new WebProxy(string.Format("http://{0}:{1}", Properties.Settings.Default.ProxyServer, Properties.Settings.Default.ProxyPort));
            }

            byte[] bytes = Encoding.ASCII.GetBytes(sb.ToString());
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        public static bool GeoEnabled()
        {
            bool result = false;
            string url = "http://twitter.com/account/verify_credentials.xml";

            Dictionary<string, string> headers = TwitterOAuth.getInstance().createOAuthHeader("GET", url, new Dictionary<string, string>());
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ServicePoint.Expect100Continue = false;
            foreach (string key in headers.Keys)
            {
                request.Headers.Add(key, headers[key]);
            }
            request.Method = WebRequestMethods.Http.Get;
            request.Timeout = 8000;
            if (Properties.Settings.Default.ProxyServer.Length > 0)
            {
                request.Proxy = new WebProxy(string.Format("http://{0}:{1}", Properties.Settings.Default.ProxyServer, Properties.Settings.Default.ProxyPort));
            }

            using (WebResponse response = request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string r = reader.ReadToEnd();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(r);
                XmlNodeList list = doc.SelectNodes("/user/geo_enabled");
                if (list != null && list.Count > 0)
                {
                    XmlNode node = list[0];
                    result = bool.Parse(node.InnerText);
                }
            }
            return result;
        }
    
    
    }
}
