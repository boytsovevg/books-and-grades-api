using System.Collections.Generic;
using System.Linq;
using bag.Modules.Books.API.ViewModels;
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
        public IActionResult CreateBook([FromBody]BookViewModel book)
        {
            this._booksManager.CreateBook(ToModel(book));
            
            return Ok();
        }
        
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var bookData = this._booksManager.GetBook(id);

            if (bookData != null)
            {
                return Ok(new BookViewModel
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
        public IActionResult GetBooks()
        {
            var booksData = this._booksManager.GetBooks().ToList();

            return Ok(
                booksData.Select(data => new BookViewModel
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
        public void UpdateBook(int id, [FromBody]BookViewModel book)
        {
            this._booksManager.UpdateBook(id, ToModel(book));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            this._booksManager.DeleteBook(id);

            return Ok();
        }

        private static BookModel ToModel(BookViewModel bookViewModel)
        {
            return new BookModel
            {
                Id = bookViewModel.Id,
                Author = bookViewModel.Author,
                Title = bookViewModel.Title,
                CoverUrl = bookViewModel.Url,
                Grade = bookViewModel.Grade,
                PagesNumber = bookViewModel.PagesNumber
            };
        }
    }
}