using System;
using System.Windows.Controls;

namespace PromodoroApp.View.UserControls;

public partial class Timer : UserControl
{
    public Timer()
    {
        InitializeComponent();
        
        tbTimer.Text = DateTime.Now.ToString("HH:mm");
    }
}