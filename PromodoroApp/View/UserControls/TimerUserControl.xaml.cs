using System;
using System.Windows;
using System.Windows.Controls;
using PromodoroApp.Classes;

namespace PromodoroApp.View.UserControls;

public partial class TimerUserControl : UserControl
{
    public event EventHandler TimeExpired;

    private Timer _timer;
    private int[] _timeIntervals;
    private int _currentIndex;
    
    public TimerUserControl()
    {
        InitializeComponent();

        _timer = new Timer(10);
        _timer.Expired += Timer_Expired;
        _timer.Ticked += Timer_Ticked;
        
        _timeIntervals = new int[]{ 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60 };
        _currentIndex = 0;
        
        UpdateTimerText(_timeIntervals[_currentIndex], 0);
    }
    
    ~TimerUserControl()
    {
        _timer.Expired -= Timer_Expired;
        _timer.Ticked -= Timer_Ticked;
    }

    private void Timer_Ticked(object? sender, TimeSpan time)
    {
        UpdateTimerText((int)time.TotalMinutes, time.Seconds);
    }

    private void Timer_Expired(object? sender, EventArgs e)
    {
        TimeExpired?.Invoke(this, e);
    }

    private void BtnLess_OnClick(object sender, RoutedEventArgs e)
    {
        _currentIndex--;
        if (_currentIndex < 0)
            _currentIndex = _timeIntervals.Length - 1;
        
        UpdateTimerText(_timeIntervals[_currentIndex], 0);
    }

    private void BtnMore_OnClick(object sender, RoutedEventArgs e)
    {
        _currentIndex++;
        if (_currentIndex > _timeIntervals.Length - 1)
            _currentIndex = 0;
        
        UpdateTimerText(_timeIntervals[_currentIndex], 0);
    }

    private void UpdateTimerText(int minutes, int seconds)
    {
        tbTimer.Text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}