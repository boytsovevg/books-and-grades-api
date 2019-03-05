using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bag.Modules.Books.Managers.Models;
using bag.Modules.Books.Repositories.Entities;
using bag.Modules.Books.Repositories.Interfaces;

namespace bag.Modules.Books.Managers
{
    public class BooksManager: IBooksManager
    {
        private readonly IRepository<BookEntity> _booksRepository;

        public BooksManager(IRepository<BookEntity> booksRepository)
        {
            this._booksRepository = booksRepository;
        }

        public async Task CreateBookAsync(BookModel book)
        {
            await this._booksRepository.CreateAsync(ToEntity(book));
        }

        public async Task<BookModel> GetBookAsync(int id)
        {
            return ToModel(await this._booksRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<BookModel>> GetBooksAsync()
        {
            var booksData = await this._booksRepository.GetAllAsync();

            return booksData.Select(ToModel);
        }

        public async Task UpdateBookAsync(int id, BookModel book)
        {
            await this._booksRepository.UpdateAsync(ToEntity(book));
        }

        public async Task DeleteBookAsync(int id)
        {
            await this._booksRepository.DeleteAsync(id);
        }

        private static BookModel ToModel(BookEntity bookEntity)
        {
            return new BookModel
            {
                Id = bookEntity.Id,
                Author = bookEntity.Author,
                CoverUrl = bookEntity.CoverUrl,
                Grade = bookEntity.Grade,
                PagesNumber = bookEntity.PagesNumber,
                Title = bookEntity.Title
            };
        }

        private static BookEntity ToEntity(BookModel bookModel)
        {
            return new BookEntity
            {
                Id = bookModel.Id,
                Author = bookModel.Author,
                CoverUrl = bookModel.CoverUrl,
                Grade = bookModel.Grade,
                PagesNumber = bookModel.PagesNumber,
                Title = bookModel.Title
            };
        }
    }
}