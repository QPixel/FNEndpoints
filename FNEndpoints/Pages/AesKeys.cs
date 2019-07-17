using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;
using FNEndpoints.Properties;
using FNEndpoints.Scintilla;

namespace FNEndpoints.Pages
{
    public partial class AesKeys : UserControl
    {
        public AesKeys()
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
            myScintilla1.setText(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(Api.GetAesKeys()), Formatting.Indented));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("http://benbotfn.tk:8080/api/aes");
        }
    }
}
