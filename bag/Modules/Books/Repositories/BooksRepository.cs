using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        internal IDbConnection DbConnection => new NpgsqlConnection(this._connectionString);
        
        public void Create(BookEntity item)
        {
            using (IDbConnection dbConnection = DbConnection)
            {
                dbConnection.Open();
                dbConnection.Execute(
                    @"INSERT INTO book
                                 (title, author, coverUrl, grade, pagesNumber)
                            VALUES
                                 (@Title, @Author, @CoverUrl, @Grade, @PagesNumber)",
                    item
                );
            }
        }

        public BookEntity GetById(int id)
        {
            using (IDbConnection dbConnection = DbConnection)
            {
                dbConnection.Open();
                return dbConnection.Query<BookEntity>(
                    @"SELECT * FROM book WHERE id = @Id", new { Id = id }
                ).FirstOrDefault();
            }
        }

        public void Update(BookEntity item)
        {
            using (IDbConnection dbConnection = DbConnection)
            {
                dbConnection.Open();
                dbConnection.Execute(@"
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

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = DbConnection)
            {
                dbConnection.Open();
                dbConnection.Execute(
                    @"DELETE FROM book WHERE id = @Id", new { Id = id }
                );
            }
        }

        public IEnumerable<BookEntity> GetAll()
        {
            using (IDbConnection dbConnection = DbConnection)
            {
                dbConnection.Open();
                return dbConnection.Query<BookEntity>(
                    @"SELECT * FROM book"
                );
            }
        }
    }
}