﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HoldTimer
{
    public partial class SettingsDialog : Form
    {
        ThemeInfoDialog themeInfoDialog;

        public Color TimerBackColor
        {
            get { return button1.BackColor; }
            set { button1.BackColor = value; }
        }

        public Color TimerForeColor
        {
            get { return button5.BackColor; }
            set { button5.BackColor = value; }
        }

        public Color TimeDefaultColor
        {
            get { return button2.BackColor; }
            set { button2.BackColor = value; }
        }

        public Color AlertTimeColor
        {
            get { return button3.BackColor; }
            set { button3.BackColor = value; }
        }

        public Color OverTimeColor
        {
            get { return button4.BackColor; }
            set { button4.BackColor = value; }
        } 

        public Color AppBackColor
        {
            get { return button8.BackColor; }
            set { button8.BackColor = value; }
        }

        public Color ToolbarForeColor
        {
            get { return button10.BackColor; }
            set { button10.BackColor = value; }
        }

        public Color ToolbarBackColor
        {
            get { return button9.BackColor; }
            set { button9.BackColor = value; }
        }

        public Color ButtonPressedColor
        {
            get { return button13.BackColor; }
            set { button13.BackColor = value; }
        }

        public Color ButtonBackColor
        {
            get { return button11.BackColor; }
            set { button11.BackColor = value; }
        }

        public Color ButtonHoverColor
        {
            get { return button12.BackColor; }
            set { button12.BackColor = value; }
        }

        public TimeSpan TimeOverValue
        {
            get
            {
                int val = (int)numericUpDown1.Value;

                if (comboBox1.Text == "Hours")
                    return TimeSpan.FromHours(val);
                else if (comboBox1.Text == "Minutes")
                    return TimeSpan.FromMinutes(val);
                else
                    return TimeSpan.FromSeconds(val);
            }
            set
            {
                if (value.Hours > 0)
                {
                    comboBox1.Text = "Hours";
                    numericUpDown1.Value = value.Hours;
                }
                else if (value.Minutes > 0)
                {
                    comboBox1.Text = "Minutes";
                    numericUpDown1.Value = value.Minutes;
                }
                else
                {
                    comboBox1.Text = "Seconds";
                    numericUpDown1.Value = value.Seconds;
                }
            }
        }

        public TimeSpan AlertNotificationDisplayTime
        {
            get
            {
                int val = (int)numericUpDown2.Value;

                if (comboBox2.Text == "Hours")
                    return TimeSpan.FromHours(val);
                else if (comboBox2.Text == "Minutes")
                    return TimeSpan.FromMinutes(val);
                else
                    return TimeSpan.FromSeconds(val);
            }
            set
            {
                if(value.Hours > 0)
                {
                    comboBox2.Text = "Hours";
                    numericUpDown2.Value = value.Hours;
                }
                else if(value.Minutes > 0)
                {
                    comboBox2.Text = "Minutes";
                    numericUpDown2.Value = value.Minutes;
                }
                else
                {
                    comboBox2.Text = "Seconds";
                    numericUpDown2.Value = value.Seconds;
                }
            }
        }

        public bool AlwaysOnTop
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }

        public string AlertAudioSource
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public SettingsDialog()
        {
            InitializeComponent();

            themeInfoDialog = new ThemeInfoDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            TimerBackColor = Properties.Settings.Default.TimerBackColor;
            TimeDefaultColor = Properties.Settings.Default.TimeDefaultColor;
            AlertTimeColor = Properties.Settings.Default.AlertTimeColor;
            OverTimeColor = Properties.Settings.Default.OverTimeColor;
            TimerForeColor = Properties.Settings.Default.TimerForeColor;
            AppBackColor = Properties.Settings.Default.AppBackColor;
            ToolbarBackColor = Properties.Settings.Default.ToolbarBackColor;
            ToolbarForeColor = Properties.Settings.Default.ToolbarForeColor;
            ButtonBackColor = Properties.Settings.Default.ButtonBackColor;
            ButtonHoverColor = Properties.Settings.Default.ButtonHoverColor;
            ButtonPressedColor = Properties.Settings.Default.ButtonPressedColor;
            AlwaysOnTop = Properties.Settings.Default.AlwaysOnTop;
            AlertAudioSource = Properties.Settings.Default.AlertAudioSource;

            base.OnLoad(e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TimerBackColor
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                TimerBackColor = c;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TimeDefaultColor
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                TimeDefaultColor = c;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //AlertTimeColor
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                AlertTimeColor= c;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //OverTimeColor
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                OverTimeColor = c;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //TimerForeColor
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                TimerForeColor = c;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //AppBackColor
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                AppBackColor = c;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(themeInfoDialog.ShowDialog() == DialogResult.OK)
            {
                string name = themeInfoDialog.ThemeName;
                string desc = themeInfoDialog.ThemeDescription;
                string fileName = BuildThemeFileName(name);
                string filePath = Path.Combine(ThemeLoader.Instance.ThemesDirPath, fileName);
                string themeXml = BuildThemeXML(name, desc);

                try
                {
                    if (!Directory.Exists(ThemeLoader.Instance.ThemesDirPath))
                        Directory.CreateDirectory(ThemeLoader.Instance.ThemesDirPath);

                    File.WriteAllText(filePath, themeXml);

                    if (File.Exists(filePath))
                    {
                        MessageBox.Show("Your theme file has succesfully been saved to\r\n " + filePath);
                        System.Diagnostics.Process.Start("explorer.exe", "/select,\"" + filePath + "\"");
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("There was an error attempting to save your theme to the Themes folder. It may not have permissions, or was unable to create Themes folder");

#if DEBUG
                    MessageBox.Show(ex.Message);
#endif
                }
            }
        }

        protected string BuildThemeXML(string name, string description)
        {
            StringBuilder themeXml = new StringBuilder();
            themeXml.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            themeXml.AppendLine(string.Format("<Theme Name=\"{0}\" Description=\"{1}\">", name, description));
            themeXml.AppendLine(string.Format("<Color Name=\"{0}\" Value=\"{1}\" />", "AppBackColor", ColorTranslator.ToHtml(AppBackColor)));
            themeXml.AppendLine(string.Format("<Color Name=\"{0}\" Value=\"{1}\" />", "TimerBackColor", ColorTranslator.ToHtml(TimerBackColor)));
            themeXml.AppendLine(string.Format("<Color Name=\"{0}\" Value=\"{1}\" />", "TimeForeColor", ColorTranslator.ToHtml(TimerForeColor)));
            themeXml.AppendLine(string.Format("<Color Name=\"{0}\" Value=\"{1}\" />", "TimeDefaultColor", ColorTranslator.ToHtml(TimeDefaultColor)));
            themeXml.AppendLine(string.Format("<Color Name=\"{0}\" Value=\"{1}\" />", "AlertTimeColor", ColorTranslator.ToHtml(AlertTimeColor)));
            themeXml.AppendLine(string.Format("<Color Name=\"{0}\" Value=\"{1}\" />", "OverTimeColor", ColorTranslator.ToHtml(OverTimeColor)));
            themeXml.AppendLine(string.Format("<Color Name=\"{0}\" Value=\"{1}\" />", "ToolbarForeColor", ColorTranslator.ToHtml(ToolbarForeColor)));
            themeXml.AppendLine(string.Format("<Color Name=\"{0}\" Value=\"{1}\" />", "ToolbarBackColor", ColorTranslator.ToHtml(ToolbarBackColor)));
            themeXml.AppendLine(string.Format("<Color Name=\"{0}\" Value=\"{1}\" />", "ButtonBackColor", ColorTranslator.ToHtml(ButtonBackColor)));
            themeXml.AppendLine(string.Format("<Color Name=\"{0}\" Value=\"{1}\" />", "ButtonHoverColor", ColorTranslator.ToHtml(ButtonHoverColor)));
            themeXml.AppendLine(string.Format("<Color Name=\"{0}\" Value=\"{1}\" />", "ButtonPressedColor", ColorTranslator.ToHtml(ButtonPressedColor)));
            themeXml.AppendLine("</Theme>");

            return themeXml.ToString();
        }

        protected string BuildThemeFileName(string name)
        {
            string fileName = string.Empty;

            foreach(char c in name)
            {
                if (char.IsLetterOrDigit(c))
                    fileName += c.ToString();
                else if (char.IsWhiteSpace(c))
                    fileName += "_";
            }

            fileName += ".xml";

            return fileName;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "WAV Files (*.wav)|*.wav";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                if (Path.GetExtension(path).ToLower() != ".wav")
                    MessageBox.Show("The alert sound can only be a .wav file.");
                else
                {
                    AlertAudioSource = path;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //ButtonPressedColor
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                ButtonPressedColor = c;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //ButtonBackColor
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                ButtonBackColor = c;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //ButtonHoverColor
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                ButtonHoverColor = c;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //ToolbarBackColor
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                ToolbarBackColor = c;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //ToolbarForeColor
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                ToolbarForeColor = c;
            }
        }
    }
}
