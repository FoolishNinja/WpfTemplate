using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

using WpfTemplate.Form;
using WpfTemplate.Form.FormFields;
using WpfTemplate.Lib;
using WpfTemplate.Models;
using WpfTemplate.Types;

namespace WpfTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            new BaseWindow<TestModel>("Test", new TestModel()).Show();
            InitializeComponent();
            Hide();
            //Dictionary<string, string> entries = new Dictionary<string, string>();
            //entries.Add("Test1", "1");
            //entries.Add("Test2", "2");
            //entries.Add("Test3", "3");
            //entries.Add("Test4", "4");
            //LabelFormField labelFormField = new LabelFormField { Text = "Test field", IsValid = false, ValidationMessage = "Not valid" };
            //new FormWindow("Test Form", new List<List<FormField>>() {
            //    new List<FormField>() {
            //        labelFormField,
            //        new TextBoxFormField { Label = "Amount", Callback = (msg) => {  }, Placeholder = "Enter a value" },
            //        new TextBoxFormField { Label = "Amount", Callback = (msg) => {  }, Placeholder = "Enter a value" },
            //        new DropDownFormField<string> { Label = "Test dropdown", Placeholder = "Select an element", Callback = (selectedValue) => { }, DropDownEntries = entries },
            //        new DateFormField { Label = "Date", Value = new DateTime(0), Callback = (dateTime) => Message.Info(dateTime.ToString()) },
            //    },
            //    new List<FormField>()
            //    {
            //        new ButtonFormField { Label = "Button", Callback = () => { } },
            //        new ListBoxFormField<string> {Label = "ListBox", Entries = entries, Callback = (value) => Message.Info(value) },
            //        //new TableFormField<Animal> { Label = "Animals", Headers = new List<TableHeader>()
            //        //    {
            //        //        new TableHeader { Label = "Name", PropertyName = "Name", WidthRatio = 1 },
            //        //        new TableHeader { Label = "Age", PropertyName = "Age", WidthRatio = 1 },
            //        //        new TableHeader { Label = "Birth date", PropertyName = "BirthDate", WidthRatio = 2 },
            //        //    },
            //        //    Entries = new List<Animal>()
            //        //    {
            //        //        new Animal { Name = "Kevin", Age = 15, BirthDate = DateTime.UtcNow },
            //        //        new Animal { Name = "Kevin", Age = 15, BirthDate = DateTime.UtcNow },
            //        //        new Animal { Name = "Kevin", Age = 15, BirthDate = DateTime.UtcNow },
            //        //        new Animal { Name = "Kevin", Age = 15, BirthDate = DateTime.UtcNow }
            //        //    },
            //        //    Callback = (animal) => { Message.Info(animal.Name);  }
            //        //},
            //        new ImageFormField { Path = "icon.png" }
            //    }
            //},
            //new MenuBar { ToolBarEntries = new List<MenuBarEntry>()
            //{
            //    new MenuBarEntry { Text = "File", Callback = () => {}, Children = new List<MenuBarEntry>()
            //        {
            //            new MenuBarEntry { Text = "Exit" , Callback = () => {} }
            //        }
            //    },
            //    new MenuBarEntry { Text = "File", Callback = () => {}, Children = new List<MenuBarEntry>()
            //        {
            //            new MenuBarEntry { Text = "Exit" , Callback = () => {} }
            //        }
            //    },
            //    new MenuBarEntry { Text = "File", Callback = () => {}, Children = new List<MenuBarEntry>()
            //        {
            //            new MenuBarEntry { Text = "Exit" , Callback = () => {} }
            //        }
            //    }
            //}
            //}).Show();
            //Thread.Sleep(2000);
            //labelFormField.IsValid = true;
        }
    }
}
