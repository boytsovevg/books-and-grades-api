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
            _booksRepository = booksRepository;
        }

        public async Task CreateBookAsync(Book book)
        {
            await _booksRepository.CreateAsync(book.ToEntity());
        }

        public async Task<Book> GetBookAsync(int id)
        {
            var bookEntity = await _booksRepository.GetByIdAsync(id);

            return bookEntity.ToModel();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var booksData = await _booksRepository.GetAllAsync();

            return booksData.Select(data => data.ToModel());
        }

        public async Task UpdateBookAsync(int id, Book book)
        {
            await _booksRepository.UpdateAsync(book.ToEntity());
        }

        public async Task DeleteBookAsync(int id)
        {
            await _booksRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BookProgress>> GetBooksProgress(int[] ids)
        {
            var booksProgressData = await _booksRepository.GetBooksProgressAsync(ids);

            return booksProgressData.Select(data => data.ToModel());
        }

        public async Task UpdateBookProgressAsync(int bookId, int pagesCount)
        {
            await _booksRepository.UpdateBookProgressAsync(bookId, pagesCount);
        }
    }
}