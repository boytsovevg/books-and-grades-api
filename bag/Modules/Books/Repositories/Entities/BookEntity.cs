using System;
using System.ComponentModel.DataAnnotations;

namespace bag.Modules.Books.Repositories.Entities
{
    public class BookEntity: BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string CoverUrl { get; set; }

        [Required]
        public string Grade { get; set; }

        [Required]
        public int PagesNumber { get; set; }
    }
}