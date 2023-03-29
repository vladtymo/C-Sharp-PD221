using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_classes.Partials
{
    internal partial class User
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsValidEmail()
        {
            return Email != null && Email.Contains('@');
        }
    }
}
