using System;
using System.Windows;

namespace PromodoroApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //ucTimer.TimeExpired += Timer_TimeExpired;
        }

        ~MainWindow()
        {
            //ucTimer.TimeExpired -= Timer_TimeExpired;
        }

        private void Timer_TimeExpired(object? sender, EventArgs e)
        {
            lblTimeUp.Visibility = Visibility.Visible;
        }
    }
}