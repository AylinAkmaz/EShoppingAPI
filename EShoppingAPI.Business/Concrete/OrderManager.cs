using System.Linq.Expressions;
using EShoppingAPI.Business.Abstract;
using EShoppingAPI.DAL.Abstract.DataManagment;
using EShoppingAPI.Entity.Poco;

namespace EShoppingAPI.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IUnıtOfWork _uow;
        public OrderManager(IUnıtOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Order> AddAsync(Order Entity)
        {
            await _uow.OrderRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(Expression<Func<Order, bool>> filter = null, params string[] IncludeProperties)
        {
            return await _uow.OrderRepository.GetAllAsync(filter, IncludeProperties);
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> filter, params string[] IncludeProperties)
        {
            return await _uow.OrderRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task OrderAdd(Order order, List<OrderDetail> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                orderDetail.Order = order;
                await _uow.OrderDetailRepository.AddAsync(orderDetail);
            }

            await _uow.OrderRepository.AddAsync(order);

            await _uow.SaveChangeAsync();
        }

        public async Task RemoveAsync(Order Entity)
        {
            await _uow.OrderRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Order Entity)
        {
            await _uow.OrderRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }

}
