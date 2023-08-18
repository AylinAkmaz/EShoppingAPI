using EShoppingAPI.DAL.Abstract;
using EShoppingAPI.DAL.Concrete.EntityFramework.DataManagment;
using EShoppingAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;

namespace EShoppingAPI.DAL.Concrete
{
    public class EFOrderDetailRepository : EFRepository<OrderDetail>, IOrderDetailRepository
    {
        public EFOrderDetailRepository(DbContext context) : base(context)
        {

        }
    }


}
