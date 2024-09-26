using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PromodoroApp.View.UserControls
{
    /// <summary>
    /// Logique d'interaction pour RoundedButton.xaml
    /// </summary>
    public partial class RoundedButton : UserControl
    {
        public ImageSource Image
        { 
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(RoundedButton), new UIPropertyMetadata(null));

        public int Radius
        {
            get { return (int)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }
        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(int), typeof(RoundedButton), new UIPropertyMetadata(null));

        public event RoutedEventHandler Click;

        public RoundedButton()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }
    }
}
