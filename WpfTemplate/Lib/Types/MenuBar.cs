using SwissSkillsTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfTemplate.Form;

namespace WpfTemplate.Types
{
    public class MenuBar
    {
        public List<MenuBarEntry> ToolBarEntries { get; set; }

        public void RenderToGrid(Grid grid)
        {
            Menu menu = new Menu();
            foreach(MenuBarEntry entry in ToolBarEntries)
            {
                menu.Items.Add(GenerateMenuItemRecursive(entry));
            }
            menu.Background = Utils.GetColorBrushFromHex("#ffffff");
            menu.SetValue(Grid.ColumnSpanProperty, FormStyling.COLUMNS);
            grid.Children.Add(menu);
        }

        private MenuItem GenerateMenuItemRecursive(MenuBarEntry entry)
        {
            void click(object sender, RoutedEventArgs e)
            {
                entry.Callback.Invoke();
            }
            MenuItem menuItem = new MenuItem { Header = entry.Text };
            menuItem.Click += click;
            foreach (MenuBarEntry childEntry in entry.Children)
            {
                menuItem.Items.Add(GenerateMenuItemRecursive(childEntry));
            }
            return menuItem;
        }
    }
}
