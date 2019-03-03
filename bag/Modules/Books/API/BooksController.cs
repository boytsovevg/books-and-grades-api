using System.Collections.Generic;
using System.Linq;
using bag.Modules.Books.API.ViewModels;
using bag.Modules.Books.Repositories;
using bag.Modules.Books.Repositories.Entities;
using bag.Modules.Books.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace bag.Modules.Books.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IRepository<BookEntity> _booksRepository;
        
        public BooksController(IRepository<BookEntity> booksRepository)
        {
            this._booksRepository = booksRepository;
        }


        [HttpPost]
        public void CreateBook([FromBody]BookViewModel book)
        {
            var bookData = new BookEntity
            {
                Author = book.Author,
                Title = book.Title,
                CoverUrl = book.Url,
                Grade = book.Grade,
                PagesNumber = book.PagesNumber ?? 0
            };
            
            this._booksRepository.Create(bookData);
        }
        
        [HttpGet("{id}")]
        public BookViewModel GetBook(int id)
        {
            var bookData = this._booksRepository.GetById(id);

            if (bookData != null)
            {
                return new BookViewModel
                {
                    Id = bookData.Id,
                    Title = bookData.Title,
                    Author = bookData.Author,
                    Grade = bookData.Grade,
                    PagesNumber = bookData.PagesNumber,
                    Url = bookData.CoverUrl
                };
            }
            
            return new BookViewModel();
        }

        [HttpGet]
        public IEnumerable<BookViewModel> GetBooks()
        {
            var booksData = this._booksRepository.GetAll().ToList();

            return booksData
                .Select(data => new BookViewModel
                {
                    Id = data.Id,
                    Title = data.Title,
                    Author = data.Author,
                    Grade = data.Grade,
                    PagesNumber = data.PagesNumber,
                    Url = data.CoverUrl
                });
        }

        [HttpPut("{id}")]
        public void UpdateBook(int id, [FromBody]BookViewModel book)
        {
            var bookData = this._booksRepository.GetById(id);

            if (bookData != null)
            {
                bookData.Title = book.Title ?? bookData.Title;
                bookData.Author = book.Author ?? bookData.Author;
                bookData.CoverUrl = book.Url ?? bookData.CoverUrl;
                bookData.Grade = book.Grade ?? bookData.Grade;
                bookData.PagesNumber = book.PagesNumber ?? bookData.PagesNumber;
            }
            
            this._booksRepository.Update(bookData);
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            this._booksRepository.Delete(id);
        }
    }
}