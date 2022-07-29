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

        public virtual async Task Add(T Item)
        {
            Context.Add(Item);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Delete(T item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
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

        public virtual async Task Save(T Item)
        {
            Context.Update(Item);
            await Context.SaveChangesAsync();
        }
    }
}
