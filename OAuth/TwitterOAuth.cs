using System;

using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace PCGPS.OAuth
{
    public class TwitterOAuth
    {
        private static String CONSUMER_KEY = "g1QHkn8QjcXop6TvR1LIg";
        private static String CONSUMER_SECRET = "QxVShkTNgoMPRvWIilqT4sFvsIOvfdHBWDSlT2Y1zU";
        // private static String AUTHORIZATION_URL = "http://twitter.com/oauth/authorize";
        // private static String REQUEST_TOKEN_URL = "http://twitter.com/oauth/request_token";
        // private static String ACCESS_TOKEN_URL = "http://twitter.com/oauth/access_token";
        // private static String CALLBACK_URL = "http://localhost:11962/";
        private static String XAUTH_URL = "https://api.twitter.com/oauth/access_token";

        private static TwitterOAuth instance = null;

        public static TwitterOAuth getInstance()
        {
            if (instance == null)
            {
                instance = new TwitterOAuth();
            }
            return instance;
        }

        private string token;

        public string Token
        {
            get { return token; }
            set { token = value; }
        }
        private string tokenSecret;

        public string TokenSecret
        {
            get { return tokenSecret; }
            set { tokenSecret = value; }
        }
        private string consumerKey;

        public string ConsumerKey
        {
            get { return consumerKey; }
            set { consumerKey = value; }
        }
        private string consumerSecret;

        public string ConsumerSecret
        {
            get { return consumerSecret; }
            set { consumerSecret = value; }
        }

        private TwitterOAuth()
        {
            token = Properties.Settings.Default.OAuthToken;
            tokenSecret = Properties.Settings.Default.OAuthTokenSecret;
            consumerKey = CONSUMER_KEY;
            consumerSecret = CONSUMER_SECRET;
        }

        public bool getAccessToken(string username, string password)
        {
            var timestamp = OAuth.CreateTimestamp().ToString();
            var nonce = OAuth.CreateNonce();
            var oauthParameters = new NameValueCollection
            {
                {OAuth.OAuthTimestampKey, timestamp},
                {OAuth.OAuthNonceKey, nonce},
                {OAuth.OAuthVersionKey, OAuth.OAuthVersion},
                {OAuth.OAuthSignatureMethodKey, OAuth.HMACSHA1SignatureType},
                {OAuth.OAuthConsumerKeyKey, CONSUMER_KEY},
                {OAuth.XAuthAuthModeKey, OAuth.ClientAuth},
                {OAuth.XAuthPasswordKey, password},
                {OAuth.XAuthUsernameKey, username}
            };

            // prepare a signature base
            string url = OAuth.NormalizeUrl(XAUTH_URL);
            var parameters = OAuth.NormalizeRequestParameters(oauthParameters);
            var signatureBase = OAuth.ConcatenateRequestElements("POST", url, parameters);

            // obtain a signature and add it to oauth header parameters
            var signature = OAuth.CreateSignature(signatureBase, CONSUMER_SECRET, null);
            oauthParameters.Add(OAuth.OAuthSignatureKey, signature);

            // build request authorization header
            var header = new StringBuilder();
            header.Append("OAuth realm=\"Twitter API\",");
            for (var i = 0; i < oauthParameters.Count; i++)
            {
                var key = oauthParameters.GetKey(i);
                var pair = key + "=\"" + oauthParameters[key] + "\"";

                header.Append(pair);
                if (i < oauthParameters.Count - 1)
                {
                    header.Append(",");
                }
            }

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers["Authorization"] = header.ToString();


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ServicePoint.Expect100Continue = false;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = WebRequestMethods.Http.Post;
            request.Timeout = 7000;
            foreach (string key in headers.Keys)
            {
                request.Headers.Add(key, headers[key]);
            }

            if (Properties.Settings.Default.ProxyServer.Length > 0)
            {
                request.Proxy = new WebProxy(string.Format("http://{0}:{1}", Properties.Settings.Default.ProxyServer, Properties.Settings.Default.ProxyPort));
            }

            byte[] bytes = Encoding.UTF8.GetBytes(
                string.Format("{0}={1}&{2}={3}&{4}={5}",
                    OAuth.XAuthAuthModeKey, OAuth.ClientAuth,
                    OAuth.XAuthPasswordKey, Util.URLEncode(password),
                    OAuth.XAuthUsernameKey, Util.URLEncode(username))
                );
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new UnauthorizedAccessException();
                }

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    Dictionary<String, String> dict = new Dictionary<string, string>();
                    string s;
                    while ((s = reader.ReadLine()) != null)
                    {
                        foreach (string r in s.Split('&'))
                        {
                            string[] kv = r.Split('=');
                            if (kv.Length == 2)
                            {
                                dict[kv[0]] = kv[1];
                            }
                        }
                    }
                    token = Properties.Settings.Default.OAuthToken = dict[OAuth.OAuthTokenKey];
                    tokenSecret = Properties.Settings.Default.OAuthTokenSecret = dict[OAuth.OAuthTokenSecretKey];
                }
            }
            return true;
        }

        public Dictionary<string, string> createOAuthHeader(string method, string url, Dictionary<String, String> postData)
        {
            var oauthParameters = new NameValueCollection
            {
                {OAuth.OAuthTimestampKey,  OAuth.CreateTimestamp().ToString()},
                {OAuth.OAuthNonceKey, OAuth.CreateNonce()},
                {OAuth.OAuthVersionKey, OAuth.OAuthVersion},
                {OAuth.OAuthSignatureMethodKey, OAuth.HMACSHA1SignatureType},
                {OAuth.OAuthConsumerKeyKey, consumerKey},
                {OAuth.OAuthTokenKey, token}
            };
            if (postData != null)
            {
                foreach (String key in postData.Keys)
                {
                    oauthParameters.Add(key, postData[key]);
                }
            }
            int index = url.IndexOf("?");
            if (index != -1)
            {
                string[] kv = url.Substring(index + 1).Split('&');
                foreach (string s in kv)
                {
                    string[] s2 = s.Split('=');
                    oauthParameters.Add(s2[0], s2[1]);
                }
            }

            foreach (string s in oauthParameters.Keys)
            {
                System.Console.WriteLine(s + "=" + oauthParameters[s]);
            }
            
            // prepare a signature base
            url = OAuth.NormalizeUrl(url);
            System.Console.WriteLine("Normalize URL = " + url);
            var parameters = OAuth.NormalizeRequestParameters(oauthParameters);
            System.Console.WriteLine("parameters = " + parameters);
            var signatureBase = OAuth.ConcatenateRequestElements(method, url, parameters);
            System.Console.WriteLine("signatureBase = " + signatureBase);

            // obtain a signature and add it to oauth header parameters
            var signature = OAuth.CreateSignature(signatureBase, CONSUMER_SECRET, tokenSecret);
            System.Console.WriteLine("signature = " + signature);

            if (postData != null)
            {
                foreach (String key in postData.Keys)
                {
                    oauthParameters.Remove(key);
                }
            }
            if (index != -1)
            {
                string[] kv = url.Substring(index + 1).Split('&');
                foreach (string s in kv)
                {
                    string[] s2 = s.Split('=');
                    oauthParameters.Remove(s2[0]);
                }
            }
            oauthParameters.Add(OAuth.OAuthSignatureKey, signature);


            // build request authorization header
            var header = new StringBuilder();
            header.Append("OAuth realm=\"" + url + "\",");
            for (var i = 0; i < oauthParameters.Count; i++)
            {
                var key = oauthParameters.GetKey(i);
                var pair = key + "=\"" + oauthParameters[key] + "\"";

                header.Append(pair);
                if (i < oauthParameters.Count - 1)
                {
                    header.Append(",");
                }
            }
            System.Console.WriteLine("Authorization = " + header.ToString());

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers["Authorization"] = header.ToString();
            return headers;
        }
    }
}
