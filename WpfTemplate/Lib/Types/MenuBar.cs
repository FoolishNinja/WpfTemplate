using SwissSkillsTemplate;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
