using EShoppingAPI.DAL.Abstract;
using EShoppingAPI.DAL.Concrete.EntityFramework.DataManagment;
using EShoppingAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;

namespace EShoppingAPI.DAL.Concrete
{
    public class EFProductRepository : EFRepository<Product>, IProductRepository
    {
        public EFProductRepository(DbContext context) : base(context)
        {

        }
    }


}
