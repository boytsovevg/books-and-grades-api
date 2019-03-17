namespace bag.Modules.Books.API.DTOs
{
    public class BookDto
    {
        public int? Id { get; set; }
        
        public string Title { get; set; }
        
        public string Author { get; set; }

        public string Url { get; set; }

        public string Grade { get; set; }

        public int PagesCount { get; set; }
    }
}