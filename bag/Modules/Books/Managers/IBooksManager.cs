using System.Collections.Generic;
using bag.Modules.Books.Managers.Models;

namespace bag.Modules.Books.Managers
{
    public interface IBooksManager
    {
        void CreateBook(BookModel book);
        
        BookModel GetBook(int id);

        IEnumerable<BookModel> GetBooks();

        void UpdateBook(int id, BookModel book);

        void DeleteBook(int id);
    }
}