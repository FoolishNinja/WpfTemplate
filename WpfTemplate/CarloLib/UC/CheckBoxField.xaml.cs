using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using WpfTemplate.Utils;

namespace WpfTemplate.CarloLib.UC
{
    /// <summary>
    /// Interaction logic for CheckBoxField.xaml
    /// </summary>
    public partial class CheckBoxField : UserControl
    {
        public CheckBoxFieldModel Model = new CheckBoxFieldModel();

        public CheckBoxField()
        {
            InitializeComponent();
            DataContext = Model;
        }

        public bool IsChecked
        {
            get => Model.IsChecked;
            set => Model.IsChecked = value;
        }

        public Action<bool> Callback
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

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            Callback.Invoke(Model.IsChecked);
        }
    }

    public class CheckBoxFieldModel : INotifyPropertyChanged
    {
        private bool _IsChecked;
        public bool IsChecked
        {
            get => _IsChecked;
            set => SetField(ref _IsChecked, value, "IsChecked");
        }

        public Action<bool> Callback { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
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
