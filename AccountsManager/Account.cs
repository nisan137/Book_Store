using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager
{
    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }


        public bool VerifyPassword(string input)
        {
            bool checkIfPassValid = PrivateVerifyPassword(input);
            return checkIfPassValid;
        }
        private bool PrivateVerifyPassword(string input)
        {
            bool checkPass = false;
            if (input != null)
            {
                checkPass = input == Password;
            }
            return checkPass;
        }
    }
}