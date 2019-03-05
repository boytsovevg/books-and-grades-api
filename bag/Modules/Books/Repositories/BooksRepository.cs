using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using bag.Modules.Books.Repositories.Entities;
using bag.Modules.Books.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace bag.Modules.Books.Repositories
{
    public class BooksRepository: IRepository<BookEntity>
    {
        private readonly string _connectionString;

        public BooksRepository(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("PgSql");
        }

        public async Task CreateAsync(BookEntity item)
        {
            using (IDbConnection dbConnection = GetNewDbConnection())
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync(
                    @"INSERT INTO book
                                 (title, author, coverUrl, grade, pagesNumber)
                            VALUES
                                 (@Title, @Author, @CoverUrl, @Grade, @PagesNumber)",
                    item
                );
            }
        }

        public async Task<BookEntity> GetByIdAsync(int id)
        {
            using (IDbConnection dbConnection = GetNewDbConnection())
            {
                dbConnection.Open();
                var booksData = await dbConnection.QueryAsync<BookEntity>(
                    @"SELECT * FROM book WHERE id = @Id", new { Id = id }
                );

                return booksData.FirstOrDefault();
            }
        }

        public async Task UpdateAsync(BookEntity item)
        {
            using (IDbConnection dbConnection = GetNewDbConnection())
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync(@"
                    UPDATE book
                    SET 
                        title = @Title,
                        author = @Author,
                        grade = @Grade,
                        pagesNumber = @PagesNumber,
                        coverUrl = @CoverUrl
                    WHERE id = @Id
                ", item);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (IDbConnection dbConnection = GetNewDbConnection())
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync(
                    @"DELETE FROM book WHERE id = @Id", new { Id = id }
                );
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync()
        {
            using (IDbConnection dbConnection = GetNewDbConnection())
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<BookEntity>(
                    @"SELECT * FROM book"
                );
            }
        }
        
        private IDbConnection GetNewDbConnection()
        {
            return new NpgsqlConnection(this._connectionString);
        }
    }
}