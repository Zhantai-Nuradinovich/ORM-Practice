using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ORM.EF
{
    public interface IRepository<T> where T : Entity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int Id);
        Task<List<T>> Get(Expression<Func<T, bool>> predicate);
        Task<bool> Save(T Item);
        Task<int> Add(T Item);
        Task<bool> Delete(int PrimaryKey);
    }
}
