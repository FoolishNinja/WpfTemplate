using System;
using System.Collections.Generic;
using WpfTemplate.Form;
using WpfTemplate.Form.FormFields;
using WpfTemplate.Lib;

namespace WpfTemplate.Models
{
    public class TestModel : BaseModel
    {
        public int Columns = 12;
        public int Rows = 12;
        public List<FormField> Fields = new List<FormField>()
        {
        };

        public TestModel()
        {
            base.Columns = Columns;
            base.Rows = Rows;
            base.Fields = Fields;
        }
    }
}
