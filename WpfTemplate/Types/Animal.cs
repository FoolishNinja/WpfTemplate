using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTemplate.Types
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate = DateTime.UtcNow;
    }
}
