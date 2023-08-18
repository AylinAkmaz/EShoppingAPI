using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EShoppingAPI.Entity.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EShoppingAPI.DAL.Abstract.DataManagment
{
    public interface IRepository<T> where T : AuditableEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] IncludeProperties);/* category. GetAsync (q=>q id==6,"Products")*/
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params string[] IncludeProperties);
        Task<EntityEntry<T>> AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task RemoveAsync(T Entity);

    }
}
