using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task SaveAsync(T item);
        Task AddAsync(T item);
        Task DeleteAsync(T item);
    }
}
