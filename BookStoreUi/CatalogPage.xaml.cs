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
using InventoryManager;
using Items_Manager;
using Windows.UI.Xaml.Media.Imaging;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BookStoreUi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CatalogPage : Page
    {
        //List<Abstract_Item> _baughtItems = StoreIntro.BaughtItems;

        public CatalogPage()
        {
            this.InitializeComponent();
            GridView.ItemsSource = InventoryStoreManager.Instance.ItemList;

        }



        private void BackToMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StoreIntro));
        }

        private void Exit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void GridView_ItemClicked(object sender, ItemClickEventArgs e)
        {
            if (GridView.SelectedItem == null) return;

            // Gets the correct book / journal:
            Abstract_Item selectedItem = InventoryStoreManager.Instance.SelectedAbstractItem(InventoryStoreManager.Instance.ItemList, GridView.SelectedItem.ToString());
            if (selectedItem != null)
            {
                DescriptionTB.Text = selectedItem.Description;
                if (selectedItem.ImagePath != null)
                    BookCoverIMG.Source = new BitmapImage(new Uri(selectedItem.ImagePath));
            }
        }

        private void PurchaseItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (GridView.SelectedItem == null) return;
            Abstract_Item selectedItem = InventoryStoreManager.Instance.SelectedAbstractItem(InventoryStoreManager.Instance.ItemList, GridView.SelectedItem.ToString());
            if (selectedItem != null)
            {
                PurchaseItemDialog();
            }

        }
        private async void PurchaseItemDialog()
        {
            Abstract_Item selectedItem = InventoryStoreManager.Instance.SelectedAbstractItem(InventoryStoreManager.Instance.ItemList, GridView.SelectedItem.ToString());
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
                //_baughtItems.Add(selectedItem);
                if (selectedItem.CopiesAmount > 0)
                {
                    selectedItem.CopiesAmount--;
                    StoreIntro.BaughtItems.Add(selectedItem);
                    this.Frame.Navigate(typeof(PurchaseItem));
                }
                else
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
                        this.Frame.Navigate(typeof(CatalogPage));
                    }
                }
            }
            else
            {
                this.Frame.Navigate(typeof(CatalogPage));
            }
        }
    }


}