using Models;
using ORM.EF;
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
            //using (var pRepo = new ProductRepository())
            //{
            //    var product = new Product()
            //    {
            //        Name = "HP",
            //        Description = "2021, nice laptop",
            //        Height = 100,
            //        Weight = 155,
            //        Width = 5,
            //        Length = 16
            //    };

            //    pRepo.Add(product);
            //    var isAdded = product.Id != 0;
            //    Assert.True(isAdded);
            //}
        }
        [Fact]
        public void Add_Null_ThrowsArgumentNullException()
        {
            //using (var pRepo = new ProductRepository())
            //{
            //    Action action = () => pRepo.Add(null);
            //    Assert.Throws<ArgumentNullException>(action);
            //}
        }
        #endregion
        #region READ
        [Fact]
        public void GetAll_GetProducts_ReturnsAllProducts()
        {
            //using (var pRepo = new ProductRepository())
            //{
            //    var products = pRepo.GetAll();
            //    var count = products.Result.Count;
            //    Assert.True(count > 0);
            //}
        }

        [Fact]
        public void Get_GetProductById_ReturnsProduct()
        {
            //using (var pRepo = new ProductRepository())
            //{
            //    var product = pRepo.GetById(1).Result;
            //    Assert.NotNull(product);
            //}
        }
        #endregion
        #region UPDATE
        [Fact]
        public void Update_Product_ReturnsUpdatedProduct()
        {
            //using (var pRepo = new ProductRepository())
            //{
            //    var product = pRepo.GetById(3).Result;
            //    product.Length = product.Length + 1;
            //    var isAdded = pRepo.Save(product).Result;
            //    Assert.True(isAdded);
            //}

        }
        [Fact]
        public void Update_Null_ThrowsArgumentNullException()
        {
            //using (var pRepo = new ProductRepository())
            //{
            //    Action action = () => pRepo.Save(null);
            //    Assert.Throws<ArgumentNullException>(action);
            //}
        }
        #endregion
        #region DELETE
        [Fact]
        public void Delete_Product_ReturnsTrue()
        {
            //using (var pRepo = new ProductRepository())
            //{
                
            //}
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
