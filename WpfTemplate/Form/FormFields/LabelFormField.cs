using System.Windows;
using System.Windows.Controls;

namespace WpfTemplate.Form.FormFields
{
    public class LabelFormField : FormField<Label>
    {
        public string Text { get; set; }

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
            PrimaryUIElement.FontSize = FormStyling.FONT_SIZE;
            grid.Children.Add(PrimaryUIElement);
            base.RenderToGrid(grid, currentRow, currentCol);
        }
    }
}
