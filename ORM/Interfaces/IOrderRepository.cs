using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ORM.EF
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<bool> DeleteAll(Expression<Func<Order, bool>> predicate);
    }
}