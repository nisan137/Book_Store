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
using Items_Manager;
using Windows.UI.Xaml.Media.Imaging;
using JSON_Logic.Services;
using BookProject;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BookStoreUi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StoreIntro : Page
    {
        //public InventoryStoreManager mainPageBookList;  
        private AccountManager accountManager;
        private Account currentUserAccount;
        public static List<Abstract_Item> BaughtItems { get; set; } = new List<Abstract_Item>();
        public DbService DbServiceForUsage { get; } = new DbService("BoughtItemDB.json");
        public StoreIntro()
        {
            List<Abstract_Item> tempListDB = DbServiceForUsage.GetData<Abstract_Item>();
            if (tempListDB != null)
            {
                BaughtItems = tempListDB;
            }
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            //this.mainPageBookList = InventoryStoreManager.Instance.ItemList;
        }
        public void Save()
        {
            DbServiceForUsage.SaveData(BaughtItems);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // 1st parameter is the BookListManage object, 2nd is the UserManager, 3rd is the current Account (logged in)
            // Passed as Tuple from MainPage
            if (e.Parameter is Tuple<object, object>)
            {
                Tuple<object, object> mainPageParams = e.Parameter as Tuple<object, object>;

                if (mainPageParams.Item1 != null)
                    accountManager = mainPageParams.Item1 as AccountManager;

                if (mainPageParams.Item2 != null)
                {
                    currentUserAccount = mainPageParams.Item2 as Account;
                }
            }
            DescriptionTB.Text = "";
            BookCoverIMG.Source = null;
            ListViewUser.Items.Clear();
        }

        private void Exit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void EditInventory_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (currentUserAccount.UserName == "Admin" || currentUserAccount.UserName == "stavAdmin")
            {
                this.Frame.Navigate(typeof(InventoryPage));
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


        private void ViewAll_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CatalogPage));
        }

        private void ListViewFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterService filterManager = new FilterService(InventoryStoreManager.Instance.ItemList);
            SubFilter.Items.Clear();
            List<string> filteredList = null;
            // Switches between the correct control to the filter selected
            // If Genre/Author/Publisher filter selected, Name filtered disable
            // On the opposite SubFilter ComboBox disabled if Name selected
            SubFilter.IsEnabled = true;
            NameFilter.IsEnabled = false;
            if (FiltName.IsSelected == true)
            {
                SubFilter.IsEnabled = false;
                NameFilter.IsEnabled = true;
            }
            else if (FiltGenre.IsSelected == true)
                filteredList = filterManager.GetFilterResultsOfType(filterManager.FilterGenre);
            else if (FiltAuthor.IsSelected == true)
                filteredList = filterManager.GetFilterResultsOfType(filterManager.FilterAuthor);
            else if (FiltName.IsSelected == true)
                filteredList = filterManager.GetFilterResultsOfType(filterManager.FilterName);
            else if (FiltPublisher.IsSelected == true)
                filteredList = filterManager.GetFilterResultsOfType(filterManager.FilterPublisher);
            else if (FiltType.IsSelected == true)
                filteredList = filterManager.GetFilterResultsOfType(filterManager.FilterType);
            if (filteredList != null)
            {
                RefreshSubFilter(filteredList, SubFilter);
            }
        }
        public void RefreshSubFilter(List<string> filterList, ComboBox subFilt)
        {
            foreach (string item in filterList)
            {
                subFilt.Items.Add(item);
            }
        }
        private void SubFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ListViewUser.Items.Clear();
            FilterService filterManager = new FilterService(InventoryStoreManager.Instance.ItemList);

            if (SubFilter.SelectedItem == null) return;

            List<string> filteredItems = filterManager.SubFilterResult(InventoryStoreManager.Instance.ItemList, SubFilter.SelectedItem.ToString());

            if (filteredItems != null)
            {
                foreach (var item in filteredItems)
                {
                    ListViewUser.Items.Add(item);
                }
            }
        }
        public void RefreshItems(ListView listItem, InventoryStoreManager manager)
        {
            listItem.Items.Clear();
            foreach (var item in manager.Items)
            {
                listItem.Items.Add(item.ItemName);
            }
        }
        private void NameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (var item in InventoryStoreManager.Instance.ItemList)
            {
                if (item.ItemName.ToLower().Contains(NameFilter.Text.ToLower()))
                {

                    ListViewUser.Items.Clear();
                    ListViewUser.Items.Add(item.ItemName);
                }
            }
            if (string.IsNullOrEmpty(NameFilter.Text))
            {
                RefreshItems(ListViewUser, InventoryStoreManager.Instance);
            }
        }

        private void ListViewUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewUser.SelectedItem == null) return;

            // Gets the correct book / journal:
            Abstract_Item selectedItem = InventoryStoreManager.Instance.SelectedAbstractItem(InventoryStoreManager.Instance.ItemList, ListViewUser.SelectedItem.ToString());
            if (selectedItem != null)
            {
                DescriptionTB.Text = selectedItem.Description;
                if (selectedItem.ImagePath != null)
                    BookCoverIMG.Source = new BitmapImage(new Uri(selectedItem.ImagePath));
            }
        }

        private void PurchaseItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PurchaseItemDialog();
        }
        private async void PurchaseItemDialog()
        {
            Abstract_Item selectedItem = InventoryStoreManager.Instance.SelectedAbstractItem(InventoryStoreManager.Instance.ItemList, ListViewUser.SelectedItem.ToString());
            ContentDialog purchaseItemDialog = new ContentDialog
            {
                Title = $"Purchase {selectedItem.ItemName} for {selectedItem.PriceAfterDiscount:c} ? ",
                Content = "If you wish to procceed purchase, press Yes. otherwise, go back to menu.",
                PrimaryButtonText = "Yes",
                CloseButtonText = "Back to menu"
            };

            ContentDialogResult result = await purchaseItemDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                if (selectedItem.CopiesAmount > 0)
                {
                    //BaughtItems = new List<Abstract_Item>();
                    //BaughtItems.Add(selectedItem);
                    selectedItem.CopiesAmount--;
                    BaughtItems.Add(selectedItem);
                    Save();
                    this.Frame.Navigate(typeof(PurchaseItem));
                }

                else if (selectedItem.CopiesAmount <= 0)
                {
                    InventoryStoreManager.Instance.RemoveItem(selectedItem);
                    ContentDialog itemInssuficient = new ContentDialog
                    {
                        Title = $"The {selectedItem.ItemType} {selectedItem.ItemName} is no longer available in store. ",
                        Content = "Please choose another item",
                        PrimaryButtonText = "close",

                    };
                    ContentDialogResult closeTab = await itemInssuficient.ShowAsync();
                    if (closeTab == ContentDialogResult.Primary)
                    {
                        this.Frame.Navigate(typeof(StoreIntro));
                    }
                }
            }
            else
            {
                this.Frame.Navigate(typeof(StoreIntro));
            }
        }

        private void LogOut_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}