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
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<List<T>> Get(Expression<Func<T, bool>> predicate);
        Task Save(T item);
        Task Add(T item);
        Task Delete(T item);
    }
}
