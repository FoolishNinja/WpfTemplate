using System.Collections.Generic;
using WpfTemplate.CarloLib;
using WpfTemplate.CarloLib.UC;
using WpfTemplate.Utils;

namespace WpfTemplate.Models
{
    public class TestModel
    {
        private Dictionary<string, object> TestDictionary = new Dictionary<string, object>();
        [Field]
        public ImageField ImageField = new ImageField { ImageSource = "icon.png", Column = 1, Row = 1, ColumnSpan = 3, RowSpan = 3 };
        [Field]
        public TextBoxField TextBoxField = new TextBoxField { Text = "Test1234", Callback = (value) => Message.Info(value), Row = 4, Column = 1, ColumnSpan = 3 };
        [Field]
        public PasswordField PasswordField = new PasswordField { Callback = (value) => Message.Info(value), Row = 6, Column = 1, ColumnSpan = 3 };
        [Field]
        public LabelField LabelField = new LabelField { Text = "Test1234", Column = 1, Row = 8, ColumnSpan = 3, RowSpan = 4, Foreground = "Red", FontFamily = "Trebuchet MS", FontSize = 30 };
        [Field]
        public DropDownField DropDownField = new DropDownField
        {
            Column = 1, Row = 10, ColumnSpan = 3, Callback = (value) => { }
        };

        public TestModel()
        {
            for(int i = 0; i < 10; i++)
            {
                TestDictionary.Add($"\"{i}\"", i);
            }
            DropDownField.Items = TestDictionary;
        }
    }
}
