using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager
{
    public class Emploee : Account
    {
        public Emploee(string emploeeName, string EmploeePass)
        {
            UserName = emploeeName;
            Password = EmploeePass;
        }
        public Emploee()
        {

        }
    }
}
