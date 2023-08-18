using EShoppingAPI.Entity.Base;

namespace EShoppingAPI.Entity.Poco
{
    public class User : AuditableEntity
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }

    }

}
