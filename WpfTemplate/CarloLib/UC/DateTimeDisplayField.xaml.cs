using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Controls;


namespace WpfTemplate.CarloLib.UC
{
    /// <summary>
    /// Interaction logic for DateTimeDisplayField.xaml
    /// </summary>
    public partial class DateTimeDisplayField : UserControl
    {
        public DateTimeDisplayFieldModel Model = new DateTimeDisplayFieldModel();

        public DateTimeDisplayField()
        {
            InitializeComponent();
            DataContext = Model;
            BaseGrid.Children.Add(Model.DateTimeLabelField);
            new Thread(() =>
            {
                while (true)
                {
                    DateTime now = DateTime.UtcNow;
                    Model.DateTimeLabelField.Text = (now.Hour < 10 ? "0" : "") + now.Hour + ":" + (now.Minute < 10 ? "0" : "") + now.Minute + ":" + (now.Second < 10 ? "0" : "") + now.Second;
                }
            }).Start();
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
    }

    public class DateTimeDisplayFieldModel : INotifyPropertyChanged
    {
        public LabelField DateTimeLabelField = new LabelField { Text = "" };

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
