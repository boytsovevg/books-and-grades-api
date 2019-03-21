using System.Collections.Generic;
using System.Threading.Tasks;
using bag.Modules.Books.Managers.Models;

namespace bag.Modules.Books.Managers
{
    public interface IBooksManager
    {
        Task CreateBookAsync(Book book);
        
        Task<Book> GetBookAsync(int id);

        Task<IEnumerable<Book>> GetBooksAsync();

        Task UpdateBookAsync(int id, Book book);

        Task DeleteBookAsync(int id);

        Task<IEnumerable<BookProgress>> GetBooksProgress(int[] ids);

        Task UpdateBookProgressAsync(int bookId, int pagesCount);
    }
}