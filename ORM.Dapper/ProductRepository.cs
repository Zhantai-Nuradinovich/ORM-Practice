﻿using Dapper;
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

            string sqlProductInsert = "INSERT INTO Products (Name, Description, Weight, Height, Width, Length) " +
                                            "Values (@Name, @Description, @Weight, @Height, @Width, @Length);";

            using (var connection = new SqliteConnection(_databaseName))
                await connection.ExecuteAsync(sqlProductInsert, item);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Product item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> Get(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAll()
        {
            string sqlProductSelect = "SELECT * FROM Products;";

            using (var connection = new SqliteConnection(_databaseName))
            {
                var products = await connection.QueryAsync<Product>(sqlProductSelect);
                return products.ToList();
            }
        }

        public async Task<Product> GetById(int id)
        {
            string sqlProductSelect = "SELECT * FROM Products WHERE Id = @Id;;";

            using (var connection = new SqliteConnection(_databaseName))
            {
                var product = await connection.QueryFirstOrDefaultAsync<Product>(sqlProductSelect, new { Id = 1 });
                return product;
            }
        }

        public Task Save(Product item)
        {
            if (item == null)
                throw new ArgumentNullException();

            throw new NotImplementedException();
        }
    }
}
