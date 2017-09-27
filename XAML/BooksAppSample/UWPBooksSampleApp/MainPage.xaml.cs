using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPBooksSampleApp.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPBooksSampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnNavigationViewLoaded(object sender, RoutedEventArgs e)
        {
            NavigationView.MenuItems.Add(
                new NavigationViewItem()
                {
                    Content = "Books",
                    Icon = new SymbolIcon(Symbol.List),
                    Tag = "books"
                });
            NavigationView.MenuItems.Add(
                new NavigationViewItem()
                {
                    Content = "Pictures",
                    Icon = new SymbolIcon(Symbol.Pictures),
                    Tag = "pictures"
                });
        }

        private void OnNavigationItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            //switch ((args.InvokedItem as NavigationViewItem).Tag)
            //{
            //    case "books":
            //        ContentFrame.Navigate(typeof(BooksMasterDetailPage));
            //        break;
            //    case "pictures":
            //        break;
            //    default:
            //        break;
            //}

            switch (args.InvokedItem)
            {
                case "Books":
                    ContentFrame.Navigate(typeof(BooksMasterDetailPage));
                    break;
                case "Pictures":
                    ContentFrame.Navigate(typeof(PicturesPage));
                    break;
                default:
                    break;
            }
        }
    }
}
