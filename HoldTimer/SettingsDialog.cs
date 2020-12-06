﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HoldTimer
{
    public partial class SettingsDialog : Form
    {
        public Color TimerBackColor
        {
            get { return button1.BackColor; }
            set { button1.BackColor = value; }
        }

        public Color TimerForeColor
        {
            get { return button2.BackColor; }
            set { button2.BackColor = value; }
        }

        public Color TimerAlertColor
        {
            get { return button3.BackColor; }
            set { button3.BackColor = value; }
        }

        public Color TimerOverColor
        {
            get { return button4.BackColor; }
            set { button4.BackColor = value; }
        }

        public Color AltTextForeColor
        {
            get { return button5.BackColor; }
            set { button5.BackColor = value; }
        }

        public TimeSpan TimeOverValue
        {
            get
            {
                int val = (int)numericUpDown1.Value;

                if (comboBox1.Text == "Hours")
                    return new TimeSpan(val, 0, 0);
                else if (comboBox1.Text == "Minutes")
                    return new TimeSpan(0, val, 0);
                else
                    return new TimeSpan(0, 0, val);
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

        public SettingsDialog()
        {
            InitializeComponent();
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
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                button1.BackColor = c;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                button2.BackColor = c;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                button3.BackColor = c;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                button4.BackColor = c;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
                button5.BackColor = c;
            }
        }
    }
}
