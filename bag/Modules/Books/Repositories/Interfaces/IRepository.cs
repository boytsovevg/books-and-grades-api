using System.Collections.Generic;
using System.Threading.Tasks;
using bag.Modules.Books.Repositories.Entities;

namespace bag.Modules.Books.Repositories.Interfaces
{
    public interface IRepository<T> where T: IEntity
    {
        Task CreateAsync(T item);
        
        Task<T> GetByIdAsync(int id);
        
        Task UpdateAsync(T item);
        
        Task DeleteAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();
    }
}