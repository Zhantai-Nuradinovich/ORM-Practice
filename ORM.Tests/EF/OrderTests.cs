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
                context.Add(new Product() { Id = 1, Name =  "Default", Description = "Max"});
                await context.SaveChangesAsync();
            }

            using (var context = Helper.GetDbContext("AddOrderContext"))
            {
                var oRepo = new OrderRepository(context);
                var order = new Order() { Id = 1, ProductId = 1, Status = (byte)Status.InProgress, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
                await oRepo.Add(order);
                Assert.NotEqual(0, order.Id);
            }
        }
        [Fact]
        public void Add_Null_ThrowsArgumentNullException()
        {
            using (var context = Helper.GetDbContext("NullContext"))
            {
                var oRepo = new OrderRepository(context);
                Action action = () => oRepo.Add(null);
                Assert.Throws<ArgumentNullException>(action);
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
            }

            using (var context = Helper.GetDbContext("GetOrderByIdTestContext"))
            {
                var oRepo = new OrderRepository(context);
                var order = await oRepo.GetById(1);
                Assert.NotNull(order);
            }
        }

        [Fact]
        public async Task GetAll_GetFilteredOrders_ReturnsFilteredOrdersAsync()
        {
            using (var context = Helper.GetDbContext("GetAllFilteredOrdersTestContext"))
            {
                context.Add(new Order() { Id = 1, CreatedDate = new DateTime(2022, 03, 21), UpdatedDate = DateTime.Now, ProductId = 1, Status = (byte)Status.Loading});
                context.Add(new Order() { Id = 2, CreatedDate = new DateTime(2022, 01, 22), UpdatedDate = DateTime.Now, ProductId = 1, Status = (byte)Status.Arrived});
                context.SaveChanges();
            }

            using (var context = Helper.GetDbContext("GetAllFilteredOrdersTestContext"))
            {
                var oRepo = new OrderRepository(context);
                var orders = await oRepo.Get(x => x.Status == (byte)Status.Arrived && x.CreatedDate.Day > 20);
                bool isSatisfyConditions = orders.All(x => x.Status == 3 && x.CreatedDate.Day > 20);
                Assert.True(isSatisfyConditions);
            }
        }
        #endregion
        #region UPDATE
        [Fact]
        public async Task Update_Order_ReturnsUpdatedOrderAsync()
        {
            using (var context = Helper.GetDbContext("UpdateTestContext"))
            {
                context.Add(new Product() { Id = 1, Name = "Product", Description = "Description"});
                context.Add(new Order() { Id = 1,  ProductId = 1, Status = (byte)Status.InProgress});
                await context.SaveChangesAsync();
            }

            using (var context = Helper.GetDbContext("UpdateTestContext"))
            {
                var oRepo = new OrderRepository(context);
                var orderToUpdate = await oRepo.GetById(1);
                orderToUpdate.Status = (byte)Status.Done;
                bool isUpdated = await oRepo.Save(orderToUpdate);
                Assert.True(isUpdated);
            }
        }
        [Fact]
        public void Update_Null_ThrowsArgumentNullExceptionAsync()
        {
            using (var context = Helper.GetDbContext("UpdateNullTestContext"))
            {
                var oRepo = new OrderRepository(context);
                Action action = () => oRepo.Save(null);
                Assert.Throws<ArgumentNullException>(action);
            }
        }
        #endregion
        #region DELETE
        [Fact]
        public async Task Delete_Order_ReturnsTrueAsync()
        {
            using (var context = Helper.GetDbContext("DeleteTestContext"))
            {
                context.Add(new Product() { Id = 1, Name = "Product", Description = "Description" });
                context.Add(new Order() { Id = 1, ProductId = 1, Status = (byte)Status.InProgress });
                await context.SaveChangesAsync();
            }

            using (var context = Helper.GetDbContext("DeleteTestContext"))
            {
                var oRepo = new OrderRepository(context);
                bool isDeleted = await oRepo.Delete(1);
                Assert.True(isDeleted);
            }
        }

        [Fact]
        public void Delete_Null_ThrowsArgumentNullExceptionAsync()
        {
            using (var context = Helper.GetDbContext("DeleteNullTestContext"))
            {
                var oRepo = new OrderRepository(context);
                Action action = () => oRepo.Delete(1);
                Assert.Throws<ArgumentNullException>(action);
            }
        }

        [Fact]
        public async Task DeleteAll_DeletesInBulk_ReturnsTrueAsync()
        {
            using (var context = Helper.GetDbContext("DeleteAllTestContext"))
            {
                context.Add(new Product() { Id = 1, Name = "Product", Description = "Description" });
                context.Add(new Order() { Id = 1, ProductId = 1, Status = (byte)Status.InProgress });
                context.Add(new Order() { Id = 2, ProductId = 1, Status = (byte)Status.InProgress });
                context.Add(new Order() { Id = 3, ProductId = 1, Status = (byte)Status.InProgress });
                await context.SaveChangesAsync();
            }

            using (var context = Helper.GetDbContext("DeleteAllTestContext"))
            {
                var oRepo = new OrderRepository(context);
                await oRepo.DeleteAll(x => x.Status == (byte)Status.InProgress);
                var orders = await oRepo.Get(x => x.Status == (byte)Status.InProgress);
                var ordersIsEmpty = orders.Count == 0;
                Assert.True(ordersIsEmpty);
            }
        }
        #endregion
    }
}
