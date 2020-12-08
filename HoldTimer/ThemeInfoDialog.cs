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
    public partial class ThemeInfoDialog : Form
    {
        public string ThemeName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string ThemeDescription
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public ThemeInfoDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("A theme name is required.", "Theme Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
