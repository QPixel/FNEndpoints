using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNEndpoints.Utils
{
    class TwitterApi
    {
        readonly string consumerKey, consumerKeySecret, accessToken, accessTokenSecret;

        public TwitterApi(string consumerKey, string consumerKeySecret, string accessToken, string accessTokenSecret)
        {
            this.consumerKey = consumerKey;
            this.consumerKeySecret = consumerKeySecret;
            this.accessToken = accessToken;
            this.accessTokenSecret = accessTokenSecret;
        }

        public string buildEndpoint(string path, string baseName)
        {
            Dictionary<string, string> bases = new Dictionary<string, string>
            {
                { "rest", "https://api.twitter.com/1.1" },
                { "stream", "https://stream.twitter.com/1.1" },
                { "user_stream", "https://userstream.twitter.com/1.1" },
                { "site_stream", "https://sitestream.twitter.com/1.1" },
                { "media", "https://upload.twitter.com/1.1" }
            };
            string endpoint = bases.ContainsKey(baseName) ? bases[baseName] : bases["rest_base"];
            Uri uri = null;
            bool isFullUrl = (Uri.TryCreate(path, UriKind.Absolute, out uri) && null != uri);
            if(isFullUrl)
            {
                endpoint = path;
            } else
            {
                if(Regex.Match(path, "media/").Success)
                {
                    endpoint = bases["media"];
                }
                endpoint += (path.ElementAt(0) == '/') ? path : '/' + path;
            }
            endpoint = Regex.Replace(endpoint, "/$", "");

            if(isFullUrl)
            {
                endpoint += (path.Split('.').Last() != "json") ? ".json" : "";
            }

            return endpoint;
        }

        async public Task<string> request(Method method, string path, Dictionary<string, dynamic> parameter)
        {
            /*MessageBox.Show(accessToken + "\n" + accessTokenSecret + "\n" + consumerKey + "\n" + consumerKeySecret);
            try
            {
                string baseName = "rest";

                if (parameter["base"] != null)
                {
                    baseName = parameter["base"];
                    parameter.Remove("base");
                }

                string url = buildEndpoint(path, baseName);

                string oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
                var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                string oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();

                string baseString = "OAuth oauth_once=\"" + oauth_nonce + "\",oauth_signature_method=\"HMAC-SHA1\",oauth_timestamp=\"" + oauth_timestamp + "\",oauth_consumer_key=\"" + consumerKey + "\",oauth_token=\"" + accessToken + "\",oauth_version=\"2.0\"";
                string compositeKey = string.Concat(Uri.EscapeDataString(consumerKeySecret),
                                    "&", Uri.EscapeDataString(accessTokenSecret));

                string newBaseString = string.Concat(method, "&", Uri.EscapeDataString(url), "&", Uri.EscapeDataString(baseString));


                string oauth_signature;
                using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
                {
                    oauth_signature = Convert.ToBase64String(
                        hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
                }

                using (var wb = new WebClient())
                {
                    wb.Headers["Authorization"] = baseString + "oauth_signature \"" + oauth_signature + "\"";
                    wb.Headers["User-Agent"] = "Twitter-Api/1.0";
                    var response = wb.UploadValues(url, method, parameter);
                    string responseInString = Encoding.UTF8.GetString(response);

                    return responseInString;
                }
            } catch(Exception ex)
            {
                return ex.ToString();
            }*/

            string baseName = "rest";

            if (parameter.ContainsKey("base"))
            {
                baseName = parameter["base"];
                parameter.Remove("base");
            }

            string url = buildEndpoint(path, baseName);

            RestClient restClient = new RestClient(url);
            
            restClient.Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerKeySecret, accessToken, accessTokenSecret);

            RestRequest restRequest = new RestRequest(method);

            restRequest.AddHeader("User-Agent", "Twitter-Api");
            restRequest.AddHeader("Connection", "Close");
            restRequest.AddHeader("Accept", "*/*");

            for(int i = 0; i < parameter.Count; i++)
            {
                if(parameter.ToArray()[i].Value is byte[])
                {
                    restRequest.AddFileBytes(parameter.ToArray()[i].Key, parameter.ToArray()[i].Value, parameter.ToArray()[i].Key);
                } else
                {
                    restRequest.AddParameter(parameter.ToArray()[i].Key, parameter.ToArray()[i].Value);
                }
            }

            IRestResponse response = restClient.Execute(restRequest);

            return response.Content;
        }

    }
}
