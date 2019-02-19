namespace bag.Modules.Books
{
    public class Book
    {
        public int? Id { get; set; }
        
        public string Title { get; set; }
        
        public string Author { get; set; }

        public string Url { get; set; }

        public string Grade { get; set; }

        public string BookType { get; set; } = "Print";

        public int PagesNumber { get; set; }
    }
}