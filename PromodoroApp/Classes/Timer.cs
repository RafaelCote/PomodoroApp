using System;
using System.Windows.Threading;

namespace PromodoroApp.Classes;
public class Timer
{
    public event EventHandler Expired;
    public event EventHandler<TimeSpan> Ticked;

    private DispatcherTimer _timer = null;
    private TimeSpan _time = default;

    public Timer(double duration)
    {
        _time = TimeSpan.FromSeconds(duration);
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
    
    private void Timer_Tick(object? sender, EventArgs args)
    {
        _time = _time.Subtract(TimeSpan.FromSeconds(1));
        if (_time == TimeSpan.Zero)
            _timer.Stop();
        Ticked?.Invoke(this, _time);
    }
}