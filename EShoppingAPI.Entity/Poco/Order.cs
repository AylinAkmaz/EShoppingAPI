using EShoppingAPI.Entity.Base;

namespace EShoppingAPI.Entity.Poco
{
    public class Order : AuditableEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int UserID { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
        public virtual User User { get; set; }

    }

}
