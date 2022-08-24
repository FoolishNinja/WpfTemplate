using SwissSkillsTemplate;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfTemplate.Form
{

    public abstract class FormField
    {
        public string Name { get; set; }
        public int Colspan = FormStyling.COLUMNS;
        public int Rowspan = 1;

        public virtual void RenderToGrid(Grid grid, int currentRow, int currentCol)
        {
        }
    }

    public class FormField<T> : FormField where T : UIElement
    {
        private int _Row { get; set; }
        public int Row
        {
            get => _Row;
            set {
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

        private bool _IsValid { get; set; }
        public bool IsValid
        {
            get => _IsValid;
            set
            {
                _IsValid = value;
                if(ValidationMessageLabel != null)
                    ValidationMessageLabel.Visibility = _IsValid ? Visibility.Hidden : Visibility.Visible;
            }
        }
        public string ValidationMessage { get; set; }

        public Label ValidationMessageLabel { get; set; }

        public T PrimaryUIElement { get; set; }

        public FormField()
        {
            if(Name == null)
            {
                Name = Utils.RandomCharacterString(10);
            }
        }

        public override void RenderToGrid(Grid grid, int currentRow, int currentCol)
        {
            ValidationMessageLabel = new Label();
            ValidationMessageLabel.Content = ValidationMessage;
            ValidationMessageLabel.Foreground = (SolidColorBrush) new BrushConverter().ConvertFrom("#ff0000");
            ValidationMessageLabel.Visibility = IsValid ? Visibility.Hidden : Visibility.Visible;
            ValidationMessageLabel.SetValue(Grid.RowProperty, currentRow + Rowspan);
            ValidationMessageLabel.SetValue(Grid.ColumnProperty, 1);
            ValidationMessageLabel.SetValue(Grid.ColumnSpanProperty, Colspan);
            grid.Children.Add(ValidationMessageLabel);
        }
    }
}
