using System.Collections.Generic;
using bag.Modules.Books.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bag.Modules.Books.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        public BooksController()
        {
            
        }
        
        [HttpGet]
        public IEnumerable<BookViewModel> Books()
        {
            var books = new List<BookViewModel>();

            return books;
        }
    }
}