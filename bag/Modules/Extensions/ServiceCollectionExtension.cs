using bag.Modules.Books.Managers;
using bag.Modules.Books.Repositories;
using bag.Modules.Books.Repositories.Entities;
using bag.Modules.Books.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace bag.Modules.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddBookDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IBooksManager, BooksManager>();
            serviceCollection.AddSingleton<IRepository<BookEntity>, BooksRepository>();
        } 
    }
}