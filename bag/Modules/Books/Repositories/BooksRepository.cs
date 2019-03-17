using System;
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
    public class BooksRepository : IBooksRepository
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
                    @"SELECT * FROM book WHERE id = @Id", new {Id = id}
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
                    @"DELETE FROM book WHERE id = @Id", new {Id = id}
                );
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync()
        {
            using (IDbConnection dbConnection = GetNewDbConnection())
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<BookEntity>(@"
                    SELECT * FROM book LIMIT 100
                ");
            }
        }

        public async Task<BookProgressEntity> GetBookProgressAsync(int bookId)
        {
            using (IDbConnection dbConnection = GetNewDbConnection())
            {
                dbConnection.Open();
                var bookProgressesData = await dbConnection.QueryAsync(@"
                        SELECT 
                               *
                        FROM 
                             book_progress
                        WHERE 
                              book_id = @BookId
                    ", new {BookId = bookId}
                );

                return bookProgressesData.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<BookProgressEntity>> GetBooksProgressAsync(int[] bookIds)
        {
            using (IDbConnection dbConnection = GetNewDbConnection())
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<BookProgressEntity>(@"
                    SELECT *
                    FROM
                         book_progress
                    WHERE 
                         book_id in (@Ids)

                ", new { Ids = bookIds });
            }
        }

        public async Task UpdateBookProgressAsync(int bookId, int pagesCount)
        {
            var bookProgress = await this.GetBookProgressAsync(bookId);

            using (IDbConnection dbConnection = GetNewDbConnection())
            {
                dbConnection.Open();
                if (bookProgress == null)
                {
                    await dbConnection.ExecuteAsync(@"
                              INSERT INTO book_progress
                                     (book_id, pages_count)
                              VALUES 
                                     (@BookId, @PagesCount)
                            ",
                        new {BookId = bookId, PagesCount = pagesCount}
                    );
                }
                else
                {
                    await dbConnection.ExecuteAsync(@"
                               UPDATE book_progress
                               SET pages_count = @PagesCount
                               WHERE book_id = @BookId
                             ",
                        new {BookId = bookId, PagesCount = pagesCount}
                    );
                }
            }
        }

        private IDbConnection GetNewDbConnection()
        {
            return new NpgsqlConnection(this._connectionString);
        }
    }
}