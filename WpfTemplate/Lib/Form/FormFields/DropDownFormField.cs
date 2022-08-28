using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfTemplate.Form.FormFields
{
    public class DropDownFormField<T> : FormField<ComboBox>
    {
        public Action<T> Callback { get; set; }
        public Dictionary<string, T> DropDownEntries { get; set; }
        public string SelectedEntryName { get; set; }
        public string Placeholder { get; set; }

        public DropDownFormField()
        {
            PrimaryUIElement = new ComboBox();
        }

        public override void RenderToGrid(Grid grid)
        {
            foreach (KeyValuePair<string, T> entry in DropDownEntries)
            {
                PrimaryUIElement.Items.Add(entry.Key);
            }
            PrimaryUIElement.SelectionChanged += PrimaryUIElement_SelectionChanged;
            PrimaryUIElement.Text = SelectedEntryName ?? Placeholder;
            PrimaryUIElement.IsReadOnly = true;
            PrimaryUIElement.IsEditable = true;
            PrimaryUIElement.SetValue(Grid.RowSpanProperty, 1);
            grid.Children.Add(PrimaryUIElement);
        }

        private void PrimaryUIElement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = PrimaryUIElement.SelectedIndex;
            if (selectedIndex == -1) return;
            Callback.Invoke(DropDownEntries[DropDownEntries.Keys.ToList()[selectedIndex]]);
            PrimaryUIElement.IsEditable = false;
        }

        public void AddEntry(string key, T value)
        {
            DropDownEntries.Add(key, value);
            PrimaryUIElement.Items.Add(key);
        }

        public void RemoveEntry(string item)
        {
            PrimaryUIElement.Items.Clear();
            foreach (KeyValuePair<String, T> entry in DropDownEntries)
            {
                if (entry.Key == item) continue;
                PrimaryUIElement.Items.Add(entry.Value);
            }
        }
    }
}
