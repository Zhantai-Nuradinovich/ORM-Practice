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

        public override Task AddAsync(Order Item)
        {
            if (Item == null)
                throw new ArgumentNullException();

            return base.AddAsync(Item);
        }

        public async Task DeleteAsync(int id)
        {
            var order = GetByIdAsync(id).Result;
            if (order == null)
                throw new ArgumentNullException();

            await base.DeleteAsync(order);
        }

        public async Task DeleteAllAsync(Expression<Func<Order, bool>> predicate)
        {
            var orders = await GetAsTrackingAsync(predicate);
            Context.Orders.RemoveRange(orders);
            await Context.SaveChangesAsync();
        }

        public override Task SaveAsync(Order Item)
        {
            if (Item == null)
                throw new ArgumentNullException();
            
            return base.SaveAsync(Item);
        }
    }
}
