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

namespace FNEndpoints.Pages
{
    public partial class BlogPosts : UserControl
    {
        public BlogPosts()
        {
            InitializeComponent();
        }

        public void updateSettings()
        {
            this.myScintilla1.updateSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myScintilla1.setText(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(Api.GetEndpoint("https://www.epicgames.com/fortnite/api/blog/getPosts?postsPerPage=0&offset=0&locale=" + Properties.Settings.Default.Language, false, RestSharp.Method.GET)), Formatting.Indented));
        }
    }
}
