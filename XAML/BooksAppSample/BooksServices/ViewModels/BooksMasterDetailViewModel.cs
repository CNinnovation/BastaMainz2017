using BooksServices.Events;
using BooksServices.Models;
using BooksServices.Services;
using CNElements.MVVM.Core;
using CNElements.MVVM.ViewModels;
using Microsoft.Extensions.Logging;
using Prism.Events;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksServices.ViewModels
{
    public class BooksMasterDetailViewModel : EditableMasterDetailViewModel<BooksMasterDetailViewModel, BookViewModel, Book>
    {
        private readonly IBooksService _booksService;
        private readonly IEventAggregator _eventAggregator;

        public BooksMasterDetailViewModel(ILoggerFactory loggerFactory, IBooksService booksService, IEventAggregator eventAggregator)
            : base(loggerFactory)
        {
            _booksService = booksService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<RefreshBooksEvent>().Subscribe(() =>
            {
                OnRefresh();
            });
            InitBooks();

            TestCommand = new RelayCommand(() =>
            {
                this.Items.First().Item.Title = "updated";
            });
        }

        public RelayCommand TestCommand { get; }

        public override async Task LoadCoreAsync()
        {
            IEnumerable<Book> books = await _booksService.GetBooksAsync();
            base.SetItemRange(books.Select(book => new BookViewModel(book, _booksService, _eventAggregator)));
        }

        private void InitBooks()
        {
            var book = new Book(0, string.Empty, string.Empty);
            base.SetItemRange(new BookViewModel[] { new BookViewModel(book, _booksService, _eventAggregator, true) });
        }

        public override void OnAddCore()
        {
            var book = new Book(0, "Enter a book title", "Enter a book publisher");
            var bookVM = new BookViewModel(book, _booksService, _eventAggregator, isNew: true);
            this.Items.Add(bookVM);
            this.SelectedItem = bookVM;
        }

    }
}
