using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using WpfTemplate.Utils;

namespace WpfTemplate.CarloLib.UC
{
    /// <summary>
    /// Interaction logic for DropDownField.xaml
    /// </summary>
    public partial class DropDownField : UserControl
    {
        public DropDownFieldModel Model = new DropDownFieldModel();

        public DropDownField()
        {
            InitializeComponent();
            DataContext = Model;
        }

        private Dictionary<string, object> _Items;
        public Dictionary<string, object> Items
        {
            get => _Items;
            set {
                _Items = value;
                Model.Items = new List<string>(value.Keys);
            }
        }

        public string Placeholder
        {
            get => Model.Placeholder;
            set => Model.Placeholder = value;
        }

        public string SelectedItem
        {
            get => Model.SelectedItem;
            set => Model.SelectedItem = value;
        }

        public Action<object> Callback
        {
            get => Model.Callback;
            set => Model.Callback = value;
        }

        private int _Column;
        public int Column
        {
            get => _Column;
            set
            {
                SetValue(Grid.ColumnProperty, value);
                _Column = value;
            }
        }

        private int _Row;
        public int Row
        {
            get => _Row;
            set
            {
                SetValue(Grid.RowProperty, value);
                _Row = value;
            }
        }

        private int _ColumnSpan;
        public int ColumnSpan
        {
            get => _ColumnSpan;
            set
            {
                SetValue(Grid.ColumnSpanProperty, value);
                _ColumnSpan = value;
            }
        }

        private int _RowSpan;
        public int RowSpan
        {
            get => _RowSpan;
            set
            {
                SetValue(Grid.RowSpanProperty, value);
                _RowSpan = value;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = ComboBox.SelectedIndex;
            if (selectedIndex < 0) return;
            Model.IsEditable = false;
            Callback.Invoke(new List<object>(Items.Values)[selectedIndex]);
        }
    }

    public class DropDownFieldModel : INotifyPropertyChanged
    {
        private List<string> _Items;
        public List<string> Items
        {
            get => _Items;
            set => SetField(ref _Items, value, "Items");
        }

        public Action<object> Callback;

        private string _Placeholder;
        public string Placeholder
        {
            get => _Placeholder;
            set => SetField(ref _Placeholder, value, "Placeholder");
        }

        private bool _IsEditable = true;
        public bool IsEditable
        {
            get => _IsEditable;
            set => SetField(ref _IsEditable, value, "IsEditable");
        }

        private string _SelectedItem;
        public string SelectedItem
        {
            get => _SelectedItem;
            set => SetField(ref _SelectedItem, value, "SelectedItem");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
