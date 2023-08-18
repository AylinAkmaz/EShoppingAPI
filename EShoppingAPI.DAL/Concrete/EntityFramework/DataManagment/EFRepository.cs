using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EShoppingAPI.DAL.Abstract.DataManagment;
using EShoppingAPI.Entity.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace EShoppingAPI.DAL.Concrete.EntityFramework.DataManagment
{
    public class EFRepository<T> : IRepository<T> where T : AuditableEntity
    {

        private readonly DbContext _Context;
        private readonly DbSet<T> _dbSet;
        public EFRepository(DbContext context)
        {
            _Context = context;
            _dbSet = _Context.Set<T>();
        }



        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params string[] IncludeProperties)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (IncludeProperties.Length > 0)
            {
                foreach (var item in IncludeProperties)
                {
                   query= query.Include(item);
                }
            }
            return await Task.Run(() => query);
        }

        public async Task<EntityEntry<T>> AddAsync(T Entity)
        {
            return await _dbSet.AddAsync(Entity);
        }

        public async Task UpdateAsync(T Entity)
        {
            await Task.Run(() => _dbSet.Update(Entity));
        }


        public async Task RemoveAsync(T Entity)
        {
            await Task.Run(() => _dbSet.Remove(Entity));
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] IncludeProperties)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            if (IncludeProperties.Length > 0)
            {
                foreach (var item in IncludeProperties)
                {
                    query.Include(item);
                }
            }
            return await query.SingleOrDefaultAsync();
        }
    }
}
