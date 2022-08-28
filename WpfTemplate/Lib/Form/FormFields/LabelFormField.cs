using System.Windows;
using System.Windows.Controls;

namespace WpfTemplate.Form.FormFields
{
    public class LabelFormField : FormField<Label>
    {
        private string _Label { get; set; }
        public string Label
        {
            get => _Label;
            set
            {
                _Label = value;
                PrimaryUIElement.Content = Label;
            }
        }

        public int FontSize = 15;

        public LabelFormField()
        {
            PrimaryUIElement = new Label();
        }

        public override void RenderToGrid(Grid grid)
        {
            PrimaryUIElement.Content = Label;
            PrimaryUIElement.Name = Name;
            PrimaryUIElement.FontSize = FontSize;
            grid.Children.Add(PrimaryUIElement);
            base.RenderToGrid(grid);
        }
    }
}
