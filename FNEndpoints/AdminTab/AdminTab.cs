using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using FNEndpoints.Utils;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FNEndpoints.AdminTab
{
    public partial class AdminTab : Form
    {

        private string passwordHash = "5A984EE50B1DE2224BAA3407A4578E52A70275D9AB36DE7E682C124C6B294233";
        private string passwordHash2 = "312433C28349F63C4F387953FF337046E794BEA0F9B9EBFCB08E90046DED9C76";

        public bool show = true;

        public AdminTab(string password)
        {
            if (ComputeSha256Hash(password).ToLower() == passwordHash.ToLower() || ComputeSha256Hash(password).ToLower() == passwordHash2.ToLower())
            {
                InitializeComponent();

                consumer_key.Text = Properties.Settings.Default.consumer_key;
                consumer_secret.Text = Properties.Settings.Default.consumer_secret;
                access_token_key.Text = Properties.Settings.Default.access_token_key;
                access_token_secret.Text = Properties.Settings.Default.access_token_secret;
            }
            else
            {
                MessageBox.Show("Wrong Password!");
                show = false;
            }

        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.consumer_key = consumer_key.Text;
            Properties.Settings.Default.consumer_secret = consumer_secret.Text;
            Properties.Settings.Default.access_token_key = access_token_key.Text;
            Properties.Settings.Default.access_token_secret = access_token_secret.Text;
            Properties.Settings.Default.Save();
        }

        private void AdminTab_Load(object sender, EventArgs e)
        {
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            TwitterApi twitterApi = new TwitterApi(
                Properties.Settings.Default.consumer_key,
                Properties.Settings.Default.consumer_secret,
                Properties.Settings.Default.access_token_key,
                Properties.Settings.Default.access_token_secret);
            List<byte[]> buffer = new List<byte[]>();

            if (textBox1.Text != "" && File.Exists(textBox1.Text)) buffer.Add(GetBytesAsPngFromImage(textBox1.Text));
            if (textBox2.Text != "" && File.Exists(textBox2.Text)) buffer.Add(GetBytesAsPngFromImage(textBox2.Text));
            if (textBox3.Text != "" && File.Exists(textBox3.Text)) buffer.Add(GetBytesAsPngFromImage(textBox3.Text));
            if (textBox4.Text != "" && File.Exists(textBox4.Text)) buffer.Add(GetBytesAsPngFromImage(textBox4.Text));

            List<string> mediaIds = new List<string>();

            for (int ic = 0; ic < buffer.ToArray().Length; ic++)
            {
                byte[] buff = buffer.ToArray()[ic];
                File.WriteAllBytes(@"D:\Downloads\sas.png", buff);

                var args = new Dictionary<string, dynamic>() { { "media", buff } };
                foreach (KeyValuePair<string, dynamic> arg in args)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", arg.Key, arg.Value);
                }

                string mediaResponse = await twitterApi.request(RestSharp.Method.POST, "media/upload.json", args);

                Console.WriteLine(mediaResponse);

                JObject json = JObject.Parse(mediaResponse);
                mediaIds.Add(json.GetValue("media_id_string").ToString());
            }
            
            var media_ids = mediaIds.ToArray().Length > 0 ? mediaIds.ToArray()[0] : "";
            var i = 1;
            while (i < mediaIds.ToArray().Length)
            {
                media_ids += "," + mediaIds.ToArray()[i];
                i++;
            }
            string response = await twitterApi.request(RestSharp.Method.POST, "statuses/update.json", new Dictionary<string, dynamic>()
            {
                {"status", status_textbox.Text},
                {"media_ids", media_ids != null ? media_ids : "" }
            });
        }

        private byte[] GetBytesAsPngFromImage(String imageFile)
        {
            MemoryStream ms = new MemoryStream();
            Image img = Image.FromFile(imageFile);
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            return ms.ToArray();
        }

        private void open1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if(openFileDialog.CheckFileExists)
                {
                    textBox1.Text = openFileDialog.FileName;
                }
            }
        }

        private void open2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.CheckFileExists)
                {
                    textBox2.Text = openFileDialog.FileName;
                }
            }
        }

        private void open3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.CheckFileExists)
                {
                    textBox3.Text = openFileDialog.FileName;
                }
            }
        }

        private void open4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.CheckFileExists)
                {
                    textBox4.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
