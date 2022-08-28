using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace WpfTemplate.Form.FormFields
{
    public class ListBoxFormField<T> : FormField<ListBox>
    {
        private Label LabelItem;
        private string _Label { get; set; }
        public string Label
        {
            get => _Label;
            set
            {
                _Label = value;
                if (LabelItem != null)
                    LabelItem.Content = value;
            }
        }
        public Dictionary<string, T> Entries { get; set; }
        public Action<T> Callback { get; set; }

        public ListBoxFormField()
        {
            Colspan = 12;
            Rowspan = 5;
            PrimaryUIElement = new ListBox();
        }

        public override void RenderToGrid(Grid grid, int currentRow, int currentCol)
        {
            LabelItem = new Label();
            LabelItem.Content = Label;
            LabelItem.FontSize = FormStyling.FONT_SIZE;
            LabelItem.SetValue(Grid.RowProperty, currentRow);
            LabelItem.SetValue(Grid.ColumnProperty, currentCol);
            LabelItem.SetValue(Grid.ColumnSpanProperty, FormStyling.COLUMNS);
            grid.Children.Add(LabelItem);
            Row = currentRow + 1;
            Col = currentCol;
            foreach (KeyValuePair<string, T> entry in Entries)
            {
                PrimaryUIElement.Items.Add(entry.Key);
            }
            PrimaryUIElement.SelectionChanged += PrimaryUIElement_SelectionChanged;
            PrimaryUIElement.SetValue(Grid.RowSpanProperty, Rowspan - 1);
            grid.Children.Add(PrimaryUIElement);
            base.RenderToGrid(grid, currentRow, currentCol);
        }

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
