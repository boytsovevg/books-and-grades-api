using System;
using System.Collections.Generic;
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
        private IRepository<BookEntity> _booksRepository;
        public BooksController(IConfiguration configuration)
        {
            this._booksRepository = new BooksRepository(configuration);
        }
        
        [HttpGet("{id}")]
        public BookViewModel Book(int id)
        {
            var bookData = this._booksRepository.GetById(id);
            
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

        [HttpGet]
        public IEnumerable<BookViewModel> Books()
        {
            var books = new List<BookViewModel>();

            return books;
        }
    }
}