using SwissSkillsTemplate;
using System.Windows;
using System.Windows.Controls;

namespace WpfTemplate.Form
{

    public abstract class FormField
    {
        public string Name { get; set; }
        public int Colspan = 1;
        public int Rowspan = 1;

        public virtual void RenderToGrid(Grid grid)
        {
        }
    }

    public class FormField<T> : FormField where T : UIElement
    {
        private int _Row { get; set; }
        public int Row
        {
            get => _Row;
            set
            {
                _Row = value;
                PrimaryUIElement.SetValue(Grid.RowProperty, value);
                PrimaryUIElement.SetValue(Grid.RowSpanProperty, Rowspan);
            }
        }

        public int _Col { get; set; }
        public int Col
        {
            get => _Col;
            set
            {
                _Col = value;
                PrimaryUIElement.SetCurrentValue(Grid.ColumnProperty, value);
                PrimaryUIElement.SetValue(Grid.ColumnSpanProperty, Colspan);
            }
        }

        public bool _IsValid = true;
        public bool IsValid
        {
            get => _IsValid;
            set
            {
                _IsValid = value;
                if (ValidationMessageLabel != null)
                    ValidationMessageLabel.Visibility = _IsValid ? Visibility.Hidden : Visibility.Visible;
            }
        }
        public string ValidationMessage { get; set; }

        public Label ValidationMessageLabel { get; set; }

        public T PrimaryUIElement { get; set; }

        public FormField()
        {
            if (Name == null)
            {
                Name = Utils.RandomCharacterString(10);
            }
        }

        public override void RenderToGrid(Grid grid)
        {
            ValidationMessageLabel = new Label();
            ValidationMessageLabel.Content = ValidationMessage;
            ValidationMessageLabel.Foreground = Utils.GetColorBrushFromHex("#ff0000");
            ValidationMessageLabel.Visibility = IsValid ? Visibility.Hidden : Visibility.Visible;
            ValidationMessageLabel.SetValue(Grid.RowProperty, Row + Rowspan);
            ValidationMessageLabel.SetValue(Grid.ColumnProperty, Col);
            ValidationMessageLabel.SetValue(Grid.ColumnSpanProperty, Colspan);
            grid.Children.Add(ValidationMessageLabel);
        }
    }
}
