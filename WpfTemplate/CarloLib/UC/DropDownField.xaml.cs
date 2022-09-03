﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private long InitializationTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        public DropDownField()
        {
            InitializeComponent();
            DataContext = Model;

        }

        public void AddItem(object item)
        {
            Model.Items.Add(item);
        }

        public void RemoveItem(object item)
        {
            Model.Items.Remove(item);
        }

        public ObservableCollection<object> Items
        {
            get => Model.Items;
            set => Model.Items = value;
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
            if (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - InitializationTime < 1000) return;
            int selectedIndex = ComboBox.SelectedIndex;
            if (selectedIndex < 0) return;
            Model.IsEditable = false;
            object value = Items[selectedIndex];
            Callback.Invoke(value);
        }
    }

    public class DropDownFieldModel : INotifyPropertyChanged
    {
        private ObservableCollection<object> _Items;
        public ObservableCollection<object> Items
        {
            get => _Items;
            set {
                SetField(ref _Items, value, "Items");
            }
        }

        public Action<object> Callback;

        private bool _IsEditable = true;
        public bool IsEditable
        {
            get => _IsEditable;
            set => SetField(ref _IsEditable, value, "IsEditable");
        }

        private string _SelectedItem = null;
        public string SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if (Items.Contains(value)) IsEditable = false;
                SetField(ref _SelectedItem, value, "SelectedItem");
            }
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
