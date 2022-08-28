using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using WpfTemplate.Types;

namespace WpfTemplate.Form.FormFields
{
    public class TableFormField<T> : FormField<DataGrid>
    {
        public string Label { get; set; }
        public Action<T> Callback { get; set; }
        public List<TableHeader> Headers { get; set; }
        public List<T> Entries { get; set; }

        public TableFormField()
        {
            Rowspan = 10;
            PrimaryUIElement = new DataGrid();
        }

        public override void RenderToGrid(Grid grid, int currentRow, int currentCol)
        {
            Label label = new Label();
            label.SetValue(Grid.RowProperty, currentRow);
            label.SetValue(Grid.ColumnProperty, currentCol);
            label.SetValue(Grid.ColumnSpanProperty, FormStyling.COLUMNS);
            label.FontSize = FormStyling.FONT_SIZE;
            label.Content = Label;
            grid.Children.Add(label);
            Col = currentCol;
            Row = currentRow + 1;
            foreach (TableHeader header in Headers)
            {
                DataGridTextColumn dataGridTextColumn = new DataGridTextColumn();
                dataGridTextColumn.Header = header.Label;
                dataGridTextColumn.Binding = new Binding(header.PropertyName);
                dataGridTextColumn.Width = new DataGridLength(header.WidthRatio, DataGridLengthUnitType.Star);
                PrimaryUIElement.Columns.Add(dataGridTextColumn);
            }
            foreach (T entry in Entries)
            {
                PrimaryUIElement.Items.Add(entry);
            }
            PrimaryUIElement.SelectionChanged += PrimaryUIElement_SelectionChanged;
            PrimaryUIElement.SetValue(Grid.RowSpanProperty, Rowspan - 1);
            grid.Children.Add(PrimaryUIElement);
            base.RenderToGrid(grid, currentRow, currentCol);
        }

        private void PrimaryUIElement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = PrimaryUIElement.SelectedIndex;

            if (selectedIndex == -1 || selectedIndex > Entries.Count - 1 || PrimaryUIElement.SelectedItem == null) return;


            Callback.Invoke((T)PrimaryUIElement.SelectedItem);
        }

        public void AddEntry(T item)
        {
            Entries.Add(item);
            PrimaryUIElement.Items.Add(item);
        }

        public void RemoveItem(T item)
        {
            Entries.Remove(item);
            PrimaryUIElement.Items.Clear();
            foreach (T entry in Entries)
            {
                PrimaryUIElement.Items.Add(entry);
            }
        }
    }
}
