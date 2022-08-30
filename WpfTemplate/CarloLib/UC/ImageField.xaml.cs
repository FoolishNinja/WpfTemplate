using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using WpfTemplate.Utils;

namespace WpfTemplate.CarloLib
{
    /// <summary>
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class ImageField : UserControl
    {
        public ImageModel Model = new ImageModel();
        public ImageField()
        {
            InitializeComponent();
            DataContext = Model;
        }

        public int Width
        {
            get => Model.Width;
            set => Model.Width = value;
        }

        public int Height
        {
            get => Model.Height;
            set => Model.Height = value;
        }

        public string ImageSource
        {
            get => Model.ImageSource;
            set => Model.ImageSource = value;
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

        private void ParentGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Width = (int)ParentGrid.ActualWidth;
            Height = (int)ParentGrid.ActualHeight;
        }
    }

    public class ImageModel : INotifyPropertyChanged
    {
        private int _Width;
        public int Width
        {
            get => _Width;
            set => SetField(ref _Width, value, "Width");
        }

        private int _Height;
        public int Height
        {
            get => _Height;
            set => SetField(ref _Height, value, "Height");
        }

        private string _ImageSource;
        public string ImageSource
        {
            get => _ImageSource;
            set => SetField(ref _ImageSource, $"pack://application:,,,/WpfTemplate;component/Resources/{value}", "ImageSource");
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
