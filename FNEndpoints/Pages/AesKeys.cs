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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void myScintilla1_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
