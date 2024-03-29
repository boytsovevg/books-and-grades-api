using bag.Modules.Books.API.DTOs;
using bag.Modules.Books.Managers.Models;
using bag.Modules.Books.Repositories.Entities;

namespace bag.Modules.Extensions
{
    public static class BookExtension
    {
        public static Book ToModel(this BookDto bookDto)
        {
            return new Book
            {
                Id = bookDto.Id,
                Author = bookDto.Author,
                Title = bookDto.Title,
                CoverUrl = bookDto.Url,
                Grade = bookDto.Grade,
                PagesNumber = bookDto.PagesCount
            };
        }
        
        public static Book ToModel(this BookEntity bookEntity)
        {
            return new Book
            {
                Id = bookEntity.Id,
                Author = bookEntity.Author,
                CoverUrl = bookEntity.CoverUrl,
                Grade = bookEntity.Grade,
                PagesNumber = bookEntity.PagesNumber,
                Title = bookEntity.Title
            };
        }

        public static BookEntity ToEntity(this Book bookModel)
        {
            return new BookEntity
            {
                Id = bookModel.Id,
                Author = bookModel.Author,
                CoverUrl = bookModel.CoverUrl,
                Grade = bookModel.Grade,
                PagesNumber = bookModel.PagesNumber,
                Title = bookModel.Title
            };
        }

        public static BookDto ToDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Author = bookModel.Author,
                Grade = bookModel.Grade,
                PagesCount = bookModel.PagesNumber,
                Url = bookModel.CoverUrl
            };
        }
    }
}