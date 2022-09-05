using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using WpfTemplate.CarloLib;
using WpfTemplate.CarloLib.UC;
using WpfTemplate.Utils;

namespace WpfTemplate.Models
{
    public class TestModel
    {
        [Field]
        public static ImageField ImageField = new ImageField { ImageSource = "icon.png", Column = 6, Row = 6, ColumnSpan = 6, RowSpan = 6 };
        [Field]
        public static TextBoxField TextBoxField = new TextBoxField { Text = "Test1234", Callback = (value) => { }, Row = 4, Column = 1, ColumnSpan = 3 };
        [Field]
        public static PasswordField PasswordField = new PasswordField { Callback = (value) => { }, Row = 6, Column = 1, ColumnSpan = 3 };
        [Field]
        public static LabelField LabelField = new LabelField { Text = "Test1234", Column = 1, Row = 8, ColumnSpan = 3, RowSpan = 4, Foreground = "Red", FontFamily = "Trebuchet MS", FontSize = 30 };
        [Field]
        public static DropDownField DropDownField = new DropDownField { Items = new ObservableCollection<object>() { "test", "abc" }, Callback = (value) => { TextBoxField.Text = (string) value; LabelField.Text = (string) value; }, SelectedItem = "Select value...", Column = 1, Row = 10, ColumnSpan = 3, RowSpan = 3 };
        [Field]
        public static DateField DateField = new DateField { SelectedDate = DateTime.UtcNow, Callback = (date) => { LabelField.Text = date.ToLongDateString(); }, Column = 1, Row = 13, ColumnSpan = 3 };
        [Field]
        public static CheckBoxField CheckBoxField = new CheckBoxField { IsChecked = false, Callback = (value) => { LabelField.Text = value.ToString(); }, Column = 1, Row = 17 };
        [Field]
        public static RadioField RadioField = new RadioField { Column = 7, Row = 1, ColumnSpan = 2, RowSpan = 2, Direction = "horizontal",  Callback = (value) => { LabelField.Text = value.ToString(); }, Labels = new List<string>() { "test", "abcdefg" }, Amount = 2 };
        [Field]
        public static ButtonField ButtonField = new ButtonField { Label = "test", Column = 7, Row = 4, ColumnSpan = 2, RowSpan = 2, Callback = () => { LabelField.Text = "Clicked button"; TableField.Items.RemoveAt(0); } };
        [Field]
        public static DateTimeDisplayField DateTimeDisplayField = new DateTimeDisplayField { Column = 7, Row = 6, ColumnSpan = 2 };
        [Field]
        public static TableField TableField = new TableField {
            ItemType = typeof(User),
            Items = new ObservableCollection<object>() { new User { Username = "MaxMuster", FirstName = "Max", LastName = "Mustermann" }, new User { Username = "FoolishNinja", FirstName = "Foolish", LastName = "Ninja" } }, 
            ShowColumns = new List<string>() { "FirstName", "LastName"}, 
            Column = 7, Row = 12, ColumnSpan = 6, RowSpan = 6,
            Callback = (value) => { Message.Info(((User)value).FirstName);  }
        };
    }
}
