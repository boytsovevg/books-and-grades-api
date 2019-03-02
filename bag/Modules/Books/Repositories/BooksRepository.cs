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
                    @"INSERT INTO
                                 books (title, author, cover_url, grade, pages_number)
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
                    @"SELECT * FROM book WHERE id = @Id", new {Id = id}
                ).FirstOrDefault();
            }
        }

        public BookEntity Update(BookEntity item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookEntity> GetAll()
        {
            using (IDbConnection dbConnection = DbConnection)
            {
                return dbConnection.Query<BookEntity>(
                @"SELECT * FROM book"
                );
            }
        }
    }
}