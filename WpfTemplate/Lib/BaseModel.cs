using System.Collections.Generic;
using System.ComponentModel;
using WpfTemplate.Form;

namespace WpfTemplate.Lib
{
    public class BaseModel : INotifyPropertyChanged
    {
        public int Columns { get; set; }
        public int Rows { get; set;  }
        public List<FormField> Fields { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
