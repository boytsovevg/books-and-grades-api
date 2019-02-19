using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace bag.Modules.Books
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        [HttpGet]
        public IEnumerable<Book> Books()
        {
            var books = new []
            {
                new Book
                {
                    Id = 1,
                    Title = "45 татуировок менеджера",
                    Author = "Максим Батырев",
                    Url = "https://ozon-st.cdn.ngenix.net/multimedia/1022366551.jpg",
                    Grade = "TeamLead",
                    PagesNumber = 304
                },
                new Book
                {
                    Id = 2,
                    Title = "Чистая архитектура",
                    Author = "Роберт Мартин",
                    Url = "https://ozon-st.cdn.ngenix.net/multimedia/1026061260.jpg",
                    Grade = "FrontendDeveloper",
                    PagesNumber = 352
                },
                new Book
                {
                    Id = 3,
                    Title = "Будь лучшей версией себя",
                    Author = "Дэн Вальдшмидт",
                    Url = "https://ozon-st.cdn.ngenix.net/multimedia/1025400937.jpg",
                    Grade = "TeamLead",
                    PagesNumber = 208
                },
                new Book
                {
                    Id = 4,
                    Title = "Просто космос",
                    Author = "Катерина Ленгольд",
                    Url = "https://ozon-st.cdn.ngenix.net/multimedia/1025475624.jpg",
                    Grade = "FrontendDeveloper",
                    PagesNumber = 160
                },
                new Book
                {
                    Id = 5,
                    Title = "Путь программиста",
                    Author = "Джон Сонмез",
                    Url = "https://ozon-st.cdn.ngenix.net/multimedia/1013663461.jpg",
                    Grade = "FrontendDeveloper",
                    PagesNumber = 448
                },
                new Book
                {
                    Id = 6,
                    Title = "Думай как математик",
                    Author = "Барбара Оакли",
                    Url = "https://opt-407193.ssl.1c-bitrix-cdn.ru/upload/resize_cache/iblock/915/380_567_1/915bb117e40b154d371c6ddff7a390ef.jpg?153252402453797",
                    Grade = "FrontendDeveloper",
                    PagesNumber = 288
                },
                new Book
                {
                    Id = 7,
                    Title = "Элегантные объекты",
                    Author = "Егор Бугаенко",
                    Url = "https://ozon-st.cdn.ngenix.net/multimedia/1023618704.jpg",
                    Grade = "FrontendDeveloper",
                    PagesNumber = 240
                },
                new Book
                {
                    Id = 9,
                    Title = "Илон Маск",
                    Author = "Эшли Вэнс",
                    Url = "https://ozon-st.cdn.ngenix.net/multimedia/1023964254.jpg",
                    Grade = "TeamLead",
                    PagesNumber = 416
                },
                new Book
                {
                    Id = 10,
                    Title = "Microsoft .NET = Архитектура корпоративных приложений",
                    Author = "Дино Эспозито, Андреа Сальтарелло",
                    Url = "https://ozon-st.cdn.ngenix.net/multimedia/1013942325.jpg",
                    Grade = "FrontendDeveloper",
                    PagesNumber = 432
                },
                new Book
                {
                    Id = 11,
                    Title = "Принцип пирамиды Минто. Золотые правила мышления, делового письма и устных выступлений",
                    Author = "Барбара Минто",
                    Url = "https://ozon-st.cdn.ngenix.net/multimedia/1021964317.jpg",
                    Grade = "TeamLead",
                    PagesNumber = 272
                },
                new Book
                {
                    Id = 13,
                    Title = "Scrum. Революционный метод управления проектами",
                    Author = "Джефф Сазерленд",
                    Url = "https://ozon-st.cdn.ngenix.net/multimedia/1019253785.jpg",
                    Grade = "TeamLead",
                    PagesNumber = 288
                },
                new Book
                {
                    Id = 14,
                    Title = "Как привести дела в порядок. Искусство продуктивности без стресса",
                    Author = "Дэвид Аллен",
                    Url = "https://www.mann-ivanov-ferber.ru/assets/images/covers/97/16097/1.00x-thumb.png",
                    Grade = "TeamLead",
                    PagesNumber = 416
                },
            };

            return books;
        }
    }
}