using WpfTemplate.Controls.ControlModels.DropDown;
using System.Threading;
using System.Windows;
using System.Windows.Controls;


namespace WpfTemplate.Controls
{
    /// <summary>
    /// Interaction logic for DropDown.xaml
    /// </summary>
    public partial class DropDown : UserControl
    {
        private DropDownContext Context { get; set; }

        public object SelectedValue { get; set; }

        private DropDownProps _Props { get; set; }

        public DropDownProps Props { 
            get => _Props; 
            set {
                _Props = value;
                DropDownComboBox.Items.Clear();
                Context.Placeholder = _Props.Placeholder;
                foreach (DropDownEntry entry in _Props.Entries)
                {
                    DropDownComboBox.Items.Add(entry.Text);
                    if(entry.Selected)
                    {
                        DropDownComboBox.Text = entry.Text;
                        Context.Placeholder = entry.Text;
                    }
                }
            }
        }

        public DropDown()
        {
            InitializeComponent();
            Context = new DropDownContext();
            DataContext = Context;
        }

        private void DropDownComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = (sender as ComboBox).SelectedIndex;
            if (selectedIndex == -1) return;
            SelectedValue = Props.Entries[selectedIndex].Value;
            Props.Callback.Invoke();
        }

        public class DropDownContext : Model
        {
            private string _Placeholder { get; set; }
            public string Placeholder { 
                get => _Placeholder;
                set
                {
                    _Placeholder = value;
                    OnPropertyChanged("Placeholder");
                }
            }
        }
    }
}
