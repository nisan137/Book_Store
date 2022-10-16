using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace AccountsManager
{
    public class AccountManager
    {
        List<Account> accounts = new List<Account>();

        public AccountManager()
        {
            accounts.Add(new Admin("Admin", "Pass"));
            accounts.Add(new Admin("stavAdmin", "Pass1"));
            accounts.Add(new Emploee("User", "Pass"));
            accounts.Add(new Emploee("nisanEmploee", "Pass123"));
        }
        public List<Account> Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
        
        public Account GetCurrentAcount(string userName, List<Account> accountList)// Get current Account
        {
            Account currentUser = PrivateGetCurrentAcount(userName, accountList);
            return currentUser;
        }
        private Account PrivateGetCurrentAcount(string userName, List<Account> accountList)
        {
            Account temp = default;
            foreach (Account item in accountList)
            {
                if (userName == item.UserName)
                    temp = item;
            }
            return temp;
        }
    }
}
