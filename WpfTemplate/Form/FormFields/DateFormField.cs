using System;
using System.Windows.Controls;

namespace WpfTemplate.Form.FormFields
{
    public class DateFormField : FormField<DatePicker>
    {
        public string Label { get; set; }
        public DateTime Value { get; set; }
        public Action<DateTime> Callback { get; set; }

        public DateFormField()
        {
            Rowspan = 2;
            PrimaryUIElement = new DatePicker();
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
            PrimaryUIElement.SetValue(Grid.RowSpanProperty, 1);
            PrimaryUIElement.SelectedDate = Value == null ? DateTime.UtcNow : Value;
            PrimaryUIElement.SelectedDateChanged += PrimaryUIElement_SelectedDateChanged;
            grid.Children.Add(PrimaryUIElement);
            base.RenderToGrid(grid, currentRow, currentCol);
        }

        private void PrimaryUIElement_SelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {
            if(PrimaryUIElement.SelectedDate != null)
                Callback.Invoke((DateTime) PrimaryUIElement.SelectedDate);
        }
    }
}
