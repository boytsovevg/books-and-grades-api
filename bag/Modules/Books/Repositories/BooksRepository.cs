using System;
using bag.Modules.Books.Repositories.Entities;
using bag.Modules.Books.Repositories.Interfaces;

namespace bag.Modules.Books.Repositories
{
    public class BooksRepository: IRepository<BookEntity>
    {
        public void Create(BookEntity item)
        {
            throw new NotImplementedException();
        }

        public BookEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public BookEntity Update(BookEntity item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEquatable<BookEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}