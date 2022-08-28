using System;
using System.Windows.Controls;

namespace WpfTemplate.Form.FormFields
{
    public class ButtonFormField : FormField<Button>
    {
        public string Label { get; set; }
        public Action Callback { get; set; }

        public ButtonFormField()
        {
            Colspan = 5;
            PrimaryUIElement = new Button();
        }

        public override void RenderToGrid(Grid grid)
        {
            PrimaryUIElement.Content = Label;
            PrimaryUIElement.Name = Name;
            PrimaryUIElement.Click += (sender, e) => Callback.Invoke();
            grid.Children.Add(PrimaryUIElement);
            base.RenderToGrid(grid);
        }
    }
}
