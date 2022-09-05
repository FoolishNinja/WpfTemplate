using System.Windows;
using WpfTemplate.CarloLib;
using WpfTemplate.Models;

namespace WpfTemplate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            BaseWindow<TestModel> b = new BaseWindow<TestModel> { Model = new TestModel(), GridSize = GridSize.LARGE, Name = "TestWindow", Title = "Test" };
            b.Initialize();
            b.Show();
        }
    }
}
