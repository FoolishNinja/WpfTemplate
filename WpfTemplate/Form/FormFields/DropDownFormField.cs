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
        public string Label { get; set; }
        public Action<T> Callback { get; set; }
        public Dictionary<string, T> DropDownEntries { get; set; }
        public string SelectedEntryName { get; set; }
        public string Placeholder { get; set; }

        public DropDownFormField()
        {
            Rowspan = 2;
            PrimaryUIElement = new ComboBox();
        }

        public override void RenderToGrid(Grid grid, int currentRow, int currentCol)
        {
            Label label = new Label();
            label.Content = Label;
            label.FontSize = FormStyling.FONT_SIZE;
            label.SetValue(Grid.RowProperty, currentRow);
            label.SetValue(Grid.ColumnProperty, currentCol);
            label.SetValue(Grid.ColumnSpanProperty, FormStyling.COLUMNS);
            grid.Children.Add(label);
            Row = currentRow + 1;
            Col = currentCol;
            foreach(KeyValuePair<string, T> entry in DropDownEntries)
            {
                PrimaryUIElement.Items.Add(entry.Key);
            }
            PrimaryUIElement.SelectionChanged += PrimaryUIElement_SelectionChanged;
            PrimaryUIElement.Text = SelectedEntryName ?? Placeholder;
            PrimaryUIElement.IsReadOnly = true;
            PrimaryUIElement.IsEditable = true;
            PrimaryUIElement.SetValue(Grid.RowSpanProperty, 1);
            grid.Children.Add(PrimaryUIElement);
            base.RenderToGrid(grid, currentRow, currentCol);
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
            foreach(KeyValuePair<String, T> entry in DropDownEntries)
            {
                if (entry.Key == item) continue;
                PrimaryUIElement.Items.Add(entry.Value);
            }
        }
    }
}
