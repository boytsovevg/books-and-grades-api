using System;
using bag.Modules.Books.Repositories.Entities;

namespace bag.Modules.Books.Repositories.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        void Create(T item);
        
        T GetById(Guid id);
        
        T Update(T item);
        
        void Delete(Guid id);

        IEquatable<T> GetAll();
    }
}