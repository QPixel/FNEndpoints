using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNEndpoints
{
    public partial class Settings : Form
    {
        Form1 mainForm;
        public Settings(Form1 form)
        {
            mainForm = form;

            InitializeComponent();

            textBox1.Text = Properties.Settings.Default.EpicEmail;
            textBox2.Text = Properties.Settings.Default.EpicPassword;
            LanguageComboBox.Text = Properties.Settings.Default.Language;
            textBox3.Text = Properties.Settings.Default.pakPath;


            color_background_panel.BackColor = Properties.Settings.Default.viewer_default_backcolor;
            color_default_font_panel.BackColor = Properties.Settings.Default.viewer_default_forecolor;
            color_braceLight_backcolor_panel.BackColor = Properties.Settings.Default.viewer_BraceLight_backcolor;
            color_braceLight_forecolor_panel.BackColor = Properties.Settings.Default.viewer_BraceLight_forecolor;
            color_cursor_panel.BackColor = Properties.Settings.Default.viewer_Cursor_Color;
            color_selection_panel.BackColor = Properties.Settings.Default.viewer_Selection_backcolor;
            color_linenumber_panel.BackColor = Properties.Settings.Default.viewer_linenumber_forecolor;
            color_propertyName_panel.BackColor = Properties.Settings.Default.viewer_Json_PropertyName_forecolor;
            color_string_panel.BackColor = Properties.Settings.Default.viewer_Json_String_forecolor;
            color_number_panel.BackColor = Properties.Settings.Default.viewer_Json_Number_forecolor;
            color_operator_panel.BackColor = Properties.Settings.Default.viewer_Json_Operator_forecolor;
            color_comments_panel.BackColor = Properties.Settings.Default.viewer_Json_Comment_forecolor;
            color_url_panel.BackColor = Properties.Settings.Default.viewer_Json_Uri_forecolor;
            color_boolean_panel.BackColor = Properties.Settings.Default.viewer_Json_Boolean_forecolor;
        }

        private void reset_color_button_Click(object sender, EventArgs e)
        {
            color_background_panel.BackColor = Color.FromArgb(46, 46, 46);
            color_default_font_panel.BackColor = Color.White;
            color_braceLight_backcolor_panel.BackColor = Color.Blue;
            color_braceLight_forecolor_panel.BackColor = Color.White;
            color_cursor_panel.BackColor = Color.White;
            color_selection_panel.BackColor = Color.FromArgb(170, 170, 170);
            color_linenumber_panel.BackColor = Color.FromArgb(183, 183, 183);
            color_propertyName_panel.BackColor = Color.Lime;
            color_string_panel.BackColor = Color.Green;
            color_number_panel.BackColor = Color.Red;
            color_operator_panel.BackColor = Color.Gray;
            color_comments_panel.BackColor = Color.FromArgb(64, 191, 87);
            color_url_panel.BackColor = Color.Green;
            color_boolean_panel.BackColor = Color.DarkOrange;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EpicEmail = textBox1.Text;
            Properties.Settings.Default.EpicPassword = textBox2.Text;
            Properties.Settings.Default.Language = LanguageComboBox.Text;
            Properties.Settings.Default.pakPath = textBox3.Text;


            Properties.Settings.Default.viewer_default_backcolor = color_background_panel.BackColor;
            Properties.Settings.Default.viewer_default_forecolor = color_default_font_panel.BackColor;
            Properties.Settings.Default.viewer_BraceLight_backcolor = color_braceLight_backcolor_panel.BackColor;
            Properties.Settings.Default.viewer_BraceLight_forecolor = color_braceLight_forecolor_panel.BackColor; 
            Properties.Settings.Default.viewer_Cursor_Color = color_cursor_panel.BackColor;
            Properties.Settings.Default.viewer_Selection_backcolor = color_selection_panel.BackColor;
            Properties.Settings.Default.viewer_linenumber_forecolor = color_linenumber_panel.BackColor;
            Properties.Settings.Default.viewer_Json_PropertyName_forecolor = color_propertyName_panel.BackColor;
            Properties.Settings.Default.viewer_Json_String_forecolor = color_string_panel.BackColor;
            Properties.Settings.Default.viewer_Json_Number_forecolor = color_number_panel.BackColor;
            Properties.Settings.Default.viewer_Json_Operator_forecolor = color_operator_panel.BackColor;
            Properties.Settings.Default.viewer_Json_Comment_forecolor = color_comments_panel.BackColor;
            Properties.Settings.Default.viewer_Json_Uri_forecolor = color_url_panel.BackColor;
            Properties.Settings.Default.viewer_Json_Boolean_forecolor = color_boolean_panel.BackColor;


            Properties.Settings.Default.Save();

            mainForm.updateSettings();

            MessageBox.Show("Restart the program for all changes to take effect");

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = textBox3.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox2.UseSystemPasswordChar = !this.checkBox1.Checked;
        }

        private void color_background_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_background_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_background_panel.BackColor = colorDialog.Color;
            }
        }

        private void color_default_font_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_default_font_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_default_font_panel.BackColor = colorDialog.Color;
            }
        }

        private void color_braceLight_backcolor_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_braceLight_backcolor_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_braceLight_backcolor_panel.BackColor = colorDialog.Color;
            }
        }

        private void color_braceLight_forecolor_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_braceLight_forecolor_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_braceLight_forecolor_panel.BackColor = colorDialog.Color;
            }
        }

        private void color_cursor_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_cursor_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_cursor_panel.BackColor = colorDialog.Color;
            }
        }

        private void color_selection_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_selection_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_selection_panel.BackColor = colorDialog.Color;
            }
            
        }

        private void color_linenumber_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_linenumber_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_linenumber_panel.BackColor = colorDialog.Color;
            }
            
        }

        private void color_propertyName_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_propertyName_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_propertyName_panel.BackColor = colorDialog.Color;
            }
        }

        private void color_string_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_string_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_string_panel.BackColor = colorDialog.Color;
            }
        }

        private void color_number_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_number_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_number_panel.BackColor = colorDialog.Color;
            }
        }

        private void color_operator_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_operator_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_operator_panel.BackColor = colorDialog.Color;
            }
        }

        private void color_comments_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_comments_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_comments_panel.BackColor = colorDialog.Color;
            }
        }

        private void color_url_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_url_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_url_panel.BackColor = colorDialog.Color;
            }
        }

        private void color_boolean_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = color_boolean_panel.BackColor;
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                color_boolean_panel.BackColor = colorDialog.Color;
            }
        }
    }
}
