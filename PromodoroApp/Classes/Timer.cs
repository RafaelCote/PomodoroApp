using System;
using System.Windows.Threading;

namespace PromodoroApp.Classes;
public class Timer
{
    public event EventHandler Expired;
    public event EventHandler<TimeSpan> Ticked;

    private DispatcherTimer _timer = null;
    private TimeSpan _time = default;

    public Timer()
    {
        _timer = new DispatcherTimer();
        _timer.Tick += Timer_Tick;
        _timer.Interval = TimeSpan.FromSeconds(1);
    }

    ~Timer()
    {
        _timer.Tick -= Timer_Tick;
    }

    public TimeSpan StartTimer()
    {
        _timer.Start();
        return _time;
    }

    public void Stop()
    {
        _timer.Stop();
        SetTime(0);
        Expired?.Invoke(this, EventArgs.Empty);
    }

    public void SetTime(double minutes)
    {
        _time = TimeSpan.FromMinutes(minutes);
    }
    
    private void Timer_Tick(object? sender, EventArgs args)
    {
        _time = _time.Subtract(TimeSpan.FromSeconds(1));
        if (_time == TimeSpan.Zero)
        {
            _timer.Stop();
            Expired?.Invoke(this, EventArgs.Empty);
        }
        Ticked?.Invoke(this, _time);
    }
}