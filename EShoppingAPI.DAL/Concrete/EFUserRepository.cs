using EShoppingAPI.DAL.Abstract;
using EShoppingAPI.DAL.Concrete.EntityFramework.DataManagment;
using EShoppingAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;

namespace EShoppingAPI.DAL.Concrete
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        public EFUserRepository(DbContext context) : base(context)
        {

        }
    }


}
