using BooksServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace UWPBooksSampleApp.UWPServices
{
    public class UWPDialogService : IDialogService
    {
        public async Task ShowMessageAsync(string message)
        {
            await new MessageDialog(message).ShowAsync();
        }
    }
}
