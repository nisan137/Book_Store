using Microsoft.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using AccountsManager;
using Windows.System;
using InventoryManager;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BookStoreUi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StoreIntro : Page
    {
        public InventoryStoreManager mainPageBookList;
        private MainPage mainPage = new MainPage();
        private AccountManager accountManager;
        private Account currentUserAccount;
        public StoreIntro()
        {

            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            this.mainPageBookList = new InventoryStoreManager();

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // 1st parameter is the BookListManage object, 2nd is the UserManager, 3rd is the current Account (logged in)
            // Passed as Tuple from MainPage
            if (e.Parameter is Tuple<object, object, object>)
            {
                Tuple<object, object, object> mainPageParams = e.Parameter as Tuple<object, object, object>;

                if (mainPageParams.Item2 != null)
                    accountManager = mainPageParams.Item2 as AccountManager;

                if (mainPageParams.Item3 != null)
                {
                    currentUserAccount = mainPageParams.Item3 as Account;
                }
            }
        }
        private void ViewMore_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void BookSelected_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BookDescription));
        }

        private void Exit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void EditInventory_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (currentUserAccount.UserName == "Admin" || currentUserAccount.UserName == "stavAdmin")
            {
                this.Frame.Navigate(typeof(ReportsPage));
            }
            else
            {
                NoPermisionDialog();
            }
        }

        private void ProduceReports_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (currentUserAccount.UserName == "Admin" || currentUserAccount.UserName == "stavAdmin")
            {
                this.Frame.Navigate(typeof(ReportsPage));
            }
            else
            {
                NoPermisionDialog();
            }

        }
        private async void NoPermisionDialog()
        {
            ContentDialog noPermisionDialog = new ContentDialog
            {
                Title = $"You dont have permision to press this button.",
                Content = "are you an admin? please log in as admin first and than try again.",
                PrimaryButtonText = "Close"
            };
            ContentDialogResult result = await noPermisionDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                this.Frame.Navigate(typeof(StoreIntro));
            }
        }

        private void SortedFilter_Clicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FilterBy_Window));
        }

        private void ViewAll_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}