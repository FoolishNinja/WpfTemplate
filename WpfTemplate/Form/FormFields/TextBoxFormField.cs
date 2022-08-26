

using System;
using System.Windows.Controls;

namespace WpfTemplate.Form.FormFields
{
    public class TextBoxFormField : FormField<TextBox>
    {
        public string Label { get; set; }
        public string Placeholder { get; set; }

        private string _Value { get; set; }
        public string Value
        {
            get => _Value;
            set
            {
                _Value = value;
                PrimaryUIElement.Text = value;
            }
        }

        public bool IsReadOnly = false;

        public Action<string> Callback { get; set; }

        public TextBoxFormField()
        {
            Rowspan = 2;
            PrimaryUIElement = new TextBox();
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
            Row = currentRow + 1;
            Col = currentCol;
            PrimaryUIElement.GotFocus += RemovePlaceholder;
            PrimaryUIElement.LostFocus += AddPlaceholder;
            PrimaryUIElement.TextChanged += TextBox_TextChanged;
            PrimaryUIElement.Name = Name;
            PrimaryUIElement.FontSize = 13;
            PrimaryUIElement.Text = Value != null ? Value : Placeholder;
            PrimaryUIElement.SetValue(Grid.RowSpanProperty, 1);
            PrimaryUIElement.IsReadOnly = IsReadOnly;

            grid.Children.Add(PrimaryUIElement);
            base.RenderToGrid(grid, currentRow, currentCol);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            Callback.Invoke(PrimaryUIElement.Text.Trim());
        }

        public void RemovePlaceholder(object sender, EventArgs e)
        {
            if (PrimaryUIElement.Text == Placeholder)
            {
                PrimaryUIElement.Text = "";
            }
        }

        public void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PrimaryUIElement.Text))
            {
                PrimaryUIElement.Text = Placeholder;
            }
        }
    }
}
