using System.Collections.Generic;
using System.Threading;
using WpfTemplate.CarloLib;
using WpfTemplate.CarloLib.UC;
using WpfTemplate.Utils;

namespace WpfTemplate.Models
{
    public class TestModel
    {
        [Field]
        public ImageField ImageField = new ImageField { ImageSource = "icon.png", Column = 1, Row = 1, ColumnSpan = 3, RowSpan = 3 };
        [Field]
        public TextBoxField TextBoxField = new TextBoxField { Text = "Test1234", Callback = (value) => { }, Row = 4, Column = 1, ColumnSpan = 3 };
        [Field]
        public PasswordField PasswordField = new PasswordField { Callback = (value) => { }, Row = 6, Column = 1, ColumnSpan = 3 };
        [Field]
        public LabelField LabelField = new LabelField { Text = "Test1234", Column = 1, Row = 8, ColumnSpan = 3, RowSpan = 4, Foreground = "Red", FontFamily = "Trebuchet MS", FontSize = 30 };
        [Field]
        public DropDownField DropDownField = new DropDownField
        {
            Column = 1, Row = 10, ColumnSpan = 3, Callback = (value) => { }, 
            Items = new Dictionary<string, object>()
            {
                {"test", 0},
                {"abc", 1}
            },
            SelectedItem = "test"
        };
    }
}
