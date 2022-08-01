using Microsoft.EntityFrameworkCore;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public virtual async Task AddAsync(T Item)
        {
            Context.Add(Item);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<List<T>> GetAsTrackingAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int Id)
        {
            return await Context.Set<T>().FindAsync(Id);
        }

        public virtual async Task SaveAsync(T Item)
        {
            Context.Update(Item);
            await Context.SaveChangesAsync();
        }
    }
}
