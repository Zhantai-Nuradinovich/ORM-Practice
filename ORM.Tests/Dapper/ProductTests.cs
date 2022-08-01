using Models;
using ORM.Dapper;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ORM.Tests.Dapper
{
    public class ProductTests
    {
        #region CREATE
        [Fact]
        public async Task Add_Product_ReturnsInsertedProductAsync()
        {
            string databaseName = "Data Source=AddProducts.sqlite";
            Helper.Setup(databaseName);
            var pRepo = new ProductRepository(databaseName);
            var product = new Product() { Id = 1, Name = "Default", Description = "Max" , Height =1, Length = 2, Weight = 15, Width = 54};

            await pRepo.AddAsync(product);

            product = await pRepo.GetByIdAsync(1);
            Assert.NotNull(product);
        }
        [Fact]
        public async Task Add_Null_ThrowsArgumentNullException()
        {
            string databaseName = "Data Source=AddProducts.sqlite";
            var pRepo = new ProductRepository(databaseName);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await pRepo.AddAsync(null));
        }
        #endregion
        #region READ
        [Fact]
        public async Task GetAll_GetProducts_ReturnsAllProductsAsync()
        {
            string databaseName = "Data Source=GetAllProducts.sqlite";
            Helper.Setup(databaseName);
            var pRepo = new ProductRepository(databaseName);
            var product = new Product() { Id = 1, Name = "Default", Description = "Max", Height = 1, Length = 2, Weight = 15, Width = 54 };
            var product2 = new Product() { Id = 2, Name = "Default2", Description = "Max", Height = 1, Length = 2, Weight = 15, Width = 54 };
            var product3 = new Product() { Id = 3, Name = "Default3", Description = "Max", Height = 1, Length = 2, Weight = 15, Width = 54 };

            await pRepo.AddAsync(product);
            await pRepo.AddAsync(product2);
            await pRepo.AddAsync(product3);

            var products = await pRepo.GetAllAsync();

            Assert.Equal(3, products.Count);
        }

        [Fact]
        public async Task Get_GetProductById_ReturnsProductAsync()
        {
            string databaseName = "Data Source=GetProductById.sqlite";
            Helper.Setup(databaseName);
            var pRepo = new ProductRepository(databaseName);
            var product = new Product() { Id = 1, Name = "Default", Description = "Max", Height = 1, Length = 2, Weight = 15, Width = 54 };
            await pRepo.AddAsync(product);

            product = await pRepo.GetByIdAsync(1);

            Assert.NotNull(product);
        }
        #endregion
        #region UPDATE
        [Fact]
        public async Task Update_Product_ReturnsUpdatedProductAsync()
        {
            string databaseName = "Data Source=UpdateProduct.sqlite";
            Helper.Setup(databaseName);
            var pRepo = new ProductRepository(databaseName);
            var product = new Product() { Id = 1, Name = "Default", Description = "NotNull description", Height = 1, Length = 2, Weight = 15, Width = 54 };
            await pRepo.AddAsync(product);

            product = await pRepo.GetByIdAsync(1);
            product.Description = null;
            await pRepo.SaveAsync(product);

            product = await pRepo.GetByIdAsync(1);
            Assert.Null(product.Description);
        }
        [Fact]
        public async Task Update_Null_ThrowsArgumentNullExceptionAsync()
        {
            string databaseName = "Data Source=UpdateNullProduct.sqlite";
            var pRepo = new ProductRepository(databaseName);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await pRepo.SaveAsync(null));
        }
        #endregion
        #region DELETE
        [Fact]
        public async Task Delete_Product_ReturnsNullAfterSelectAsync()
        {
            string databaseName = "Data Source=DeleteProduct.sqlite";
            Helper.Setup(databaseName);
            var pRepo = new ProductRepository(databaseName);
            var product = new Product() { Id = 1, Name = "Default", Description = "NotNull description", Height = 1, Length = 2, Weight = 15, Width = 54 };
            await pRepo.AddAsync(product);

            await pRepo.DeleteAsync(1);

            product = await pRepo.GetByIdAsync(1);
            Assert.Null(product);
        }

        [Fact]
        public async Task Delete_Null_ThrowsArgumentNullExceptionAsync()
        {
            string databaseName = "Data Source=DeleteNullProduct.sqlite";
            Helper.Setup(databaseName);
            var pRepo = new ProductRepository(databaseName);
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await pRepo.DeleteAsync(1));
        }
        #endregion
    }
}
