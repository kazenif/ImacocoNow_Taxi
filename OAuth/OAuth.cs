using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace PCGPS.OAuth
{
    public static class OAuth
    {
        public const string OAuthVersion = "1.0";
        public const string OAuthParameterPrefix = "oauth_";

        //
        // List of know and used oauth parameters' names
        //        
        public const string OAuthConsumerKeyKey = "oauth_consumer_key";
        public const string OAuthCallbackKey = "oauth_callback";
        public const string OAuthVersionKey = "oauth_version";
        public const string OAuthSignatureMethodKey = "oauth_signature_method";
        public const string OAuthSignatureKey = "oauth_signature";
        public const string OAuthTimestampKey = "oauth_timestamp";
        public const string OAuthNonceKey = "oauth_nonce";
        public const string OAuthTokenKey = "oauth_token";
        public const string OAuthVerifierKey = "oauth_verifier";
        public const string OAuthTokenSecretKey = "oauth_token_secret";

        public const string XAuthUsernameKey = "x_auth_username";
        public const string XAuthPasswordKey = "x_auth_password";
        public const string XAuthAuthModeKey = "x_auth_mode";

        public const string ClientAuth = "client_auth";

        public const string HMACSHA1SignatureType = "HMAC-SHA1";
        public const string PlainTextSignatureType = "PLAINTEXT";
        public const string RSASHA1SignatureType = "RSA-SHA1";

        private class NameValuePair
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public bool Equals(NameValuePair other)
            {
                return Equals(other.Name, Name) &&
                       Equals(other.Value, Value);
            }

            public override bool Equals(object obj)
            {
                return Equals((NameValuePair)obj);
            }
        }

        private const string ALPHANUMERIC = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static long CreateTimestamp()
        {
            var now = DateTime.UtcNow;
            var then = new DateTime(1970, 1, 1);

            var timespan = (now - then);
            var timestamp = (long)timespan.TotalSeconds;

            return timestamp;
        }

        public static string CreateNonce()
        {
            var sb = new StringBuilder();
            var random = new Random();

            for (var i = 0; i <= 12; i++)
            {
                var index = random.Next(ALPHANUMERIC.Length);
                sb.Append(ALPHANUMERIC[index]);
            }

            return sb.ToString();
        }

        public static string NormalizeUrl(string url)
        {
            Uri uri;

            // only work with a valid URL in lowercase
            if (Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                // only include non-standard ports
                string port = "";
                if (uri.Scheme.Equals("http") && uri.Port != 80 ||
                   uri.Scheme.Equals("https") && uri.Port != 443 ||
                   uri.Scheme.Equals("ftp") && uri.Port != 20)
                {
                    port = ":" + uri.Port;
                }

                // use only the scheme, host, port, and path
                url = uri.Scheme + "://" + uri.Host + port + uri.AbsolutePath;
            }

            return url;
        }

        public static string NormalizeRequestParameters(NameValueCollection parameters)
        {
            var sb = new StringBuilder();

            var list = new List<NameValuePair>();
            foreach (var name in parameters.AllKeys)
            {
                // escaping occurs both here, and during concatenation
                //var value = Uri.EscapeDataString(parameters[name]);
                var value = Util.URLEncode(parameters[name]);
                var item = new NameValuePair { Name = name, Value = value };

                // Ensure duplicates are not included
                if (list.Contains(item))
                {
                    throw new ArgumentException(
                        "Cannot add duplicate parameters");
                }
                list.Add(item);
            }

            list.Sort((left, right) =>
                          {
                              if (left.Name.Equals(right.Name))
                              {
                                  return left.Value.CompareTo(right.Value);
                              }

                              return left.Name.CompareTo(right.Name);
                          });

            foreach (var item in list)
            {
                sb.Append(item.Name + "=" + item.Value);
                if (list.IndexOf(item) < list.Count - 1)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }

        public static string ConcatenateRequestElements(string method, string url, string parameters)
        {
            // URL encode base elements
            url = Util.URLEncode(url);
            parameters = Util.URLEncode(parameters);

            // build signature base according to spec
            var sb = new StringBuilder();
            sb.Append(method.ToUpper()).Append("&");
            sb.Append(url).Append("&");
            sb.Append(parameters);

            return sb.ToString();
        }

        public static string CreateSignature(string signatureBase, string consumerSecret, string tokenSecret)
        {
            if (tokenSecret == null)
            {
                // the token secret is unknown
                tokenSecret = string.Empty;
            }

            // URL encode key elements
            consumerSecret = Util.URLEncode(consumerSecret);
            tokenSecret = Util.URLEncode(tokenSecret);

            // initialize the cryptography provider
            var key = String.Concat(consumerSecret, "&", tokenSecret);
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var signatureMethod = new HMACSHA1(keyBytes);
            
            // create a signature with the base and provider
            var data = Encoding.ASCII.GetBytes(signatureBase);
            var hash = signatureMethod.ComputeHash(data);
            var signature = Convert.ToBase64String(hash);

            // You must encode the URI for safe net travel
            signature = Util.URLEncode(signature);
            return signature;
        }

    }
}
