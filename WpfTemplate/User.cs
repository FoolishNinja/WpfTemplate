using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTemplate.CarloLib;

namespace WpfTemplate
{
    public class User
    {
        [TableColumnHeader( Header = "User name" )]
        public string Username { get; set; }
        [TableColumnHeader(Header = "First name")]
        public string FirstName { get; set; }
        [TableColumnHeader(Header = "Last name")]
        public string LastName { get; set; }
        [TableColumnHeader(Header = "Full name")]
        public string FullName
        {
            get => FirstName + " " + LastName;
        }
    }
}
