using System.Collections.Generic;
using System.Threading.Tasks;

namespace CNElements.MVVM.Networking
{
    public interface IHttpHelper<T>
    {
        Task<T> GetItemAsync(string url);
        Task<IEnumerable<T>> GetItemsAsync(string url);
        Task<T> AddItemAsync(string url, T item);
        Task UpdateItemAsync(string url, T item);
        Task<T> DeleteItemAsync(string url);
    }
}
