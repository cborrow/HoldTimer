using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace HoldTimer
{
    public partial class TimerControl : UserControl
    {
        protected delegate void UpdateTimerDisplayDelegate(TimeSpan time);
        protected delegate void ShowNotificationDelegate();

        Thread timerThread;

        List<TimeSpan> pastTimes = new List<TimeSpan>();
        TimeSpan elapsedTime = new TimeSpan();

        TimeSpan alertTime;
        public TimeSpan AlertTime
        {
            get { return alertTime; }
            set { alertTime = value; }
        }

        bool running;
        public bool Running
        {
            get { return running; }
        }

        public string Title
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public TimerControl()
        {
            InitializeComponent();

            running = true;
            CreateTimerThread();
        }

        public void PauseTimer()
        {
            running = false;
            pauseTimerButton.Image = HoldTimer.Properties.Resources.Resume_Icon;
        }

        public void ResumeTimer()
        {
            running = true;
            pauseTimerButton.Image = HoldTimer.Properties.Resources.Pause_Icon;
            CreateTimerThread();
        }

        public void RestartTimer()
        {
            running = false;
            pastTimes.Add(elapsedTime);

            if (timerThread.IsAlive)
                timerThread.Abort();

            elapsedTime = TimeSpan.Zero;
            running = true;
            pauseTimerButton.Image = HoldTimer.Properties.Resources.Pause_Icon;
            CreateTimerThread();

            UpdatePastTimersDisplay();
        }

        public void StopTimer()
        {
            running = false;
            pauseTimerButton.Image = HoldTimer.Properties.Resources.Resume_Icon;
            pastTimes.Add(elapsedTime);

            if (timerThread.IsAlive)
                timerThread.Abort();
        }

        public void DeleteTimer()
        {
            running = false;

            if (timerThread.IsAlive)
                timerThread.Abort();

            Parent.Controls.Remove(this);
        }

        protected void CreateTimerThread()
        {
            timerThread = new Thread(new ThreadStart(delegate ()
            {
                while(running)
                {
                    long preTicks = DateTime.Now.Ticks;

                    if(elapsedTime == alertTime)
                    {
                        if (InvokeRequired)
                            Invoke(new ShowNotificationDelegate(ShowNotification));
                    }

                    if (InvokeRequired && running)
                    {
                        try
                        {
                            Invoke(new UpdateTimerDisplayDelegate(UpdateTimerDisplay), elapsedTime);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    long postTicks = DateTime.Now.Ticks;
                    long ms = 1000 - ((postTicks - preTicks) / 10000);

                    Thread.Sleep((int)ms);
                    elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
                }
            }));
            timerThread.Start();
        }

        protected void UpdatePastTimersDisplay()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach(TimeSpan ts in pastTimes)
            {
                sb.Append(ts.ToString() + " ");
            }

            label3.Text = sb.ToString();
        }

        protected void UpdateTimerDisplay(TimeSpan timeSpan)
        {
            if(label2 != null)
                label2.Text = timeSpan.ToString();
        }

        protected void ShowNotification()
        {
            MainForm.NotificationIcon.ShowBalloonTip(15, Title + " - Hold Timer", "A running timer has reached it's alert timeout", ToolTipIcon.Warning);
        }

        private void resetTimerButton_Click(object sender, EventArgs e)
        {
            RestartTimer();
        }

        private void pauseTimerButton_Click(object sender, EventArgs e)
        {
            if (running)
                PauseTimer();
            else
                ResumeTimer();
        }

        private void deleteTimerButton_Click(object sender, EventArgs e)
        {
            DeleteTimer();
        }
    }
}
