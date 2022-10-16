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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BookStoreUi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BookDescription : Page
    {
        
        public BookDescription()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private void Back_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StoreIntro));
        }

        private void Purchase_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PurchaseItemDialog();
        }
        private async void PurchaseItemDialog()
        {
            ContentDialog purchaseItemDialog = new ContentDialog
            {
                Title = $"Purchase -here will be the book name- for -here will be the book price-?",
                Content = "If you wish to procceed purchase, press Yes. otherwise, go back to menu.",
                PrimaryButtonText = "Yes",
                CloseButtonText = "Back to menu"
            };

            ContentDialogResult result = await purchaseItemDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                this.Frame.Navigate(typeof(PurchaseItem));
            }
            else
            {
                this.Frame.Navigate(typeof(BookDescription));
            }
        }
    }
}
