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

            panel1.ControlRemoved += Panel1_ControlRemoved;
            panel1.ClientSizeChanged += Panel1_ClientSizeChanged;
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
    }
}
