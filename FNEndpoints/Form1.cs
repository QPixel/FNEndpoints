using FNEndpoints.Properties;
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

            Updater.Updater.checkForUpdate();

            openPage(null);
        }

        public void updateSettings()
        {

            this.timeline1.updateSettings();
            this.news1.updateSettings();
            this.aesKeys1.updateSettings();
            this.ltm_info1.updateSettings();
            this.store1.updateSettings();
            this.status1.updateSettings();

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

        private void openPage(UserControl form)
        {
            timeline1.Visible = form == timeline1;
            ltm_info1.Visible = form == ltm_info1;
            news1.Visible = form == news1;
            aesKeys1.Visible = form == aesKeys1; 
            store1.Visible = form == store1;
            status1.Visible = form == status1;
            blogPosts1.Visible = form == blogPosts1;
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

        private void button1_Click(object sender, EventArgs e)
        {
            openPage(blogPosts1);
        }
    }
}
