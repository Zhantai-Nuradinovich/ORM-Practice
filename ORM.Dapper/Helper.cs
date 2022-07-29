using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM.Dapper
{
    public static class Helper
    {
        public static void Setup(string databaseName)
        {
            using var connection = new SqliteConnection(databaseName);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND (name = 'Products' OR name = 'Orders');");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && (tableName == "Products" || tableName == "Orders"))
            {
                string deleteFromProducts = "Delete from Products;";
                string deleteFromOrders = "Delete from Orders;";
                connection.Execute(deleteFromProducts);
                connection.Execute(deleteFromOrders);
                return;
            }

            string productsCreateQuery = "Create Table Products (" +
                "Id INTEGER NOT NULL PRIMARY KEY," +
                "Name VARCHAR(200) NOT NULL," +
                "Description VARCHAR(500) NULL," +
                "Weight INTEGER NOT NULL," +
                "Height INTEGER NOT NULL," +
                "Width INTEGER NOT NULL," +
                "Length INTEGER NOT NULL);";
            
            string ordersCreateQuery = "Create Table Orders (" +
                "Status SMALLINT NOT NULL," +
                "CreatedDate DATETIME NOT NULL," +
                "UpdatedDate DATETIME NOT NULL," +
                "ProductId INTEGER NOT NULL," +
                "FOREIGN KEY (ProductId) REFERENCES Products (Id) "+
                    "ON DELETE CASCADE ON UPDATE NO ACTION);";

            connection.Execute(productsCreateQuery);
            connection.Execute(ordersCreateQuery);
        }
    }
}
