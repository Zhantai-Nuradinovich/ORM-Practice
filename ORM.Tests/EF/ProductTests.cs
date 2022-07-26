using Models;
using ORM.EF;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ORM.Tests.EF
{
    public class ProductTests
    {
        #region CREATE
        [Fact]
        public async Task Add_Product_ReturnsInsertedProductAsync()
        {
            using (var context = Helper.GetDbContext("AddProductContext"))
            {
                var product = new Product() { Id = 1, Name = "Default", Description = "Max" };
                var pRepo = new ProductRepository(context);

                await pRepo.AddAsync(product);

                product = await pRepo.GetByIdAsync(1);
                Assert.NotNull(product);
            }
        }
        [Fact]
        public void Add_Null_ThrowsArgumentNullException()
        {
            using (var context = Helper.GetDbContext("NullContext"))
            {
                var pRepo = new ProductRepository(context);
                Action action = () => pRepo.AddAsync(null);
                Assert.Throws<ArgumentNullException>(action);
            }
        }
        #endregion
        #region READ
        [Fact]
        public async Task GetAll_GetProducts_ReturnsAllProductsAsync()
        {
            using (var context = Helper.GetDbContext("GetAllProductsTestContext"))
            {
                context.Add(new Product() { Id = 1, Name = "1", Description = "2", Height = 1});
                context.Add(new Product() { Id = 2, Name = "2", Description = "3", Height = 2});
                context.Add(new Product() { Id = 3, Name = "3", Description = "4", Height = 3});
                context.SaveChanges();

                var pRepo = new ProductRepository(context);
                var products = await pRepo.GetAllAsync();

                Assert.Equal(3, products.Count);
            }
        }

        [Fact]
        public async Task Get_GetProductById_ReturnsProductAsync()
        {
            using (var context = Helper.GetDbContext("GetProductByIdTestContext"))
            {
                var product = new Product() { Id = 1, Name = "1", Description = "2", Height = 1 };
                context.Add(product);
                context.SaveChanges();

                var pRepo = new ProductRepository(context);
                product = await pRepo.GetByIdAsync(1);

                Assert.NotNull(product);
            }
        }
        #endregion
        #region UPDATE
        [Fact]
        public async Task Update_Product_ReturnsUpdatedProductAsync()
        {
            using (var context = Helper.GetDbContext("UpdateProductTestContext"))
            {
                context.Add(new Product() { Id = 1, Name = "Product", Description = "Description" });
                context.SaveChanges();
                var pRepo = new ProductRepository(context);
                var productToUpdate = await pRepo.GetByIdAsync(1);

                productToUpdate.Description = null;
                await pRepo.SaveAsync(productToUpdate);

                productToUpdate = await pRepo.GetByIdAsync(1);
                Assert.Null(productToUpdate.Description);
            }
        }
        [Fact]
        public void Update_Null_ThrowsArgumentNullException()
        {
            using (var context = Helper.GetDbContext("UpdateProductNullTestContext"))
            {
                var pRepo = new ProductRepository(context);
                Action action = () => pRepo.SaveAsync(null);
                Assert.Throws<ArgumentNullException>(action);
            }
        }
        #endregion
        #region DELETE
        [Fact]
        public async Task Delete_Product_ReturnsNullAfterSelectAsync()
        {
            using (var context = Helper.GetDbContext("DeleteProductTestContext"))
            {
                context.Add(new Product() { Id = 1, Name = "Product", Description = "Description" });
                context.SaveChanges();

                var pRepo = new ProductRepository(context);
                await pRepo.DeleteAsync(1);

                var product = await pRepo.GetByIdAsync(1);
                Assert.Null(product);
            }
        }

        [Fact]
        public void Delete_Null_ThrowsArgumentNullException()
        {
            using (var context = Helper.GetDbContext("DeleteProductNullTestContext"))
            {
                var pRepo = new ProductRepository(context);
                Assert.ThrowsAsync<ArgumentNullException>(async () => await pRepo.DeleteAsync(1));
            }
        }
        #endregion
    }
}
