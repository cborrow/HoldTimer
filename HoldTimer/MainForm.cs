using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HoldTimer
{
    public partial class MainForm : Form
    {
        NewTimerDialog newTimerDialog;
        SettingsDialog settingsDialog;

        ThemeLoader themeLoader;

        static NotifyIcon notificationIcon;
        public static NotifyIcon NotificationIcon
        {
            get { return notificationIcon; }
        }

        public MainForm()
        {
            InitializeComponent();

            notificationIcon = notifyIcon1;
            newTimerDialog = new NewTimerDialog();
            settingsDialog = new SettingsDialog();
            themeLoader = new ThemeLoader();

            themeLoader.LoadThemes();

            foreach(Theme theme in themeLoader.LoadedThemes)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Click += ThemeMenuItem_Click;
                menuItem.Text = theme.Name;
                menuItem.Tag = theme;

                if (Properties.Settings.Default.SelectedTheme == theme.Name)
                    menuItem.Checked = true;

                themeDropDownMenuItem.DropDownItems.Add(menuItem);
            }

            panel1.ControlRemoved += Panel1_ControlRemoved;
            panel1.ClientSizeChanged += Panel1_ClientSizeChanged;

            Properties.Settings.Default.PropertyChanged += Default_PropertyChanged;
            BackColor = Properties.Settings.Default.AppBackColor;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            for(int i = 0; i < panel1.Controls.Count; i++)
            {
                if(panel1.Controls[i] is TimerControl timerControl)
                {
                    timerControl.StopTimer();
                }
            }
            System.Threading.Thread.Sleep(250);

            base.OnClosing(e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(newTimerDialog.ShowDialog() == DialogResult.OK)
            {
                TimerControl tc = new TimerControl();
                tc.Title = newTimerDialog.Title;
                tc.AlertTime = newTimerDialog.WarnTime;
                tc.Width = panel1.ClientSize.Width;
                tc.Location = new Point(0, (panel1.Controls.Count * (tc.Height + 5)));

                if (tc.Bottom > panel1.ClientSize.Height)
                    this.Height += tc.Height;

                panel1.Controls.Add(tc);
            }
        }

        private void Panel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            for(int i = 0; i < panel1.Controls.Count; i++)
            {
                panel1.Controls[i].Location = new Point(0, (i * (panel1.Controls[i].Height + 5)));
            }
        }

        private void Panel1_ClientSizeChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                panel1.Controls[i].Width = panel1.ClientSize.Width;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            SetForegroundWindow(Handle);
        }

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/cborrow/HoldTimer");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(settingsDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.AppBackColor = settingsDialog.AppBackColor;
                Properties.Settings.Default.TimerBackColor = settingsDialog.TimerBackColor;
                Properties.Settings.Default.TimerForeColor = settingsDialog.TimerForeColor;
                Properties.Settings.Default.TimeDefaultColor = settingsDialog.TimeDefaultColor;
                Properties.Settings.Default.AlertTimeColor = settingsDialog.AlertTimeColor;
                Properties.Settings.Default.OverTimeColor = settingsDialog.OverTimeColor;
                Properties.Settings.Default.OverTimeValue = settingsDialog.TimeOverValue;
                Properties.Settings.Default.AlertNotificationDisplayTime = settingsDialog.AlertNotificationDisplayTime;
                Properties.Settings.Default.Save();
            }
        }

        private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            BackColor = Properties.Settings.Default.AppBackColor;
        }

        private void ThemeMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selectedThemeMenuItem = (ToolStripMenuItem)sender;

            if(selectedThemeMenuItem != null)
            {
                for(int i = 0; i < themeDropDownMenuItem.DropDownItems.Count; i++)
                {
                    ((ToolStripMenuItem)themeDropDownMenuItem.DropDownItems[i]).Checked = false;
                }

                selectedThemeMenuItem.Checked = true;

                Theme theme = (Theme)selectedThemeMenuItem.Tag;
                Properties.Settings.Default.AppBackColor = theme.AppBackColor;
                Properties.Settings.Default.TimeDefaultColor = theme.TimeDefaultColor;
                Properties.Settings.Default.TimerBackColor = theme.TimerBackColor;
                Properties.Settings.Default.TimerForeColor = theme.TimerForeColor;
                Properties.Settings.Default.AlertTimeColor = theme.AlertTimeColor;
                Properties.Settings.Default.OverTimeColor = theme.OverTimeColor;
                Properties.Settings.Default.SelectedTheme = theme.Name;
                Properties.Settings.Default.Save();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            TimerControl tc = new TimerControl();
            tc.Title = "Quick Chat/Call Hold (3 Minutes) " + string.Format("{0:00}:{1:00}", (dt.Hour > 12) ? (dt.Hour - 12) : dt.Hour, dt.Minute);
            tc.AlertTime = TimeSpan.FromMinutes(3);
            tc.Width = panel1.ClientSize.Width;
            tc.Location = new Point(0, (panel1.Controls.Count * (tc.Height + 5)));

            if (tc.Bottom > panel1.ClientSize.Height)
                this.Height += tc.Height;

            panel1.Controls.Add(tc);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            TimerControl tc = new TimerControl();
            tc.Title = "Quick Chat/Call Hold (5 Minutes) " + string.Format("{0:00}:{1:00}", (dt.Hour > 12) ? (dt.Hour - 12) : dt.Hour, dt.Minute);
            tc.AlertTime = TimeSpan.FromMinutes(5);
            tc.Width = panel1.ClientSize.Width;
            tc.Location = new Point(0, (panel1.Controls.Count * (tc.Height + 5)));

            if (tc.Bottom > panel1.ClientSize.Height)
                this.Height += tc.Height;

            panel1.Controls.Add(tc);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            TimerControl tc = new TimerControl();
            tc.Title = "Quick Chat/Call Hold (7 Minutes) " + string.Format("{0:00}:{1:00}", (dt.Hour > 12) ? (dt.Hour - 12) : dt.Hour, dt.Minute);
            tc.AlertTime = TimeSpan.FromMinutes(7);
            tc.Width = panel1.ClientSize.Width;
            tc.Location = new Point(0, (panel1.Controls.Count * (tc.Height + 5)));

            if (tc.Bottom > panel1.ClientSize.Height)
                this.Height += tc.Height;

            panel1.Controls.Add(tc);
        }
    }
}
