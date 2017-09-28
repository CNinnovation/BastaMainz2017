using BooksServices.Events;
using BooksServices.Models;
using BooksServices.Services;
using CNElements.MVVM.ViewModels;
using Prism.Events;
using System;
using System.Threading.Tasks;

namespace BooksServices.ViewModels
{
    public class BookViewModel : ItemViewModel<Book>
    {
        private readonly IBooksService _booksService;
        private readonly IEventAggregator _eventAggregator;
        public BookViewModel(Book book, IBooksService booksService, IEventAggregator eventAggregator, bool isNew = false)
            : base(book, isNew)
        {
            _booksService = booksService;
            _eventAggregator = eventAggregator;
        }

        public override async Task OnDeleteCoreAsync()
        {
            await _booksService.DeleteBookAsync(this.Item);
            _eventAggregator.GetEvent<RefreshBooksEvent>().Publish();
        }

        protected override async Task OnSaveCoreAsync()
        {
            try
            {
                if (IsNew)
                {
                    await _booksService.AddBookAsync(Item);
                }
                else
                {
                    await _booksService.UpdateBookAsync(Item);
                }
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
        }

        protected override Task OnCancelCoreAsync()
        {
            _eventAggregator.GetEvent<RefreshBooksEvent>().Publish();
            return Task.CompletedTask;
        }
    }
}
