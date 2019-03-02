using System;
using bag.Modules.Books.Repositories.Entities;
using bag.Modules.Books.Repositories.Interfaces;

namespace bag.Modules.Books.Managers
{
    public class BooksManager
    {
        private readonly IRepository<BookEntity> _booksRepository;

        public BooksManager(IRepository<BookEntity> booksRepository)
        {
            this._booksRepository = booksRepository;
        }

        public BookEntity GetBook(int id)
        {
            return this._booksRepository.GetById(id);
        }
    }
}