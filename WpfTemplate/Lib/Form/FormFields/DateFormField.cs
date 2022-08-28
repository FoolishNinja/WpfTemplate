using System;
using System.Windows.Controls;

namespace WpfTemplate.Form.FormFields
{
    public class DateFormField : FormField<DatePicker>
    {
        public DateTime Value { get; set; }
        public Action<DateTime> Callback { get; set; }

        public DateFormField()
        {
            PrimaryUIElement = new DatePicker();
        }

        public override void RenderToGrid(Grid grid)
        {
            PrimaryUIElement.SelectedDate = Value == null ? DateTime.UtcNow : Value;
            PrimaryUIElement.SelectedDateChanged += PrimaryUIElement_SelectedDateChanged;
            grid.Children.Add(PrimaryUIElement);
        }

        private void PrimaryUIElement_SelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (PrimaryUIElement.SelectedDate != null)
                Callback.Invoke((DateTime)PrimaryUIElement.SelectedDate);
        }
    }
}
