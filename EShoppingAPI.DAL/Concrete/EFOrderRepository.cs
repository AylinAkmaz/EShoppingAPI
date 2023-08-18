using EShoppingAPI.DAL.Abstract;
using EShoppingAPI.DAL.Concrete.EntityFramework.DataManagment;
using EShoppingAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;

namespace EShoppingAPI.DAL.Concrete
{
    public class EFOrderRepository : EFRepository<Order>, IOrderRepository
    {
        public EFOrderRepository(DbContext context) : base(context)
        {

        }
    }


}
