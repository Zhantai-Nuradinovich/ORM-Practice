using Models;
using ORM.EF;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace ORM.Tests.EF
{
    public class OrderTests
    {
        //It is now depends on the Database, but implemented this way to just review EF Core and Dapper
        #region CREATE
        [Fact]
        public async Task Add_Order_ReturnsInsertedOrderAsync()
        {
            using (var context = Helper.GetDbContext("AddOrderContext"))
            {
                var pRepo = new ProductRepository(context);
                var oRepo = new OrderRepository(context);

                var product = new Product() { Id = 1, Name =  "Default", Description = "Max"};
                var order = new Order() { Id = 1, ProductId = 1, Status = (byte)Status.InProgress, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };

                await pRepo.AddAsync(product);
                await oRepo.AddAsync(order);

                var orderInserted = await oRepo.GetByIdAsync(1);
                Assert.NotNull(orderInserted);
            }
        }
        [Fact]
        public void Add_Null_ThrowsArgumentNullException()
        {
            using (var context = Helper.GetDbContext("NullContext"))
            {
                var oRepo = new OrderRepository(context);
                Assert.ThrowsAsync<ArgumentNullException>(async () => await oRepo.AddAsync(null));
            }
        }
        #endregion
        #region READ
        [Fact]
        public async Task Get_GetOrderById_ReturnsOrderAsync()
        {
            using (var context = Helper.GetDbContext("GetOrderByIdTestContext"))
            {
                context.Add(new Order() { Id = 1, CreatedDate = new DateTime(2022, 03, 21), UpdatedDate = DateTime.Now, ProductId = 1, Status = (byte)Status.Loading });
                context.SaveChanges();

                var oRepo = new OrderRepository(context);
                var order = await oRepo.GetByIdAsync(1);

                Assert.NotNull(order);
            }
        }

        [Fact]
        public async Task GetAll_GetFilteredOrders_ReturnsFilteredOrdersAsync()
        {
            using (var context = Helper.GetDbContext("GetAllFilteredOrdersTestContext"))
            {
                context.Add(new Order() { Id = 1, CreatedDate = new DateTime(2022, 03, 21), Status = (byte)Status.Loading, UpdatedDate = DateTime.Now, ProductId = 1 });
                context.Add(new Order() { Id = 2, CreatedDate = new DateTime(2022, 01, 22), Status = (byte)Status.Arrived, UpdatedDate = DateTime.Now, ProductId = 1 });
                context.SaveChanges();

                var oRepo = new OrderRepository(context);
                var orders = await oRepo.GetAsync(x => x.Status == (byte)Status.Arrived && x.CreatedDate.Day > 20);

                Assert.Single(orders);
            }
        }
        #endregion
        #region UPDATE
        [Fact]
        public async Task Update_Order_ReturnsUpdatedOrderAsync()
        {
            using (var context = Helper.GetDbContext("UpdateOrderTestContext"))
            {
                context.Add(new Product() { Id = 1, Name = "Product", Description = "Description"});
                context.Add(new Order() { Id = 1,  ProductId = 1, Status = (byte)Status.InProgress});
                await context.SaveChangesAsync();

                var oRepo = new OrderRepository(context);
                var orderToUpdate = await oRepo.GetByIdAsync(1);

                orderToUpdate.Status = (byte)Status.Done;
                await oRepo.SaveAsync(orderToUpdate);

                orderToUpdate = await oRepo.GetByIdAsync(1);
                Assert.Equal((byte)Status.Done, orderToUpdate.Status);
            }
        }
        [Fact]
        public void Update_Null_ThrowsArgumentNullExceptionAsync()
        {
            using (var context = Helper.GetDbContext("UpdateOrderNullTestContext"))
            {
                var oRepo = new OrderRepository(context);
                Action action = () => oRepo.SaveAsync(null);
                Assert.Throws<ArgumentNullException>(action);
            }
        }
        #endregion
        #region DELETE
        [Fact]
        public async Task Delete_Order_ReturnsTrueAsync()
        {
            using (var context = Helper.GetDbContext("DeleteOrderTestContext"))
            {
                context.Add(new Product() { Id = 1, Name = "Product", Description = "Description" });
                context.Add(new Order() { Id = 1, ProductId = 1, Status = (byte)Status.InProgress });
                await context.SaveChangesAsync();

                var oRepo = new OrderRepository(context);
                await oRepo.DeleteAsync(1);

                var order = await oRepo.GetByIdAsync(1);
                Assert.Null(order);
            }
        }

        [Fact]
        public void Delete_Null_ThrowsArgumentNullExceptionAsync()
        {
            using (var context = Helper.GetDbContext("DeleteOrderNullTestContext"))
            {
                var oRepo = new OrderRepository(context);
                Assert.ThrowsAsync<ArgumentNullException>(async () => await oRepo.DeleteAsync(1));
            }
        }

        [Fact]
        public async Task DeleteAll_DeletesInBulk_ReturnsTrueAsync()
        {
            using (var context = Helper.GetDbContext("DeleteAllOrderTestContext"))
            {
                context.Add(new Product() { Id = 1, Name = "Product", Description = "Description" });
                context.Add(new Order() { Id = 1, ProductId = 1, Status = (byte)Status.InProgress });
                context.Add(new Order() { Id = 2, ProductId = 1, Status = (byte)Status.InProgress });
                context.Add(new Order() { Id = 3, ProductId = 1, Status = (byte)Status.InProgress });
                await context.SaveChangesAsync();

                var oRepo = new OrderRepository(context);
                await oRepo.DeleteAllAsync(x => x.Status == (byte)Status.InProgress);

                var orders = await oRepo.GetAsync(x => x.Status == (byte)Status.InProgress);
                Assert.Empty(orders);
            }
        }
        #endregion
    }
}
