using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Booky.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IList<T>> FindAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null
            );

        Task<T> Find(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task<bool> isExists(Expression<Func<T, bool>> expression = null);

        void AddRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entites);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
