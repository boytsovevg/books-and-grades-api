namespace bag.Modules.Books.API.ViewModels
{
    public class BookViewModel
    {
        public int? Id { get; set; }
        
        public string Title { get; set; }
        
        public string Author { get; set; }

        public string Url { get; set; }

        public string Grade { get; set; }

        public int PagesNumber { get; set; }
    }
}