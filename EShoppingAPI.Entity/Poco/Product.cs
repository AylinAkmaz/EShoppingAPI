using EShoppingAPI.Entity.Base;

namespace EShoppingAPI.Entity.Poco
{
    public class Product : AuditableEntity
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FeaturedImage { get; set; }
        public int CategoryID { get; set; }
        public double? UnitPrice { get; set; }
        public virtual Category Category { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetail { get; set; }

    }

}
