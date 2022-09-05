using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfTemplate.Utils;

namespace WpfTemplate.CarloLib.UC
{
    /// <summary>
    /// Interaction logic for TableField.xaml
    /// </summary>
    public partial class TableField : UserControl
    {
        public TableFieldModel Model = new TableFieldModel();

        public TableField()
        {
            InitializeComponent();
            DataContext = Model;
        }

        public Action<object> Callback
        {
            get => Model.Callback;
            set => Model.Callback = value;
        }

        public ObservableCollection<object> Items
        {
            get => Model.Items;
            set => Model.Items = value;
        }

        public Type ItemType
        {
            get => Model.ItemType;
            set => Model.ItemType = value;
        }

        public List<string> ShowColumns
        {
            get => Model.ShowColumns;
            set
            {
                Model.ShowColumns = value;
                DataGrid.Columns.Clear();
                foreach(string shownColumn in value)
                {
                    DataGridTextColumn column = new DataGridTextColumn();
                    
                    // Checking if its a property
                    PropertyInfo propertyInfo = ItemType.GetProperty(shownColumn);

                    if(propertyInfo != null)
                    {
                        TableColumnHeader columnHeader = (TableColumnHeader) propertyInfo.GetCustomAttribute(typeof(TableColumnHeader), false);
                        if (columnHeader != null)
                        {
                            column.Header = columnHeader.Header;
                        }
                    }

                    // Checking if its a field
                    FieldInfo fieldInfo = ItemType.GetField(shownColumn);
                    if(fieldInfo != null)
                    {
                        TableColumnHeader columnHeader = (TableColumnHeader)fieldInfo.GetCustomAttribute(typeof(TableColumnHeader), false);
                        if(columnHeader != null)
                        {
                            column.Header = columnHeader.Header;
                        }
                    }

                    column.Binding = new Binding(shownColumn);
                    DataGrid.Columns.Add(column);
                }
            }
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Callback.Invoke(DataGrid.SelectedItem);
        }
    }

    public class TableFieldModel : INotifyPropertyChanged
    {
        public Action<object> Callback { get; set; }

        public ObservableCollection<object> Items { get; set; }

        public List<string> ShowColumns { get; set; }

        public Type ItemType { get; set; }

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
