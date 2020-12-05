using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HoldTimer
{
    public partial class NewTimerDialog : Form
    {
        public string Title
        {
            get { return textBox1.Text; }
        }

        public TimeSpan WarnTime
        {
            get
            {
                if (comboBox1.Text.ToLower() == "hours")
                    return new TimeSpan((int)numericUpDown1.Value, 0, 0);
                else if (comboBox1.Text.ToLower() == "minutes")
                    return new TimeSpan(0, (int)numericUpDown1.Value, 0);
                else
                    return new TimeSpan(0, 0, (int)numericUpDown1.Value);
            }
        }

        public NewTimerDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            numericUpDown1.Value = 3;
            comboBox1.Text = "Minutes";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            numericUpDown1.Value = 5;
            comboBox1.Text = "Minutes";
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            numericUpDown1.Value = 7;
            comboBox1.Text = "Minutes";
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            numericUpDown1.Value = 10;
            comboBox1.Text = "Minutes";
        }
    }
}
