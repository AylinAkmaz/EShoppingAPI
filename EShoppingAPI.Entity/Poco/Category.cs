using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShoppingAPI.Entity.Base;

namespace EShoppingAPI.Entity.Poco
{
    public class Category:AuditableEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }


    }

}
