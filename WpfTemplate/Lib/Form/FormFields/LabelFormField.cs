using System.Windows;
using System.Windows.Controls;

namespace WpfTemplate.Form.FormFields
{
    public class LabelFormField : FormField<Label>
    {
        private string _Text { get; set; }
        public string Text
        {
            get => _Text;
            set
            {
                _Text = value;
                PrimaryUIElement.Content = Text;
            }
        }

        public int FontSize = -1;

        public LabelFormField()
        {
            Rowspan = 1;
            PrimaryUIElement = new Label();
        }

        public override void RenderToGrid(Grid grid, int currentRow, int currentCol)
        {
            Row = currentRow;
            Col = currentCol;
            PrimaryUIElement.Content = Text;
            PrimaryUIElement.Name = Name;
            PrimaryUIElement.FontSize = FontSize == -1 ? FormStyling.FONT_SIZE : FontSize;
            grid.Children.Add(PrimaryUIElement);
            base.RenderToGrid(grid, currentRow, currentCol);
        }
    }
}
