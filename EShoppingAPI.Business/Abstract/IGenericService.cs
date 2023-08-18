using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Business.Abstract
{
    public interface IGenericService<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] IncludeProperties);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params string[] IncludeProperties);
        Task<T> AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task RemoveAsync(T Entity);

    }
}
