using Dapper;
using Microsoft.Data.Sqlite;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ORM.Dapper
{
    public class ProductRepository : IRepository<Product>
    {
        string _databaseName = "Data Source=OrmDapper.sqlite";

        public ProductRepository(string databaseName)
        {
            _databaseName = databaseName;
        }

        public async Task Add(Product item)
        {
            if (item == null)
                throw new ArgumentNullException();

            string sqlProductInsert = "INSERT INTO Products (Id, Name, Description, Weight, Height, Width, Length) " +
                                            "Values (@Id, @Name, @Description, @Weight, @Height, @Width, @Length);";

            using (var connection = new SqliteConnection(_databaseName))
                await connection.ExecuteAsync(sqlProductInsert, item);
        }

        public async Task Delete(int id)
        {
            var product = await GetById(id);
            await Delete(product);
        }

        public async Task Delete(Product item)
        {
            if (item == null)
                throw new InvalidOperationException("No entity found in Products table");

            string sqlProductDelete = "DELETE FROM Products WHERE Id = @Id;";

            using (var connection = new SqliteConnection(_databaseName))
                await connection.ExecuteAsync(sqlProductDelete, item);
        }

        public Task<List<Product>> Get(Expression<Func<Product, bool>> predicate)//todo: segregate interface, unnecessary method
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAll()
        {
            string sqlProductsSelect = "SELECT * FROM Products;";

            using (var connection = new SqliteConnection(_databaseName))
            {
                var products = await connection.QueryAsync<Product>(sqlProductsSelect);
                return products.ToList();
            }
        }

        public async Task<Product> GetById(int id)
        {
            string sqlProductSelectById = "SELECT * FROM Products WHERE Id = @Id;";

            using (var connection = new SqliteConnection(_databaseName))
            {
                var product = await connection.QueryFirstOrDefaultAsync<Product>(sqlProductSelectById, new { Id = id });
                return product;
            }
        }

        public async Task Save(Product item)
        {
            if (item == null)
                throw new ArgumentNullException();

            string sqlProductUpdate = "UPDATE Products " +
                "SET Name = @Name, " +
                "Description = @Description, " +
                "Weight = @Weight, " +
                "Height = @Height, " +
                "Width = @Width, " +
                "Length = @Length " +
                "WHERE Id = @Id;";

            using (var connection = new SqliteConnection(_databaseName))
                await connection.ExecuteAsync(sqlProductUpdate, item);
        }
    }
}
