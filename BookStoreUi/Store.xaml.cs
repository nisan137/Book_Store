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
using Windows.UI.Xaml.Navigation;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BookStoreUi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Store : Page
    {
        public Store()
        {
            this.InitializeComponent();
        }

        private void Filter_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void ViewMore_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void BookSelected_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Exit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void EditInventory_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void ProduceReports_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
