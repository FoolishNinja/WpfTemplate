using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTemplate.CarloLib.UC
{
    /// <summary>
    /// Interaction logic for LabelField.xaml
    /// </summary>
    public partial class LabelField : UserControl
    {
        public LabelFieldModel Model = new LabelFieldModel();

        public LabelField()
        {
            InitializeComponent();
            DataContext = Model;
        }

        public string Foreground
        {
            get => Model.Foreground;
            set => Model.Foreground = value;
        }

        public string FontFamily
        {
            get => Model.FontFamily;
            set => Model.FontFamily = value;
        }

        public int FontSize
        {
            get => Model.FontSize;
            set => Model.FontSize = value;
        }

        public string Text
        {
            get => Model.Text;
            set => Model.Text = value;
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

    public class LabelFieldModel : INotifyPropertyChanged
    {
        private string _Foreground;
        public string Foreground
        {
            get => _Foreground;
            set => SetField(ref _Foreground, value, "Foreground");
        }

        public string _FontFamily;

        public string FontFamily
        {
            get => _FontFamily;
            set =>  SetField(ref _FontFamily, value, "FontFamily");
        }

        private int _FontSize;
        public int FontSize
        {
            get => _FontSize;
            set => SetField(ref _FontSize, value, "FontSize");
        }

        private string _Text;
        public string Text
        {
            get => _Text;
            set => SetField(ref _Text, value, "Text");
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
