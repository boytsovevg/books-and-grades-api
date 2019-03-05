using System.Linq;
using System.Threading.Tasks;
using bag.Modules.Books.API.DTOs;
using bag.Modules.Books.Managers;
using bag.Modules.Books.Managers.Models;
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
            await this._booksManager.CreateBookAsync(ToModel(book));
            
            return Ok();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var bookData = await this._booksManager.GetBookAsync(id);

            if (bookData != null)
            {
                return Ok(new BookDto
                {
                    Id = bookData.Id,
                    Title = bookData.Title,
                    Author = bookData.Author,
                    Grade = bookData.Grade,
                    PagesNumber = bookData.PagesNumber,
                    Url = bookData.CoverUrl
                });
            }
            
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var booksData = await this._booksManager.GetBooksAsync();

            return Ok(
                booksData.Select(data => new BookDto
                {
                    Id = data.Id,
                    Title = data.Title,
                    Author = data.Author,
                    Grade = data.Grade,
                    PagesNumber = data.PagesNumber,
                    Url = data.CoverUrl
                })
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody]BookDto book)
        {
            await this._booksManager.UpdateBookAsync(id, ToModel(book));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await this._booksManager.DeleteBookAsync(id);

            return Ok();
        }

        private static BookModel ToModel(BookDto bookDto)
        {
            return new BookModel
            {
                Id = bookDto.Id,
                Author = bookDto.Author,
                Title = bookDto.Title,
                CoverUrl = bookDto.Url,
                Grade = bookDto.Grade,
                PagesNumber = bookDto.PagesNumber
            };
        }
    }
}