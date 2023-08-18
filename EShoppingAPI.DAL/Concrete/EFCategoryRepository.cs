using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShoppingAPI.DAL.Abstract.DataManagment;
using EShoppingAPI.DAL.Abstract;
using EShoppingAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using EShoppingAPI.DAL.Concrete.EntityFramework.DataManagment;

namespace EShoppingAPI.DAL.Concrete
{
    public class EFCategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public EFCategoryRepository(DbContext context) : base(context)
        {

        }
    }


}
