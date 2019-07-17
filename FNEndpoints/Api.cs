using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNEndpoints
{
    class Api
    {
        public static string GetEndpoint(string url, bool auth, Method method)
        {
            RestClient EndpointClient = new RestClient(url);
            RestRequest EndpointRequest = new RestRequest(method);

            if (auth)
            {
                EndpointRequest.AddHeader("Authorization", "bearer " + getExchangeToken(getAccessCode(getAccessToken(Properties.Settings.Default.EpicEmail, Properties.Settings.Default.EpicPassword))));
            }
            EndpointRequest.AddHeader("Accept-Language", Properties.Settings.Default.Language);
            EndpointRequest.AddHeader("X-EpicGames-Language", Properties.Settings.Default.Language);

            var response = EndpointClient.Execute(EndpointRequest);
            string content = response.Content;

            return content;
        }
        public static string GetAesKeys()
        {
            if (Properties.Settings.Default.pakPath != "" && Directory.Exists(Properties.Settings.Default.pakPath))
            {
                string mainKey;
                {
                    string aesApi = GetEndpoint("http://benbotfn.tk:8080/api/aes", false, Method.GET);
                    dynamic json = JsonConvert.DeserializeObject(aesApi);
                    mainKey = json.mainKey;
                }
                JArray additionalKeys = new JArray();
                {
                    string keychain = GetEndpoint("https://fortnite-public-service-prod11.ol.epicgames.com/fortnite/api/storefront/v2/keychain", true, Method.GET);
                    dynamic json = JsonConvert.DeserializeObject(keychain);
                    if (json != null)
                    {

                        var files = Directory.GetFiles(Properties.Settings.Default.pakPath).Where(x => x.EndsWith(".pak"));
                        for (int i = 0; i < files.Count(); i++)
                        {
                            var guid = ReadPakGuid(files.ElementAt(i));
                            if (guid != "0-0-0-0")
                            {

                                foreach (string myString in json)
                                {
                                    string[] parts = myString.Split(':');
                                    string keychainguid = getPakGuidFromKeychain(parts[0]);

                                    if(guid == keychainguid)
                                    {
                                        byte[] bytes = Convert.FromBase64String(parts[1]);
                                        string aeskey = BitConverter.ToString(bytes).Replace("-", "");

                                        JObject jobj = new JObject();
                                        if (parts.Length >= 3) jobj.Add("item", "" + parts[2]);
                                        jobj.Add("pak file", files.ElementAt(i));
                                        jobj.Add("AESKey", "0x" + aeskey);

                                        additionalKeys.Add(jobj);
                                    }
                                }
                            }
                        }
                    }
                }
                JObject returning = new JObject();
                returning.Add("mainKey", mainKey);
                returning.Add("additionalKeys", additionalKeys);
                return returning.ToString();
            } else {
                return "{ error: \"Your PakPath is wrong, set it in the settings!\" }";
            }
        }

        private static IEnumerable<string> SplitGuid(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        public static string getPakGuidFromKeychain(string KeychainPart)
        {
            StringBuilder sB = new StringBuilder();
            IEnumerable<string> guid = SplitGuid(KeychainPart, 8);
            int count = 0;

            foreach (string p in guid)
            {
                count += 1;

                if (count != guid.Count()) { sB.Append((uint)int.Parse(p, NumberStyles.HexNumber) + "-"); }
                else { sB.Append((uint)int.Parse(p, NumberStyles.HexNumber)); }
            }

            return sB.ToString();
        }
        public static string ReadPakGuid(string pakPath)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(pakPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                reader.BaseStream.Seek(reader.BaseStream.Length - 61 - 160, SeekOrigin.Begin);
                uint g1 = reader.ReadUInt32();
                reader.BaseStream.Seek(reader.BaseStream.Length - 57 - 160, SeekOrigin.Begin);
                uint g2 = reader.ReadUInt32();
                reader.BaseStream.Seek(reader.BaseStream.Length - 53 - 160, SeekOrigin.Begin);
                uint g3 = reader.ReadUInt32();
                reader.BaseStream.Seek(reader.BaseStream.Length - 49 - 160, SeekOrigin.Begin);
                uint g4 = reader.ReadUInt32();

                string guid = g1 + "-" + g2 + "-" + g3 + "-" + g4;
                return guid;
            }
        }
        private static string getAccessToken(string email, string password)
        {
            RestClient getAccessTokenClient = new RestClient("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/token");
            RestRequest getAccessTokenRequest = new RestRequest(Method.POST);

            getAccessTokenRequest.AddParameter("grant_type", "password");
            getAccessTokenRequest.AddParameter("username", email);
            getAccessTokenRequest.AddParameter("password", password);
            getAccessTokenRequest.AddParameter("includePerms", "true");

            getAccessTokenRequest.AddHeader("Authorization", "basic MzQ0NmNkNzI2OTRjNGE0NDg1ZDgxYjc3YWRiYjIxNDE6OTIwOWQ0YTVlMjVhNDU3ZmI5YjA3NDg5ZDMxM2I0MWE=");
            getAccessTokenRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            dynamic response = JsonConvert.DeserializeObject(getAccessTokenClient.Execute(getAccessTokenRequest).Content);
            return response["access_token"];
        }
        private static string getAccessCode(string accessToken)
        {
            RestClient getAccessCodeClient = new RestClient("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/exchange");
            RestRequest getAccessCodeRequest = new RestRequest(Method.GET);

            getAccessCodeRequest.AddHeader("Authorization", "bearer " + accessToken);

            dynamic response = JsonConvert.DeserializeObject(getAccessCodeClient.Execute(getAccessCodeRequest).Content);

            return response.code;
        }
        private static string getExchangeToken(string accessCode)
        {
            RestClient getExchangeTokenClient = new RestClient("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/token");
            RestRequest getExchangeTokenRequest = new RestRequest(Method.POST);

            getExchangeTokenRequest.AddHeader("Authorization", "basic ZWM2ODRiOGM2ODdmNDc5ZmFkZWEzY2IyYWQ4M2Y1YzY6ZTFmMzFjMjExZjI4NDEzMTg2MjYyZDM3YTEzZmM4NGQ=");
            getExchangeTokenRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            getExchangeTokenRequest.AddParameter("grant_type", "exchange_code");
            getExchangeTokenRequest.AddParameter("exchange_code", accessCode);
            getExchangeTokenRequest.AddParameter("includePerms", true);
            getExchangeTokenRequest.AddParameter("token_type", "eg1");

            dynamic response = JsonConvert.DeserializeObject(getExchangeTokenClient.Execute(getExchangeTokenRequest).Content);

            return response["access_token"];
        }
    }
}
