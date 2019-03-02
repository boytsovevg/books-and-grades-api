using System.Collections.Generic;
using bag.Modules.Books.Repositories.Entities;

namespace bag.Modules.Books.Repositories.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        void Create(T item);
        
        T GetById(int id);
        
        void Update(T item);
        
        void Delete(int id);

        IEnumerable<T> GetAll();
    }
}