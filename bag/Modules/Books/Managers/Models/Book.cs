namespace bag.Modules.Books.Managers.Models
{
    public class Book
    {
        public int? Id { get; set; }
        
        public string Title { get; set; }
        
        public string Author { get; set; }

        public string CoverUrl { get; set; }

        public string Grade { get; set; }

        public int PagesNumber { get; set; }
    }
}