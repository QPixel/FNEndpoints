﻿using FNEndpoints.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNEndpoints
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public Form1()
        {
            instance = this;

            InitializeComponent();

            updateSettings();

            update();

            openPage(null);
        }

        public void updateSettings()
        {
            this.timeline_button.Image = (Properties.Settings.Default.Images) ? (Resources.timeline) : null;
            this.timeline_button.Text = (Properties.Settings.Default.Images) ? "" : "Timeline";

            this.news_button.Image = (Properties.Settings.Default.Images) ? (Resources.news) : null;
            this.news_button.Text = (Properties.Settings.Default.Images) ? "" : "News";

            this.aesKey_button.Image = (Properties.Settings.Default.Images) ? (Resources.aesKeys) : null;
            this.aesKey_button.Text = (Properties.Settings.Default.Images) ? "" : "AesKeys";

            this.ltm_info_button.Image = (Properties.Settings.Default.Images) ? (Resources.ltmInfo) : null;
            this.ltm_info_button.Text = (Properties.Settings.Default.Images) ? "" : "LTM Info";

            this.store_button.Image = (Properties.Settings.Default.Images) ? (Resources.store) : null;
            this.store_button.Text = (Properties.Settings.Default.Images) ? "" : "Store";

            this.status_button.Image = (Properties.Settings.Default.Images) ? (Resources.status) : null;
            this.status_button.Text = (Properties.Settings.Default.Images) ? "" : "Status";

            this.timeline1.updateSettings();
            this.news1.updateSettings();
            this.aesKeys1.updateSettings();
            this.ltm_info1.updateSettings();
            this.store1.updateSettings();
            this.status1.updateSettings();

        }


        async public void update()
        {
            var currentVersion = Assembly.GetEntryAssembly().GetName().Version;
            string jsonReponse = await getNewestUpdateResponse();
            if(jsonReponse != "")
            {
                dynamic json = JsonConvert.DeserializeObject(jsonReponse);

                var newVersion = new Version(Convert.ToString(json.tag_name));
                if (newVersion > currentVersion)
                {
                    DialogResult dialogResult = MessageBox.Show("Update available, \nDo you want to update? \n\nYou have version " + currentVersion.ToString() + " and newest version is " + newVersion.ToString(), "Update available", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        JArray oldAssets = json.assets;
                        List<dynamic> assets = new List<dynamic>();
                        for(int i = 0; i < oldAssets.Count; i++)
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

        async public Task<string> getNewestUpdateResponse()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("C# App");
                return await httpClient.GetStringAsync("https://api.github.com/repos/fnbrDailyy/FNEndpoints/releases/latest");
            } catch(HttpRequestException)
            {
                return "";
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new Settings(this);
            if (Application.OpenForms[settingsForm.Name] == null)
            {
                settingsForm.Show();
            }
            else
            {
                Application.OpenForms[settingsForm.Name].Focus();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new About();
            if (Application.OpenForms[aboutForm.Name] == null)
            {
                aboutForm.Show();
            }
            else
            {
                Application.OpenForms[aboutForm.Name].Focus();
            }
        }

        private void openPage(UserControl form)
        {
            timeline1.Visible = form == timeline1 ? true : false;
            ltm_info1.Visible = form == ltm_info1 ? true : false;
            news1.Visible = form == news1 ? true : false;
            aesKeys1.Visible = form == aesKeys1 ? true : false; 
            store1.Visible = form == store1 ? true : false;
            status1.Visible = form == status1 ? true : false;
        }

        private void timeline_button_Click(object sender, EventArgs e)
        {
            openPage(timeline1);
        }

        private void ltm_button_Click(object sender, EventArgs e)
        {
            openPage(ltm_info1);
        }

        private void news_button_Click(object sender, EventArgs e)
        {
            openPage(news1);
        }

        private void aesKey_button_Click(object sender, EventArgs e)
        {
            openPage(aesKeys1);
        }

        private void store_button_Click(object sender, EventArgs e)
        {
            openPage(store1);
        }

        private void status_button_Click(object sender, EventArgs e)
        {
            openPage(status1);
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
