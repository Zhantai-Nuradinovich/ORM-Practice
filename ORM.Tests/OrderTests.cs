using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ORM.Tests
{
    public class OrderTests
    {
        #region CREATE
        [Fact]
        public void Add_Order_ReturnsInsertedOrder()
        {

        }
        [Fact]
        public void Add_Null_ThrowsArgumentNullException()
        {

        }
        #endregion
        #region READ
        [Fact]
        public void GetAll_GetOrders_ReturnsAllOrders()
        {

        }

        [Fact]
        public void Get_GetOrderById_ReturnsOrder()
        {

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
