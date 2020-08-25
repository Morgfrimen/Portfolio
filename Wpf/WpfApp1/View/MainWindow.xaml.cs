using System.Windows;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            App app = Application.Current as App;
            app.InitializeComponent();
        }
    }
}
