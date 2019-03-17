using System.Collections.Generic;
using System.Threading.Tasks;
using bag.Modules.Books.Managers.Models;

namespace bag.Modules.Books.Managers
{
    public interface IBooksManager
    {
        Task CreateBookAsync(BookModel book);
        
        Task<BookModel> GetBookAsync(int id);

        Task<IEnumerable<BookModel>> GetBooksAsync();

        Task UpdateBookAsync(int id, BookModel book);

        Task DeleteBookAsync(int id);

        Task UpdateBookProgressAsync(int bookId, int pagesCount);
    }
}