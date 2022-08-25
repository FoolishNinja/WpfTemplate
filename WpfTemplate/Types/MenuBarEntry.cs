using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfTemplate.Types
{
    public class MenuBarEntry
    {
        public string Text { get; set; }
        public Action? Callback = () => { };
        public List<MenuBarEntry> Children = new List<MenuBarEntry>();
    }
}
