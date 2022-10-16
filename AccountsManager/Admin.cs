using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager
{
    public class Admin : Account
    {
        public Admin(string adminName, string adminPass)
        {
            UserName = adminName;
            Password = adminPass;
        }
        public Admin()
        {

        }
    }
}
