
using System.Windows;
using WpfTemplate.CarloLib;
using WpfTemplate.Models;

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
            BaseWindow<TestModel> b = new BaseWindow<TestModel> { Model = new TestModel(), GridSize = GridSize.MEDIUM, Name = "TestWindow", Title = "Test" };
            b.Initialize();
            b.Show();
        }
    }
}
