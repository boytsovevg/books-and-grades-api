using System.Collections.Generic;
using System.Threading.Tasks;
using bag.Modules.Books.Repositories.Entities;

namespace bag.Modules.Books.Repositories.Interfaces
{
    public interface IBooksRepository: IRepository<BookEntity>
    {
        Task<BookProgressEntity> GetBookProgressAsync(int bookId);
        Task<IEnumerable<BookProgressEntity>> GetBooksProgressAsync(int[] bookIds);
        Task UpdateBookProgressAsync(int bookId, int pagesCount);
    }
}