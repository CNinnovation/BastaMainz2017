using CNElements.MVVM.Core;

namespace BooksServices.Models
{
    public class Book : Observable
    {
        public Book(int bookId, string title, string publisher)
        {
            BookId = bookId;
            Title = title;
            Publisher = publisher;
        }
        public int BookId { get; }

        private string _title;
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private string _publisher;
        public string Publisher
        {
            get => _publisher;
            set => Set(ref _publisher, value);
        }

        public override string ToString() => Title;
    }
}
