using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.DAL.Abstract.DataManagment
{
    public interface IUnıtOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IProductRepository ProductRepository { get; }
        IUserRepository UserRepository { get; }

        Task<int> SaveChangeAsync();

    }
}
