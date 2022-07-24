using Models;
using ORM.EF;
using System;
using Xunit;

namespace ORM.Tests.EF
{
    public class OrderTests
    {
        //It is now depends on the Database, but implemented this way to just review EF Core and Dapper
        #region CREATE
        [Fact]
        public void Add_Order_ReturnsInsertedOrder()
        {
            using (var oRepo = new OrderRepository())
            using (var prRepo = new ProductRepository())
            {
                var product = prRepo.GetById(1).Result;
                var order = new Order()
                {
                    Status = (byte)Status.NotStarted,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Product = product
                };

                bool isAdded = oRepo.Add(order).Result != 0;
                Assert.True(isAdded);
            }
        }
        [Fact]
        public void Add_Null_ThrowsArgumentNullException()
        {
            using (var oRepo = new OrderRepository())
            {
                Action action = () => oRepo.Add(null);
                Assert.Throws<ArgumentNullException>(action);
            }
        }
        #endregion
        #region READ
        [Fact]
        public void Get_GetOrderById_ReturnsOrder()
        {
            using (var oRepo = new OrderRepository())
            {

            }
        }

        [Fact]
        public void GetAll_GetFilteredOrders_ReturnsFilteredOrders()
        {

        }
        #endregion
        #region UPDATE
        [Fact]
        public void Update_Order_ReturnsUpdatedOrder()
        {

        }
        [Fact]
        public void Update_Null_ThrowsArgumentNullException()
        {

        }
        #endregion
        #region DELETE
        [Fact]
        public void Delete_Order_ReturnsTrue()
        {

        }
        [Fact]
        public void Delete_DeletedOrder_ReturnsFalse()
        {

        }
        [Fact]
        public void Delete_Null_ThrowsArgumentNullException()
        {

        }

        [Fact]
        public void DeleteAll_DeletesInBulk_ReturnsTrue()
        {

        }
        #endregion
    }
}
