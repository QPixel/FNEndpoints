namespace FNEndpoints.AdminTab
{
    partial class AdminTab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.button_ok = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.access_token_secret = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.access_token_key = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.consumer_secret = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.consumer_key = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sendTweetPage = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.status_textbox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.open1 = new System.Windows.Forms.Button();
            this.open2 = new System.Windows.Forms.Button();
            this.open3 = new System.Windows.Forms.Button();
            this.open4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.sendTweetPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.settingsPage);
            this.tabControl1.Controls.Add(this.sendTweetPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 383);
            this.tabControl1.TabIndex = 0;
            // 
            // settingsPage
            // 
            this.settingsPage.Controls.Add(this.button_ok);
            this.settingsPage.Controls.Add(this.groupBox2);
            this.settingsPage.Location = new System.Drawing.Point(4, 22);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Size = new System.Drawing.Size(792, 357);
            this.settingsPage.TabIndex = 1;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(703, 141);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.access_token_secret);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.access_token_key);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.consumer_secret);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.consumer_key);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(8, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 132);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Twitter - Keys";
            // 
            // access_token_secret
            // 
            this.access_token_secret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.access_token_secret.Location = new System.Drawing.Point(124, 97);
            this.access_token_secret.Name = "access_token_secret";
            this.access_token_secret.Size = new System.Drawing.Size(646, 20);
            this.access_token_secret.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Access Token Secret: ";
            // 
            // access_token_key
            // 
            this.access_token_key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.access_token_key.Location = new System.Drawing.Point(111, 71);
            this.access_token_key.Name = "access_token_key";
            this.access_token_key.Size = new System.Drawing.Size(659, 20);
            this.access_token_key.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Access Token Key: ";
            // 
            // consumer_secret
            // 
            this.consumer_secret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consumer_secret.Location = new System.Drawing.Point(102, 45);
            this.consumer_secret.Name = "consumer_secret";
            this.consumer_secret.Size = new System.Drawing.Size(668, 20);
            this.consumer_secret.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Consumer Secret: ";
            // 
            // consumer_key
            // 
            this.consumer_key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consumer_key.Location = new System.Drawing.Point(89, 19);
            this.consumer_key.Name = "consumer_key";
            this.consumer_key.Size = new System.Drawing.Size(681, 20);
            this.consumer_key.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Consumer Key: ";
            // 
            // sendTweetPage
            // 
            this.sendTweetPage.Controls.Add(this.button1);
            this.sendTweetPage.Controls.Add(this.status_textbox);
            this.sendTweetPage.Controls.Add(this.label1);
            this.sendTweetPage.Controls.Add(this.groupBox1);
            this.sendTweetPage.Location = new System.Drawing.Point(4, 22);
            this.sendTweetPage.Name = "sendTweetPage";
            this.sendTweetPage.Padding = new System.Windows.Forms.Padding(3);
            this.sendTweetPage.Size = new System.Drawing.Size(792, 357);
            this.sendTweetPage.TabIndex = 0;
            this.sendTweetPage.Text = "sendTweet";
            this.sendTweetPage.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(705, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // status_textbox
            // 
            this.status_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.status_textbox.Location = new System.Drawing.Point(49, 6);
            this.status_textbox.Name = "status_textbox";
            this.status_textbox.Size = new System.Drawing.Size(737, 70);
            this.status_textbox.TabIndex = 3;
            this.status_textbox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Text: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.open4);
            this.groupBox1.Controls.Add(this.open3);
            this.groupBox1.Controls.Add(this.open2);
            this.groupBox1.Controls.Add(this.open1);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 123);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Images";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(188, 91);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(536, 20);
            this.textBox4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Image 4 (leave blank for no image): ";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(188, 65);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(536, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Image 3 (leave blank for no image): ";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(188, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(536, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Image 2 (leave blank for no image): ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(188, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(536, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Image 1 (leave blank for no image): ";
            // 
            // open1
            // 
            this.open1.Location = new System.Drawing.Point(730, 11);
            this.open1.Name = "open1";
            this.open1.Size = new System.Drawing.Size(44, 23);
            this.open1.TabIndex = 8;
            this.open1.Text = ">>";
            this.open1.UseVisualStyleBackColor = true;
            this.open1.Click += new System.EventHandler(this.open1_Click);
            // 
            // open2
            // 
            this.open2.Location = new System.Drawing.Point(730, 37);
            this.open2.Name = "open2";
            this.open2.Size = new System.Drawing.Size(44, 23);
            this.open2.TabIndex = 9;
            this.open2.Text = ">>";
            this.open2.UseVisualStyleBackColor = true;
            this.open2.Click += new System.EventHandler(this.open2_Click);
            // 
            // open3
            // 
            this.open3.Location = new System.Drawing.Point(730, 63);
            this.open3.Name = "open3";
            this.open3.Size = new System.Drawing.Size(44, 23);
            this.open3.TabIndex = 10;
            this.open3.Text = ">>";
            this.open3.UseVisualStyleBackColor = true;
            this.open3.Click += new System.EventHandler(this.open3_Click);
            // 
            // open4
            // 
            this.open4.Location = new System.Drawing.Point(730, 89);
            this.open4.Name = "open4";
            this.open4.Size = new System.Drawing.Size(44, 23);
            this.open4.TabIndex = 11;
            this.open4.Text = ">>";
            this.open4.UseVisualStyleBackColor = true;
            this.open4.Click += new System.EventHandler(this.open4_Click);
            // 
            // AdminTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 383);
            this.Controls.Add(this.tabControl1);
            this.Name = "AdminTab";
            this.Text = "AdminTab";
            this.Load += new System.EventHandler(this.AdminTab_Load);
            this.tabControl1.ResumeLayout(false);
            this.settingsPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.sendTweetPage.ResumeLayout(false);
            this.sendTweetPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage sendTweetPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox status_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage settingsPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox access_token_secret;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox access_token_key;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox consumer_secret;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox consumer_key;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button open4;
        private System.Windows.Forms.Button open3;
        private System.Windows.Forms.Button open2;
        private System.Windows.Forms.Button open1;
    }
}