using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bag.Modules.Books.Managers.Models;
using bag.Modules.Books.Repositories.Interfaces;
using bag.Modules.Extensions;

namespace bag.Modules.Books.Managers
{
    public class BooksManager: IBooksManager
    {
        private readonly IBooksRepository _booksRepository;

        public BooksManager(IBooksRepository booksRepository)
        {
            this._booksRepository = booksRepository;
        }

        public async Task CreateBookAsync(BookModel book)
        {
            await this._booksRepository.CreateAsync(book.ToEntity());
        }

        public async Task<BookModel> GetBookAsync(int id)
        {
            var bookEntity = await this._booksRepository.GetByIdAsync(id);

            return bookEntity.ToModel();
        }

        public async Task<IEnumerable<BookModel>> GetBooksAsync()
        {
            var booksData = await this._booksRepository.GetAllAsync();

            return booksData.Select(data => data.ToModel());
        }

        public async Task UpdateBookAsync(int id, BookModel book)
        {
            await this._booksRepository.UpdateAsync(book.ToEntity());
        }

        public async Task DeleteBookAsync(int id)
        {
            await this._booksRepository.DeleteAsync(id);
        }

        public async Task UpdateBookProgressAsync(int bookId, int pagesCount)
        {
            await this._booksRepository.UpdateBookProgressAsync(bookId, pagesCount);
        }
    }
}