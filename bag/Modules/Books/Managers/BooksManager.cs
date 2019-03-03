using System.Collections.Generic;
using System.Linq;
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

        public void CreateBook(BookModel book)
        {
            this._booksRepository.Create(ToEntity(book));
        }

        public BookModel GetBook(int id)
        {
            return ToModel(this._booksRepository.GetById(id));
        }

        public IEnumerable<BookModel> GetBooks()
        {
            var booksData = this._booksRepository.GetAll().ToList();

            return booksData.Select(ToModel);
        }

        public void UpdateBook(int id, BookModel book)
        {
            this._booksRepository.Update(ToEntity(book));
        }

        public void DeleteBook(int id)
        {
            this._booksRepository.Delete(id);
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