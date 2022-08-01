using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ORM.EF
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task AddAsync(Product Item)
        {
            if (Item == null)
                throw new ArgumentNullException();

            return base.AddAsync(Item);
        }
        public override Task SaveAsync(Product Item)
        {
            if (Item == null)
                throw new ArgumentNullException();

            return base.SaveAsync(Item);
        }

        public async Task DeleteAsync(int id)
        {
            var product = GetByIdAsync(id).Result;
            if (product == null)
                throw new ArgumentNullException();

            await base.DeleteAsync(product);
        }
    }
}
