using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ORM.EF
{
    public class ProductRepository : IRepository<Product>, IDisposable
    {
        ApplicationDbContext _context;
        public ProductRepository()
        {
            _context = DbContextCreator.GetDbContext();
        }
        public Task<int> Add(Product Item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int PrimaryKey)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<List<Product>> Get(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Product Item)
        {
            throw new NotImplementedException();
        }
    }
}
