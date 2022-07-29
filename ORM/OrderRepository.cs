using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ORM.EF
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        { }

        public override Task Add(Order Item)
        {
            if (Item == null)
                throw new ArgumentNullException();

            return base.Add(Item);
        }

        public Task Delete(int id)
        {
            var order = GetById(id).Result;
            if (order == null)
                throw new ArgumentNullException();

            return base.Delete(order);
        }

        public async Task DeleteAll(Expression<Func<Order, bool>> predicate)
        {
            var orders = await Get(predicate);
            Context.Orders.RemoveRange(orders);
            await Context.SaveChangesAsync();
        }

        public override Task Save(Order Item)
        {
            if (Item == null)
                throw new ArgumentNullException();
            
            return base.Save(Item);
        }
    }
}
