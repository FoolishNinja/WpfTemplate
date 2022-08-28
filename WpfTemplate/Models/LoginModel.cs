using System.Collections.Generic;
using WpfTemplate.Form;
using WpfTemplate.Form.FormFields;
using WpfTemplate.Lib;

namespace WpfTemplate.Views
{
    public class LoginModel : BaseModel
    {
        public int Columns { get; set; } = 20;
        public int Rows { get; set; } = 30;
        public int Width { get; set; } = 300;
        public int Height { get; set; } = 400;
        public List<FormField> Fields { get; set; } = new List<FormField>()
        {
            new ImageFormField { Col = 2, Row = 2, Colspan = 10, Rowspan = 10, Width = 150, Height = 150, Path = "icon.png" },
            new LabelFormField { Col = 2, Row = 13, Colspan = 10, Rowspan = 1, FontSize = 15, Label = "Employee username" }
        };
    }
}
