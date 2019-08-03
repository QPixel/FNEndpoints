using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNEndpoints.Updater
{
    class Updater
    {
        async public static void checkForUpdate()
        {
            var currentVersion = Assembly.GetEntryAssembly().GetName().Version;
            string jsonReponse = await getNewestUpdateResponse();
            if (jsonReponse != "")
            {
                dynamic json = JsonConvert.DeserializeObject(jsonReponse);

                var newVersion = new Version(Convert.ToString(json.tag_name));
                if (newVersion > currentVersion)
                {
                    WantToUpdateDialog wantToUpdateDialog = new WantToUpdateDialog(currentVersion.ToString(), newVersion.ToString(), ((JValue)json.body).ToString());
                    DialogResult dialogResult = wantToUpdateDialog.ShowDialog();
                    if (dialogResult == DialogResult.Yes)
                    {
                        JArray oldAssets = json.assets;
                        List<dynamic> assets = new List<dynamic>();
                        for (int i = 0; i < oldAssets.Count; i++)
                        {
                            string name = ((string)((JObject)oldAssets[i]).GetValue("name"));
                            if (name.Substring(name.Length - 4) == ".zip")
                            {
                                assets.Add(json.assets[i]);
                            }
                        }
                        ShowUpdateForm(Convert.ToString(assets[0].browser_download_url));

                    }
                }
            }

        }

        public static void ShowUpdateForm(string url)
        {
            var updateForm = new DownloadUpdateDialog(url);
            if (updateForm.ShowDialog().Equals(DialogResult.OK))
            {
                Application.Exit();
            }
        }

        async public static Task<string> getNewestUpdateResponse()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("C# App");
                return await httpClient.GetStringAsync("https://api.github.com/repos/RythenGlyth/FNEndpoints/releases/latest");
            }
            catch (HttpRequestException)
            {
                return "";
            }
        }
    }
}
