using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Core.Entities;

namespace WriterBlog.Core.DataAccess.EntityFremawork
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity, new()
    {
        DbContext _db;
        DbSet<T> _dbSet;
        public RepositoryBase(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public Task<int> AddAsync(T entity)
        {
            
            _dbSet.Add(entity);

            return _db.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
            return _db.SaveChangesAsync();
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? _dbSet.Where(x => x.IsDeleted == false).ToListAsync() : _dbSet.Where(expression).Where(x => x.IsDeleted == false).ToListAsync();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AsNoTracking<T>().FirstOrDefaultAsync(expression);
        }
        public Task<int> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return _db.SaveChangesAsync();
        }
    }
}
