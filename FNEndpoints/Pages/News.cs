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
using FNEndpoints.Properties;
using Newtonsoft.Json.Linq;
using FNEndpoints.Scintilla;

namespace FNEndpoints.Pages
{
    public partial class News : UserControl
    {
        public News()
        {
            InitializeComponent();

            updateSettings();
        }

        public void updateSettings()
        {
            this.myScintilla1.updateSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string response = Api.GetEndpoint("https://fortnitecontent-website-prod07.ol.epicgames.com/content/api/pages/fortnite-game", false, RestSharp.Method.GET);
            dynamic obj = JsonConvert.DeserializeObject(response);
            JObject jobj = new JObject();

            jobj.Add("common", obj.athenamessage.overrideablemessage);

            JObject subgame = new JObject();
            subgame.Add("battleRoyale", obj.subgameselectdata.battleRoyale);
            subgame.Add("creative", obj.subgameselectdata.creative);
            subgame.Add("saveTheWorld", obj.subgameselectdata.saveTheWorld);
            subgame.Add("saveTheWorldUnowned", obj.subgameselectdata.saveTheWorldUnowned);
            jobj.Add("subgame", subgame);

            jobj.Add("br", obj.battleroyalenews.news);
            jobj.Add("battlepass", obj.battlepassaboutmessages.news);
            jobj.Add("stw", obj.savetheworldnews.news);
            jobj.Add("loginmessage", obj.loginmessage.loginmessage);
            jobj.Add("survivalmessage", obj.survivalmessage.overrideablemessage);
            jobj.Add("tournamentinformation", obj.tournamentinformation.tournament_info);
            jobj.Add("emergencynotice", obj.emergencynotice.news);

            var json = JsonConvert.SerializeObject(jobj, Formatting.Indented);
            
            myScintilla1.setText(json);
        }
    }
}
