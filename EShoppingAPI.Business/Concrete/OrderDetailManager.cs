using System.Linq.Expressions;
using EShoppingAPI.Business.Abstract;
using EShoppingAPI.DAL.Abstract.DataManagment;
using EShoppingAPI.Entity.Poco;

namespace EShoppingAPI.Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IUnıtOfWork _uow;

        public OrderDetailManager(IUnıtOfWork uow)
        {
            _uow = uow;
        }
        public async Task<OrderDetail> AddAsync(OrderDetail Entity)
        {
            await _uow.OrderDetailRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync(Expression<Func<OrderDetail, bool>> filter = null, params string[] IncludeProperties)
        {
            return await _uow.OrderDetailRepository.GetAllAsync(filter, IncludeProperties);
        }

        public async Task<OrderDetail> GetAsync(Expression<Func<OrderDetail, bool>> filter, params string[] IncludeProperties)
        {
            return await _uow.OrderDetailRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task RemoveAsync(OrderDetail Entity)
        {
            await _uow.OrderDetailRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(OrderDetail Entity)
        {
            await _uow.OrderDetailRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }

}
