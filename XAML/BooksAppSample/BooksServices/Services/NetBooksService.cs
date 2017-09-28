using BooksServices.Models;
using CNElements.MVVM.Networking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksServices.Services
{
    public class NetBooksService : IBooksService
    {
        private readonly IHttpHelper<Book> _httpClient;
        private readonly string _booksUrl;
        public NetBooksService(IHttpHelper<Book> httpClient, IConfigurationService configurationService)
        {
            _httpClient = httpClient;
            _booksUrl = configurationService.BookServiceUrl;
        }
        public Task<Book> AddBookAsync(Book book)
        {
            return _httpClient.AddItemAsync(_booksUrl, book);
        }

        public Task<Book> DeleteBookAsync(Book book)
        {
            return _httpClient.DeleteItemAsync($"{_booksUrl}/{book.BookId}");
        }

        public Task<Book> GetBookAsync(int id)
        {
            return _httpClient.GetItemAsync($"{_booksUrl}/{id}");
        }

        public Task<IEnumerable<Book>> GetBooksAsync()
        {
            return _httpClient.GetItemsAsync($"{_booksUrl}");
        }

        public Task<IEnumerable<Book>> GetBooksByPublisher(string publisher)
        {
            return _httpClient.GetItemsAsync($"{_booksUrl}/publisher/{publisher}");
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            await _httpClient.UpdateItemAsync($"{_booksUrl}/{book.BookId}", book);
            return book;
        }
    }
}
