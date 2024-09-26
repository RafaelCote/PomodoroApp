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

        _timeIntervals = new int[]{ 1, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60 };
        _currentIndex = 0;
        
        _timer = new Timer();
        _timer.Expired += Timer_Expired;
        _timer.Ticked += Timer_Ticked;
        
        UpdateTimer();
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
        _btnLess.Visibility = Visibility.Visible;
        _btnMore.Visibility = Visibility.Visible;
        _btnStart.Visibility = Visibility.Visible;
        _btnStop.Visibility = Visibility.Hidden; 
        
        UpdateTimer();
        
        TimeExpired?.Invoke(this, e);
    }

    private void BtnLess_OnClick(object sender, RoutedEventArgs e)
    {
        _currentIndex--;
        if (_currentIndex < 0)
            _currentIndex = _timeIntervals.Length - 1;

        UpdateTimer();
    }

    private void BtnMore_OnClick(object sender, RoutedEventArgs e)
    {
        _currentIndex++;
        if (_currentIndex > _timeIntervals.Length - 1)
            _currentIndex = 0;
        
        UpdateTimer();
    }

    private void BtnStart_OnClick(object sender, RoutedEventArgs e)
    {
        var time = _timer.StartTimer();
        _btnLess.Visibility = Visibility.Hidden;
        _btnMore.Visibility = Visibility.Hidden;
        _btnStart.Visibility = Visibility.Hidden;
        _btnStop.Visibility = Visibility.Visible;
    }

    private void BtnStop_OnClick(object sender, RoutedEventArgs e)
    {
        _timer.Stop();
    }

    private void UpdateTimer()
    {
        _timer.SetTime(_timeIntervals[_currentIndex]);
        UpdateTimerText(_timeIntervals[_currentIndex], 0);
    }
    
    private void UpdateTimerText(int minutes, int seconds)
    {
        _tbTimer.Text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}