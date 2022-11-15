using InventoryManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Data;
using Items_Manager;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookStoreUi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InventoryPage : Page
    {

        public InventoryPage()
        {
            this.InitializeComponent();
            InventoryData.ItemsSource = InventoryStoreManager.Instance.GetObservableItemCollection();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            InventoryData.ItemsSource = InventoryStoreManager.Instance.GetObservableItemCollection();
        }

        private void AddItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddItemPage));
        }

        private void BackToMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StoreIntro));
        }

        private void RemoveItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            RemovedItemDialog();
        }
        private async void RemovedItemDialog()
        {
            ContentDialog removededItemDialog = new ContentDialog
            {
                Title = $" Do you wish to remove '{InventoryData.SelectedItem.ToString()}' from the inventory?",
                Content = "Click 'Yes' to procceed.",
                PrimaryButtonText = "Yes",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await removededItemDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                InventoryStoreManager.Instance.RemoveItem((Abstract_Item)InventoryData.SelectedItem);
                InventoryData.ItemsSource = InventoryStoreManager.Instance.GetObservableItemCollection();
            }
            else
            {
                this.Frame.Navigate(typeof(InventoryPage));
            }
        }

        private void AddDiscount_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DiscountPage));
        }
    }
}