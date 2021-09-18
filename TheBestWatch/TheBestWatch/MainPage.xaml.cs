using System;
using System.ComponentModel;
using System.Timers;
using Xamarin.Forms;

namespace TheBestWatch
{
    public partial class MainPage : ContentPage
    {
        private Timer _timer;

        public string Time { get; set; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            InitTimer();
        }

        private void InitTimer()
        {
            _timer = new Timer {Interval = 500};
            _timer.Elapsed += TimerOnElapsed;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            var dateTime = DateTime.Now;
            Time = dateTime.ToString("T");
            SecondLine.Rotation = dateTime.Second * 6 - 180;
            HourLine.Rotation = dateTime.Hour * 30 - 180;
            MinuteLine.Rotation = dateTime.Minute * 6 - 180;
            OnPropertyChanged(nameof(Time));
        }
    }
}
