using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ENIMS.DataObjects
{
    public class RepositoryBaseWork<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        AppUnitOfWork _context;

        public RepositoryBaseWork(AppUnitOfWork context)
        {
            _context = context;
        }

        public bool Add(TEntity entity)
        {
            _context.Context.Set<TEntity>().AddAsync(entity);
            return true;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await _context.Context.Set<TEntity>().AddAsync(entity);
                return true;
        }
        public bool AddRange(IEnumerable<TEntity> entities)
        {
            _context.Context.Set<TEntity>().AddRange(entities);
            return true;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Context.Set<TEntity>().AddRangeAsync(entities);
            return true;
        }

        public bool Update(TEntity entity)
        {
            _context.Context.Attach(entity);
            _context.Context.Entry(entity).State = EntityState.Modified;
            return true;

        }

        public bool Remove(TEntity entity)
        {
            _context.Context.Remove(entity);
            return true;

        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params string[] path)
        {
            IQueryable<TEntity> query = _context.Context.Set<TEntity>();
            if (path != null)
            {
                foreach (var p in path)
                {
                    query = query.Include(p);
                }
            }

            return query.FirstOrDefault(predicate);
        }

        public TEntity First<TProperty>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, TProperty>>[] path)
        {
            IQueryable<TEntity> query = _context.Context.Set<TEntity>();

            foreach (var p in path)
            {
                query = query.Include(p);
            }

            return query.First(predicate);
        }

        public IQueryable<TEntity> Where<TProperty>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, TProperty>>[] path)
        {
            IQueryable<TEntity> query = _context.Context.Set<TEntity>();
            foreach (var p in path)
            {
                query = query.Include(p);
            }
            return query.Where(predicate);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Context.Set<TEntity>();
            foreach (var i in includes)
            {
                query = query.Include(i);
            }
            return query.Where(predicate);
        }


        public IQueryable<TEntity> All<TProperty>(params Expression<Func<TEntity, TProperty>>[] path)
        {
            IQueryable<TEntity> query = _context.Context.Set<TEntity>();
            if (path != null)
            {
                foreach (var p in path)
                {
                    query = query.Include(p);
                }
            }
            return query;
        }

        public IQueryable<TEntity> All(params string[] path)
        {
            IQueryable<TEntity> query = _context.Context.Set<TEntity>();
            if (path != null)
            {
                foreach (var p in path)
                {
                    query = query.Include(p);
                }
            }
            return query;
        }

        public TEntity Find(long id)
        {
            return _context.Context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> FindAsync(long id)
        {
            return await _context.Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params string[] path)
        {
            IQueryable<TEntity> query = _context.Context.Set<TEntity>();
            if (path != null)
            {
                foreach (var p in path)
                {
                    query = query.Include(p);
                }
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

        public bool Exist(long id)
        {
            return (_context.Context.Set<TEntity>().Find(id) != null ? true : false);
        }

        public async Task<bool> ExistAsync(long id)
        {
            return (await _context.Context.Set<TEntity>().FindAsync(id) != null ? true : false);
        }

        public long CountAll()
        {
            return _context.Context.Set<TEntity>().Count();
        }

        public async Task<long> CountAllAsync()
        {
            return await _context.Context.Set<TEntity>().CountAsync();
        }

        public bool ExistWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return (_context.Context.Set<TEntity>().Where(predicate).FirstOrDefault() != null ? true : false);
        }

        public async Task<bool> ExistWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return (await _context.Context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync() != null ? true : false);
        }


        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Context.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _context.Context.Set<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Context.Set<TEntity>();
        }

      
    }
}
