using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTemplate.Controls.ControlModels.TextInput
{
    public class TextInputProps
    {
        public string Label { get; set; }
        public string? Value = "";
        public Action Callback { get; set; }
        public bool? IsReadOnly { get; set; }
    }
}
