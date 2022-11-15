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
using Items_Manager.Enums;
using System.Net;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BookStoreUi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DiscountPage : Page
    {
        public DiscountPage()
        {
            this.InitializeComponent();
            DiscountGridView.ItemsSource = DiscountManager.Instance.DiscountList;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            double Percentage = double.Parse(DiscountPercentage.Text);
            DiscountBy type = (DiscountBy)ListViewDiscount.SelectedIndex;
            string valueOfType = SubFilter.SelectedItem.ToString();

            DiscountManager.Instance.AddNewDiscount(Percentage, type, valueOfType);
            DiscountContentDialog();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InventoryPage));
        }



        private void ListViewFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterService filterManager = new FilterService(InventoryStoreManager.Instance.ItemList);
            SubFilter.Items.Clear();
            List<string> filteredList = null;

            SubFilter.IsEnabled = true;

            if (FiltGenre.IsSelected == true)
                filteredList = filterManager.GetFilterResultsOfType(filterManager.FilterGenre);
            else if (FiltAuthor.IsSelected == true)
                filteredList = filterManager.GetFilterResultsOfType(filterManager.FilterAuthor);
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
            if (SubFilter.SelectedItem == null) return;
            //double Percentage = double.Parse(DiscountPercentage.Text);
            //DiscountBy type = (DiscountBy)ListViewDiscount.SelectedItem;
            //string valueOfType = SubFilter.SelectedItem.ToString();

            //InventoryStoreManager.Instance.CreateNewDiscount(Percentage, type, valueOfType);

        }
        private async void DiscountContentDialog()
        {
            ContentDialog DiscountContentDialog = new ContentDialog
            {
                Title = $"Discount by '{(DiscountBy)ListViewDiscount.SelectedIndex}' - '{SubFilter.SelectedItem.ToString()}' was added secssfully to the Discounts list!",
                Content = "Click on 'Continue' to procceed.",
                PrimaryButtonText = "Continue",
            };
            ContentDialogResult result = await DiscountContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                this.Frame.Navigate(typeof(DiscountPage));
            }
        }

        private void RemoveDiscount_Click(object sender, RoutedEventArgs e)
        {
            RemovedDiscountDialog();
        }
        private async void RemovedDiscountDialog()
        {
            ContentDialog removedDiscountDialog = new ContentDialog
            {
                Title = $" Do you wish to remove this discount from the Discount list?",
                Content = "Click 'Yes' to procceed.",
                PrimaryButtonText = "Yes",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await removedDiscountDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                DiscountManager.Instance.RemoveDiscount((Discount)(DiscountGridView.SelectedItem));
                this.Frame.Navigate(typeof(DiscountPage));
            }
            else
            {
                this.Frame.Navigate(typeof(DiscountPage));
            }
        }
    }
}