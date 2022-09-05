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
    /// Interaction logic for ButtonField.xaml
    /// </summary>
    public partial class ButtonField : UserControl
    {
        public ButtonFieldModel Model = new ButtonFieldModel();

        public ButtonField()
        {
            InitializeComponent();
            DataContext = Model;
        }

        public string Label
        {
            get => Model.Label;
            set => Model.Label = value;
        }

        public Action Callback
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Callback.Invoke();
        }
    }

    public class ButtonFieldModel : INotifyPropertyChanged
    {

        public Action Callback;

        private string _Label;
        public string Label
        {
            get => _Label;
            set => SetField(ref _Label, value, "Label");
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
