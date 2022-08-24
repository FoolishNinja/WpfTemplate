using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfTemplate.Controls.ControlModels.DropDown
{
    public class DropDownProps
    {
        public string Placeholder { get; set; }
        public List<DropDownEntry> Entries { get; set; }
        public Action Callback { get; set; }

    }
}
