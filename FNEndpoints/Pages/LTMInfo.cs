using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FNEndpoints.Properties;
using Newtonsoft.Json;
using FNEndpoints.Scintilla;

namespace FNEndpoints.Pages
{
    public partial class LTMInfo : UserControl
    {
        public LTMInfo()
        {
            InitializeComponent();

            updateSettings();
        }

        public void updateSettings()
        {
            this.button1.Image = (Properties.Settings.Default.Images) ? (Resources.load) : null;
            this.button1.Text = (Properties.Settings.Default.Images) ? "" : "Load";
            this.myScintilla1.updateSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string response = Api.GetEndpoint("https://fortnitecontent-website-prod07.ol.epicgames.com/content/api/pages/fortnite-game", false, RestSharp.Method.GET);
            dynamic obj = JsonConvert.DeserializeObject(response);
            var json = JsonConvert.SerializeObject(obj.playlistinformation, Formatting.Indented);
            
            myScintilla1.setText(json);
        }
    }
}
