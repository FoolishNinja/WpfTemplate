using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace WpfTemplate.Form.FormFields
{
    public class ListBoxFormField<T> : FormField<ListBox>
    {
        public Dictionary<string, T> Entries { get; set; }
        public Action<T> Callback { get; set; }

        public ListBoxFormField()
        {
            PrimaryUIElement = new ListBox();
        }

        public override void RenderToGrid(Grid grid)
        {
            foreach (KeyValuePair<string, T> entry in Entries)
            {
                PrimaryUIElement.Items.Add(entry.Key);
            }
            PrimaryUIElement.SelectionChanged += PrimaryUIElement_SelectionChanged;
            PrimaryUIElement.SetValue(Grid.RowSpanProperty, Rowspan - 1);
            grid.Children.Add(PrimaryUIElement);        }

        private void PrimaryUIElement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = PrimaryUIElement.SelectedIndex;
            if (selectedIndex == -1) return;
            Callback.Invoke(Entries[Entries.Keys.ToList()[selectedIndex]]);
        }

        public void AddEntry(string label, T value)
        {
            Entries.TryAdd(label, value);
            PrimaryUIElement.Items.Add(label);
        }

        public void RemoveEntry(string label)
        {
            Entries.Remove(label);
            PrimaryUIElement.Items.Remove(label);
        }
    }
}
