using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;


namespace WpfTemplate.CarloLib.UC
{
    /// <summary>
    /// Interaction logic for DateField.xaml
    /// </summary>
    public partial class DateField : UserControl
    {
        public DateFieldModel Model = new DateFieldModel();
        private long InitializationTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public DateField()
        {
            InitializeComponent();
            DataContext = Model;
        }

        public DateTime SelectedDate
        {
            get => Model.SelectedDate;
            set => Model.SelectedDate = value;
        }

        public Action<DateTime> Callback
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

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - InitializationTime < 1000) return;
            Callback.Invoke(SelectedDate);
        }
    }

    public class DateFieldModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Action<DateTime> Callback { get; set; }

        private DateTime _SelectedDate;
        public DateTime SelectedDate
        {
            get => _SelectedDate;
            set => SetField(ref _SelectedDate, value, "SelectedDate");
        }

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
