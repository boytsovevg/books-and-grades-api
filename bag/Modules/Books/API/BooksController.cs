using System.Linq;
using System.Threading.Tasks;
using bag.Modules.Books.API.DTOs;
using bag.Modules.Books.Managers;
using bag.Modules.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace bag.Modules.Books.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBooksManager _booksManager;
        
        public BooksController(IBooksManager booksManager)
        {
            this._booksManager = booksManager;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody]BookDto book)
        {
            await this._booksManager.CreateBookAsync(book.ToModel());
            
            return Ok();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var bookData = await this._booksManager.GetBookAsync(id);

            if (bookData != null)
            {
                return Ok(bookData.ToDto());
            }
            
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var booksData = await this._booksManager.GetBooksAsync();

            return Ok(
                booksData.Select(data => data.ToDto())
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody]BookDto book)
        {
            await this._booksManager.UpdateBookAsync(id, book.ToModel());

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await this._booksManager.DeleteBookAsync(id);

            return Ok();
        }
    }
}