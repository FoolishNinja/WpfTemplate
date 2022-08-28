using System.Collections.Generic;
using System.ComponentModel;
using WpfTemplate.Form;

namespace WpfTemplate.Lib
{
    public interface BaseModel
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public List<FormField> Fields { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
