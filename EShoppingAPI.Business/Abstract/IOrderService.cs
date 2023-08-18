using EShoppingAPI.Entity.Poco;

namespace EShoppingAPI.Business.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        Task OrderAdd(Order order, List<OrderDetail> orderDetails);
    }


}
