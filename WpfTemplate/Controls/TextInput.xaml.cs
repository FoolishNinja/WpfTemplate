using WpfTemplate.Controls.ControlModels.TextInput;
using System.Windows.Controls;


namespace WpfTemplate.Controls
{
    /// <summary>
    /// Interaction logic for TextField.xaml
    /// </summary>
    public partial class TextInput : UserControl
    {
        public string Value
        {
            get => Context.InputText;
            set => Context.InputText = value;
        }

        public TextInputProps _Props { get; set; }
        public TextInputProps Props {
            get => _Props; 
            set
            {
                _Props = value;
                Context.InputText = _Props.Value;
                Context.Label = _Props.Label;
                if(_Props.IsReadOnly == true)
                {
                    TextBox.IsReadOnly = true;
                    TextBox.Focusable = false;
                }
            }
        }
        private TextInputContext Context { get; set; }
        public TextInput()
        {
            InitializeComponent();
            Context = new TextInputContext();
            DataContext = Context;
        }

        public class TextInputContext : Model
        {
            public string _Label { get; set; }
            public string Label
            {
                get => _Label;
                set
                {
                    _Label = value;
                    OnPropertyChanged("Label");
                }
            }

            private string _InputText { get; set; }
            public string InputText
            {
                get => _InputText;
                set
                {
                    _InputText = value;
                    OnPropertyChanged("InputText");
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Props.Callback.Invoke();
        }
    }
}
