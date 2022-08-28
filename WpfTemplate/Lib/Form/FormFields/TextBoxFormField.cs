

using System;
using System.Windows.Controls;

namespace WpfTemplate.Form.FormFields
{
    public class TextBoxFormField : FormField<TextBox>
    {
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
            PrimaryUIElement = new TextBox();
        }

        public override void RenderToGrid(Grid grid)
        {
            PrimaryUIElement.GotFocus += RemovePlaceholder;
            PrimaryUIElement.LostFocus += AddPlaceholder;
            PrimaryUIElement.TextChanged += TextBox_TextChanged;
            PrimaryUIElement.Name = Name;
            PrimaryUIElement.FontSize = 13;
            PrimaryUIElement.Text = Value != null ? Value : Placeholder;
            PrimaryUIElement.IsReadOnly = IsReadOnly;
            grid.Children.Add(PrimaryUIElement);
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
