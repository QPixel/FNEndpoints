using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using FNEndpoints.Properties;

namespace FNEndpoints.Pages
{
    public partial class Status : UserControl
    {
        public Status()
        {
            InitializeComponent();
        }

        public void updateSettings()
        {
            this.myScintilla1.updateSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myScintilla1.setText(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(Api.GetEndpoint("https://lightswitch-public-service-prod06.ol.epicgames.com/lightswitch/api/service/bulk/status?serviceId=Fortnite", true, Method.GET)), Formatting.Indented));
        }
    }
}
