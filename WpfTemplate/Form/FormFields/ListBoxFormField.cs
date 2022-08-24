using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace WpfTemplate.Form.FormFields
{
    public class ListBoxFormField<T> : FormField<ListBox>
    {
        public string Label { get; set; }
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
            Label label = new Label();
            label.Content = Label;
            label.FontSize = FormStyling.FONT_SIZE;
            label.SetValue(Grid.RowProperty, currentRow);
            label.SetValue(Grid.ColumnProperty, currentCol);
            label.SetValue(Grid.ColumnSpanProperty, FormStyling.COLUMNS);
            grid.Children.Add(label);
            Row = currentRow + 1;
            Col = currentCol;
            foreach(KeyValuePair<string, T> entry in Entries)
            {
                PrimaryUIElement.Items.Add(entry.Key);
            }
            PrimaryUIElement.SelectionChanged += PrimaryUIElement_SelectionChanged;
            grid.Children.Add(PrimaryUIElement);
            base.RenderToGrid(grid, currentRow, currentCol);
        }

        private void PrimaryUIElement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = (sender as ListBox).SelectedIndex;
            if (selectedIndex == -1) return;
            Callback.Invoke(Entries[Entries.Keys.ToList()[selectedIndex]]);
        }
    }
}
