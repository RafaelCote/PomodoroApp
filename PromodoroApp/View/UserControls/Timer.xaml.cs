using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PromodoroApp.View.UserControls;

public partial class Timer : UserControl
{
    private DispatcherTimer _timer = null;
    private TimeSpan _time = default;
    
    public Timer()
    {
        InitializeComponent();

        _time = TimeSpan.FromSeconds(10);

        _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, (sender, args) =>
        {
            tbTimer.Text = string.Format("{0:00}:{1:00}", (int)_time.TotalMinutes, _time.Seconds);
            if (_time == TimeSpan.Zero)
                _timer.Stop();
            _time = _time.Add(TimeSpan.FromSeconds(-1));

        }, Application.Current.Dispatcher);
    }
}