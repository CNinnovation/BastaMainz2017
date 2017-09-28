using BooksServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksServices.Services
{
    public class SampleBooksService : IBooksService
    {
        private List<Book> _books = new List<Book>();

        public SampleBooksService()
        {
            InitBooks();
        }

        private void InitBooks()
        {
            var b1 = new Book(1, "Professional C# 6", "Wrox Press");
            var b2 = new Book(2, "Beginning Visual C#", "Wrox Press");
            var b3 = new Book(3, "Enterprise Services", "AWL");
            _books.Clear();
            _books.AddRange(new Book[]{ b1, b2, b3});
        }

        public Task<Book> AddBookAsync(Book book)
        {
            _books.Add(book);
            return Task.FromResult(book);
        }

        public Task<Book> DeleteBookAsync(Book book)
        {
            if (!_books.Contains(book)) return Task.FromResult(book);

            _books.Remove(book);
            return Task.FromResult(book);
        }

        public Task<Book> GetBookAsync(int id) =>
            Task.FromResult(_books.SingleOrDefault(b => b.BookId == id));

        public Task<IEnumerable<Book>> GetBooksAsync() =>
            Task.FromResult<IEnumerable<Book>>(_books);

        public Task<IEnumerable<Book>> GetBooksByPublisher(string publisher) =>
            Task.FromResult<IEnumerable<Book>>(_books.Where(b => b.Publisher == publisher));

        public Task<Book> UpdateBookAsync(Book book)
        {
            Book orig = _books.SingleOrDefault(b => b.BookId == book.BookId);
            if (orig == null) return Task.FromResult<Book>(null);
            int index = _books.IndexOf(orig);
            _books[index] = book;
            return Task.FromResult(book);
        }
    }
}
