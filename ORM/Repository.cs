using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ORM.EF
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected ApplicationDbContext Context { get; set; }

        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public virtual async Task Add(T Item)
        {
            Context.Add(Item);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<bool> Delete(T item)
        {
            Context.Remove(item);
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }

        public virtual async Task<List<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetById(int Id)
        {
            return await Context.Set<T>().FindAsync(Id);
        }

        public virtual async Task<bool> Save(T Item)
        {
            Context.Update(Item);
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }
    }
}
