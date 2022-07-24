using System;
using Xunit;

namespace ORM.Tests.EF
{
    public class ProductTests
    {
        //It is now depends on the Database, but implemented this way to just review EF Core and Dapper
        #region CREATE
        [Fact]
        public void Add_Product_ReturnsInsertedProduct()
        {

        }
        [Fact]
        public void Add_Null_ThrowsArgumentNullException()
        {

        }
        #endregion
        #region READ
        [Fact]
        public void GetAll_GetProducts_ReturnsAllProducts()
        {

        }

        [Fact]
        public void Get_GetProductById_ReturnsProduct()
        {

        }
        #endregion
        #region UPDATE
        [Fact]
        public void Update_Product_ReturnsUpdatedProduct()
        {

        }
        [Fact]
        public void Update_Null_ThrowsArgumentNullException()
        {

        }
        #endregion
        #region DELETE
        [Fact]
        public void Delete_Product_ReturnsTrue()
        {

        }
        [Fact]
        public void Delete_DeletedProduct_ReturnsFalse()
        {

        }
        [Fact]
        public void Delete_Null_ThrowsArgumentNullException()
        {

        }
        #endregion
    }
}
