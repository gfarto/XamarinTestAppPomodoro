using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class PomodoroPageViewModel : NotificationObject
    {
        private TimeSpan elapsed;
        private bool isRunning;
        private Timer timer;
        private bool isInBreak;

        private int pomodoroDuration;
        private int breakDuration;

        public PomodoroPageViewModel()
        {
            this.loadConfiguration();
            this.initializeTimer();
            this.StartOrPauseCommand = new Command(this.startOrPauseCommandExecute);
        }

        private void initializeTimer()
        {
            this.timer = new Timer();
            this.timer.Interval = 1000;
            this.timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Elapsed = this.Elapsed.Add(TimeSpan.FromSeconds(1));

            if (this.isRunning)
            {
                if (this.Elapsed.TotalSeconds == this.pomodoroDuration * 60)
                {
                    this.IsRunning = false;
                    this.IsInBreak = true;
                    this.Elapsed = TimeSpan.Zero;

                    this.savePomodoroRecordAsync();
                }
            }

            if (this.IsInBreak)
            {
                if (this.Elapsed.TotalSeconds == this.breakDuration * 60)
                {
                    this.isRunning = true;
                    this.IsInBreak = false;
                    this.Elapsed = TimeSpan.Zero;
                }
            }
        }

        private async void savePomodoroRecordAsync()
        {
            List<DateTime> history = null;

            if (Application.Current.Properties.ContainsKey(Literals.HISTORY))
            {
                var json = Application.Current.Properties[Literals.HISTORY].ToString();
                if (!string.IsNullOrWhiteSpace(json))
                    history = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DateTime>>(json);
            }

            if (history == null)
                history = new List<DateTime>();

            history.Add(DateTime.Now);

            Application.Current.Properties[Literals.HISTORY] = Newtonsoft.Json.JsonConvert.SerializeObject(history);
            await Application.Current.SavePropertiesAsync();
        }

        public TimeSpan Elapsed
        {
            get => this.elapsed;
            set
            {
                this.elapsed = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsRunning
        {
            get => this.isRunning;
            set
            {
                this.isRunning = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsInBreak
        {
            get => this.isInBreak;
            set
            {
                this.isInBreak = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand StartOrPauseCommand { get; set; }

        private void startTimer()
        {
            this.timer.Start();
            this.IsRunning = true;
        }

        private void stopTimer()
        {
            this.timer.Stop();
            this.IsRunning = false;
        }

        private void startOrPauseCommandExecute()
        {
            if (this.IsRunning)
                this.stopTimer();
            else
                this.startTimer();
        }

        private void loadConfiguration()
        {
            this.pomodoroDuration = 25;
            this.breakDuration = 5;

            if (Application.Current.Properties.ContainsKey(Literals.POMODORO_DURATION))
                this.pomodoroDuration = (int)Application.Current.Properties[Literals.POMODORO_DURATION];

            if (Application.Current.Properties.ContainsKey(Literals.BREAK_DURATION))
                this.breakDuration = (int)Application.Current.Properties[Literals.BREAK_DURATION];
        }
    }
}
