using bag.Modules.Books.API.DTOs;
using bag.Modules.Books.Managers.Models;
using bag.Modules.Books.Repositories.Entities;

namespace bag.Modules.Extensions
{
    public static class BookProgressExtension
    {
        public static BookProgressDto ToDto(this BookProgress bookProgress)
        {
            return new BookProgressDto
            {
                BookId = bookProgress.BookId,
                PagesCount = bookProgress.PagesCount
            };
        }

        public static BookProgress ToModel(this BookProgressEntity bookProgressEntity)
        {
            return new BookProgress
            {
                BookId = bookProgressEntity.BookId,
                PagesCount = bookProgressEntity.PagesCount
            };
        }
    }
}