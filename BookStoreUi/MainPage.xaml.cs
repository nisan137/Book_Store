using AccountsManager;
using InventoryManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BookStoreUi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public InventoryStoreManager mainPageBookList = new InventoryStoreManager(); // Main Book List, public for use in other pages to prevent errors
        AccountManager accountManager = new AccountManager();
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private void SignIn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Checks if Username Text Box or Password Text Box are empty, will throw a message in the correct control if empty
            if (UserNameTbx.Text == "" || PasswordTbx.Text == "")
            {
                ErrorBlock.Text = "Please enter username and password";
                return;
            }
            Account acnt = accountManager.GetCurrentAcount(UserNameTbx.Text, accountManager.Accounts); // Gets the current account entered in username
            if (acnt == null)
            {
                ErrorBlock.Text = "Wrong username"; // If such account not exists, throws a message
            }
            else if (acnt.VerifyPassword(PasswordTbx.Text.ToString()) == false)
            {
                ErrorBlock.Text = "Wrong password"; // If password is wrong, throws a message
            }
            else if (UserNameTbx.Text == acnt.UserName && acnt.VerifyPassword(PasswordTbx.Text.ToString()) == true) // Verification function for password
            {
                // Checks what type is Account, if Admin, moves to LibrarianPage, if User, moves to UserUI page.

                if (acnt is Admin)   
                    Frame.Navigate(typeof(StoreIntro), new Tuple<object, object, object>(mainPageBookList, accountManager, acnt));

                else if (acnt is Emploee)
                    Frame.Navigate(typeof(StoreIntro), new Tuple<object, object, object>(mainPageBookList, accountManager, acnt));
            }
        }
        private void Exit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
