using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNEndpoints.Updater
{
    public partial class WantToUpdateDialog : Form
    {
        public WantToUpdateDialog(string currentVersion, string newVersion, string body)
        {
            InitializeComponent();

            currentVersion_text.Text = "Your Version: " + currentVersion;
            newVersion_text.Text = "Newest Version: " + newVersion;

            richTextBox1.Text = body;
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
