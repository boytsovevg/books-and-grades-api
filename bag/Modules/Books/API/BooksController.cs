using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bag.Modules.Books.API.DTOs;
using bag.Modules.Books.Managers;
using bag.Modules.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace bag.Modules.Books.API
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBooksManager _booksManager;
        
        public BooksController(IBooksManager booksManager)
        {
            _booksManager = booksManager;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody]BookDto book)
        {
            await _booksManager.CreateBookAsync(book.ToModel());
            
            return Ok();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var bookData = await _booksManager.GetBookAsync(id);

            if (bookData != null)
            {
                return Ok(bookData.ToDto());
            }
            
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var booksData = await _booksManager.GetBooksAsync();

            return Ok(
                booksData.Select(data => data.ToDto())
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody]BookDto book)
        {
            await _booksManager.UpdateBookAsync(id, book.ToModel());

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _booksManager.DeleteBookAsync(id);

            return Ok();
        }

        [HttpGet]
        [Route("progress")]
        public async Task<IActionResult> GetBooksProgress([FromQuery(Name = "ids")]int[] ids)
        {
            var booksProgress = await _booksManager.GetBooksProgress(ids);

            return Ok(booksProgress.Select(progress => progress.ToDto()));
        }
        
        [HttpPatch("{bookId}/progress")]
        public async Task<IActionResult> UpdateProgress(int bookId, [FromBody]BookProgressDto bookProgress)
        {
            await _booksManager.UpdateBookProgressAsync(bookId, bookProgress.PagesCount);
            
            return Ok();
        }
    }
}