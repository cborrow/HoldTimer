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
        protected delegate void SetTimerColorDelegate(Color color);

        Thread timerThread;

        List<TimeSpan> pastTimes = new List<TimeSpan>();
        TimeSpan elapsedTime = new TimeSpan();

        TimeSpan alertTime;
        public TimeSpan AlertTime
        {
            get { return alertTime; }
            set { alertTime = value; }
        }

        TimeSpan overTimeValue;
        TimeSpan alertDisplayTime;

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

        public Color DefaultTimeColor { get; internal set; }
        public Color AlertTimeColor { get; set; }
        public Color OverTimeColor { get; set; }

        public TimerControl()
        {
            InitializeComponent();

            running = true;
            CreateTimerThread();

            DefaultTimeColor = label2.ForeColor;
            AlertTimeColor = Color.Yellow;
            OverTimeColor = Color.Red;

            LoadSettings();
            Properties.Settings.Default.PropertyChanged += Default_PropertyChanged;
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
            SetTimerColor(DefaultTimeColor);
            CreateTimerThread();

            UpdatePastTimersDisplay();
        }

        public void StopTimer()
        {
            running = false;
            elapsedTime = TimeSpan.Zero;
            pauseTimerButton.Image = HoldTimer.Properties.Resources.Resume_Icon;
            pastTimes.Add(elapsedTime);
            SetTimerColor(DefaultTimeColor);

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
                        {
                            Invoke(new ShowNotificationDelegate(ShowNotification));
                            Invoke(new SetTimerColorDelegate(SetTimerColor), AlertTimeColor);
                        }
                    }
                    else if(elapsedTime > alertTime.Add(overTimeValue))
                    {
                        if (InvokeRequired)
                            Invoke(new SetTimerColorDelegate(SetTimerColor), OverTimeColor);
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

        protected void SetTimerColor(Color color)
        {
            label2.ForeColor = color;
        }

        protected void ShowNotification()
        {
            int seconds = 0;

            if (alertDisplayTime.Hours > 0)
                seconds += (int)(alertDisplayTime.TotalHours * 3600);
            if (alertDisplayTime.Minutes > 0)
                seconds += (int)(alertDisplayTime.TotalMinutes * 60);
            if (alertDisplayTime.Seconds > 0)
                seconds += alertDisplayTime.Seconds;

            MainForm.NotificationIcon.ShowBalloonTip(seconds, Title + " - Hold Timer", "A running timer has reached it's alert timeout", ToolTipIcon.Warning);
        }

        protected void LoadSettings()
        {
            BackColor = Properties.Settings.Default.TimerBackColor;
            ForeColor = Properties.Settings.Default.TimerForeColor;

            DefaultTimeColor = Properties.Settings.Default.TimeDefaultColor;
            AlertTimeColor = Properties.Settings.Default.AlertTimeColor;
            OverTimeColor = Properties.Settings.Default.OverTimeColor;

            overTimeValue = Properties.Settings.Default.OverTimeValue;
            alertDisplayTime = Properties.Settings.Default.AlertNotificationDisplayTime;

            if (elapsedTime > alertTime)
            {
                if (elapsedTime >= (alertTime.Add(overTimeValue)))
                    label2.ForeColor = OverTimeColor;
                else
                    label2.ForeColor = AlertTimeColor;
            }
            else
                label2.ForeColor = DefaultTimeColor;
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

        private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            LoadSettings();
        }
    }
}
