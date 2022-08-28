using System.Windows;
using WpfTemplate.Lib;
using WpfTemplate.Views;

namespace WpfTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Hide();
            new BaseWindow<LoginModel>("Login", new LoginModel()).Show();
        }
    }
}
