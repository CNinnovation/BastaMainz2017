using BooksServices.Services;
using System.Threading.Tasks;
using System.Windows;

namespace BooksAppSample.WPFServices
{
    public class WPFDialogService : IDialogService
    {
        public Task ShowMessageAsync(string message)
        {
            MessageBox.Show(message);
            return Task.CompletedTask;
        }
    }
}
