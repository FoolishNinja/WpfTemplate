using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfTemplate.Controls.ControlModels.ToolBar
{
    public class ToolBarEntry
    {
        public string Text { get; set; }
        public Action? Callback = () => { };
        public List<ToolBarEntry> Children = new List<ToolBarEntry>();
    }
}
