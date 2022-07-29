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

        public override Task Add(Product Item)
        {
            if (Item == null)
                throw new ArgumentNullException();

            return base.Add(Item);
        }
        public override Task Save(Product Item)
        {
            if (Item == null)
                throw new ArgumentNullException();

            return base.Save(Item);
        }

        public Task Delete(int id)
        {
            var product = GetById(id).Result;
            if (product == null)
                throw new ArgumentNullException();

            return base.Delete(product);
        }
    }
}
