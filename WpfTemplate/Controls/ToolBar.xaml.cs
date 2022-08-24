using WpfTemplate.Controls.ControlModels.ToolBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTemplate.Controls
{

    public partial class ToolBar : UserControl
    {
        private List<ToolBarEntry> _Entries { get; set; }
        public List<ToolBarEntry> Entries { 
            get => _Entries;
            set
            {
                _Entries = value;
                foreach (ToolBarEntry entry in _Entries) {
                    Menu.Items.Add(GenerateMenuItemRecursive(entry));
                }
            }
        }

        private MenuItem GenerateMenuItemRecursive(ToolBarEntry entry)
        {
            void click(object sender, RoutedEventArgs e)
            {
                entry.Callback.Invoke();
            }
            MenuItem menuItem = new MenuItem { Header = entry.Text };
            menuItem.Click += click;
            foreach(ToolBarEntry childEntry in entry.Children)
            {
                menuItem.Items.Add(GenerateMenuItemRecursive(childEntry));
            }
            return menuItem;
        }

        public ToolBar()
        {
            InitializeComponent();
        }
    }
}
