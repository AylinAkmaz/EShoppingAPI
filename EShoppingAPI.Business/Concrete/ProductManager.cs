using System.Linq.Expressions;
using EShoppingAPI.Business.Abstract;
using EShoppingAPI.DAL.Abstract.DataManagment;
using EShoppingAPI.Entity.Poco;

namespace EShoppingAPI.Business.Concrete
{
    public class ProductManager : IProductService
    {

        private readonly IUnıtOfWork _uow;

        public ProductManager(IUnıtOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Product> AddAsync(Product Entity)
        {
            await _uow.ProductRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null, params string[] IncludeProperties)
        {
            return await _uow.ProductRepository.GetAllAsync(filter, IncludeProperties);
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> filter, params string[] IncludeProperties)
        {
            return await _uow.ProductRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task RemoveAsync(Product Entity)
        {
            await _uow.ProductRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();

        }

        public async Task UpdateAsync(Product Entity)
        {
            await _uow.ProductRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }

}
