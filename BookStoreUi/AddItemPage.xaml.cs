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
using Windows.UI;
using Items_Manager.Enums;
using ImageLogic;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BookStoreUi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddItemPage : Page
    {

        private ImageManager imageMng = new ImageManager();
        private string imagePath;
        public AddItemPage()
        {
            this.InitializeComponent();

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = ItemName.Text;
            string type = ItemTypeComBox.SelectedIndex.ToString();
            string author = Author.Text;
            string publisher = Publisher.Text;
            Genre genre = (Genre)GenreCombox.SelectedIndex;
            int publishYear = int.Parse(PublishYear.Text);
            if (imagePath == null)
            {
                imagePath = "ms-appx:///Assets/NoImage.png";
            }
            double buyingPrice = double.Parse(ItemPrice.Text);
            long isbn = long.Parse(ISBN.Text);
            int copiesAmount = int.Parse(Amount.Text);
            int version = int.Parse(Version.Text);
            try
            {
                InventoryStoreManager.Instance.AddItem(name, type, author, publisher, genre, publishYear, imagePath, buyingPrice, isbn, copiesAmount, version);
            }
            catch (NullReferenceException nullExc)
            {
                nullExc.Message.ToString();
            }
            AddedItemDialog();
        }
        private async void AddedItemDialog()
        {
            ContentDialog addedItemDialog = new ContentDialog
            {
                Title = $"'{ItemName.Text}' was added secssfully to the inventory!",
                Content = "Click on 'Continue' to procceed.",
                PrimaryButtonText = "Continue",

            };
            ContentDialogResult result = await addedItemDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                this.Frame.Navigate(typeof(InventoryPage));
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InventoryPage));
        }

        private async void AddImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string browseFilePath = await imageMng.FileBrowserAsync();
            if (browseFilePath == null) return;
            imagePath = browseFilePath;
            ImgPreview.Source = new BitmapImage(new Uri(imagePath));
        }
    }
}