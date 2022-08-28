using SwissSkillsTemplate;
using System.Windows;
using System.Windows.Controls;

namespace WpfTemplate.Form
{

    public abstract class FormField
    {
        public string Name { get; set; }

        public virtual void RenderToGrid(Grid grid)
        {
        }
    }

    public class FormField<T> : FormField where T : UIElement
    {
        private int _Row { get; set; }

        private int _Colspan { get; set; }
        public int Colspan
        {
            get => _Colspan;
            set
            {
                _Colspan = value;
                PrimaryUIElement.SetValue(Grid.ColumnSpanProperty, value);
            }
        }
        private int _Rowspan { get; set; }
        public int Rowspan 
        {
            get => _Rowspan;
            set
            {
                _Rowspan = value;
                PrimaryUIElement.SetValue(Grid.RowSpanProperty, value);
            }
        }
        public int Row
        {
            get => _Row;
            set
            {
                _Row = value;
                PrimaryUIElement.SetValue(Grid.RowProperty, value);
            }
        }

        public int _Col { get; set; }
        public int Col
        {
            get => _Col;
            set
            {
                _Col = value;
                PrimaryUIElement.SetValue(Grid.ColumnProperty, value);
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
    }
}
