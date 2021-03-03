using Booky.Contracts;
using Booky.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Booky.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public DbSet<T> _db;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }        

        public async Task<T> Find(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if ( expression != null )
            {
                query = query.Where(expression);
            }

            if( includes != null )
            {
                foreach ( var item in includes )
                {
                    query = query.Include(item);
                }
            }

            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<IList<T>> FindAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if( expression != null )
            {
                query = query.Where(expression);
            }

            if( includes != null )
            {
                foreach ( var item in includes )
                {
                    query = query.Include(item);
                }
            }   

            if ( orderBy != null )
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<bool> isExists(Expression<Func<T, bool>> expression = null)
        {            
            return await _db.AnyAsync(expression);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _db.AddRange(entities);
        }

        public void Create(T entity)
        {
            _db.Add(entity);
        }

        public void Delete(T entity)
        {
            _db.Remove(entity);
        }

        public void Update(T entity)
        {
            _db.Update(entity);
        }

        public void RemoveRange(IEnumerable<T> entites)
        {
            _db.RemoveRange(entites);
        }
    }
}
