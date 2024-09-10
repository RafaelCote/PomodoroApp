using System;
using System.Windows.Controls;
using PromodoroApp.Classes;

namespace PromodoroApp.View.UserControls;

public partial class TimerUserControl : UserControl
{
    public event EventHandler TimeExpired;

    private Timer _timer = null;
    
    public TimerUserControl()
    {
        InitializeComponent();

        _timer = new Timer(10);
        _timer.Expired += Timer_Expired;
        _timer.Ticked += Timer_Ticked;
        
        var startingTime = _timer.StartTimer();
        tbTimer.Text = string.Format("{0:00}:{1:00}", (int)startingTime.TotalMinutes, startingTime.Seconds);
    }
    
    ~TimerUserControl()
    {
        _timer.Expired -= Timer_Expired;
        _timer.Ticked -= Timer_Ticked;
    }

    private void Timer_Ticked(object? sender, TimeSpan time)
    {
        tbTimer.Text = string.Format("{0:00}:{1:00}", (int)time.TotalMinutes, time.Seconds);
    }

    private void Timer_Expired(object? sender, EventArgs e)
    {
        TimeExpired?.Invoke(this, e);
    }
}