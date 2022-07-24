using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ORM.EF
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        ApplicationDbContext _context;
        public OrderRepository()
        {
            _context = DbContextCreator.GetDbContext();
        }
        public Task<int> Add(Order Item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int PrimaryKey)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAll(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<List<Order>> Get(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Order Item)
        {
            throw new NotImplementedException();
        }
    }
}
