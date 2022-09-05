using Accessibility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using WpfTemplate.Utils;

namespace WpfTemplate.CarloLib.UC
{
    /// <summary>
    /// Interaction logic for RadioField.xaml
    /// </summary>
    public partial class RadioField : UserControl
    {
        public RadioFieldModel Model = new RadioFieldModel();

        public RadioField()
        {
            InitializeComponent();
            DataContext = Model;
        }

        public int Amount
        {
            get => Model.Amount;
            set
            {
                BaseGrid.Children.Clear();
                BaseGrid.ColumnDefinitions.Clear();
                BaseGrid.RowDefinitions.Clear();
                Model.RadioButtons.Clear();
                //if(Labels.Count > 0)
                {
                    if(Model.Direction == "vertical")
                    {
                        BaseGrid.ColumnDefinitions.Add(BaseWindow.GetColumnDefinition(LabelsBefore ? 3 : 1));
                        BaseGrid.ColumnDefinitions.Add(BaseWindow.GetColumnDefinition(LabelsBefore ? 1 : 3));
                    } else
                    {
                        BaseGrid.RowDefinitions.Add(BaseWindow.GetRowDefinition(LabelsBefore ? 3 : 1));
                        BaseGrid.RowDefinitions.Add(BaseWindow.GetRowDefinition(LabelsBefore ? 1 : 3));
                    }
                }

                bool vertical = Model.Direction == "vertical";
                for (int i = 0; i < value; i++)
                {
                    RadioButton radioButton = new RadioButton();
                    radioButton.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                    radioButton.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                    if (vertical)
                    {
                        BaseGrid.RowDefinitions.Add(BaseWindow.GetRowDefinition(1));
                        radioButton.SetValue(Grid.RowProperty, i);
                        radioButton.SetValue(Grid.ColumnProperty, LabelsBefore ? 1 : 0);
                        
                    }
                    else {
                        BaseGrid.ColumnDefinitions.Add(BaseWindow.GetColumnDefinition(1));
                        radioButton.SetValue(Grid.ColumnProperty, i);
                        radioButton.SetValue(Grid.RowProperty, LabelsBefore ? 1 : 0);
                    }
                    if (Labels.Count > 0)
                    {
                        LabelField labelField = new LabelField { Text = Labels[i], Column = vertical ? (LabelsBefore ? 0 : 1) : i, Row = vertical ? i : (LabelsBefore ? 0 : 1) };
                        BaseGrid.Children.Add(labelField);
                    }
                    radioButton.Checked += RadioButton_Checked;
                    Model.RadioButtons.Add(radioButton);
                    BaseGrid.Children.Add(radioButton);
                }


                Model.Amount = value;
            }
        }

        public string Direction
        {
            get => Model.Direction;
            set => Model.Direction = value;

        }

        public List<string> Labels
        {
            get => Model.Labels;
            set => Model.Labels = value;
        }

        public bool LabelsBefore
        {
            get => Model.LabelsBefore;
            set => Model.LabelsBefore = value;
        }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            Callback.Invoke(Model.RadioButtons.IndexOf((RadioButton)sender));
        }

        public Action<int> Callback
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
    }

    public class RadioFieldModel : INotifyPropertyChanged
    {
        public string Direction = "vertical";

        public Action<int> Callback { get; set; }

        public int Amount { get; set; }

        public List<string> Labels = new List<string>();

        public bool LabelsBefore = true;

        public List<RadioButton> RadioButtons = new List<RadioButton>();

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
