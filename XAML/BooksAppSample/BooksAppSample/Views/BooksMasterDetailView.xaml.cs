using BooksServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;

namespace BooksAppSample.Views
{
    /// <summary>
    /// Interaction logic for BooksMasterDetailView.xaml
    /// </summary>
    public partial class BooksMasterDetailView : UserControl
    {
        public BooksMasterDetailView()
        {
            ViewModel = (Application.Current as App).Container.GetService<BooksMasterDetailViewModel>();
            InitializeComponent();
            DataContext = this;
        }

        public BooksMasterDetailViewModel ViewModel { get; set; }
    }
}
