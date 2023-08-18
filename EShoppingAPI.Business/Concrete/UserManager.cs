using System.Linq.Expressions;
using EShoppingAPI.Business.Abstract;
using EShoppingAPI.DAL.Abstract.DataManagment;
using EShoppingAPI.Entity.Poco;

namespace EShoppingAPI.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnıtOfWork _uow;

        public UserManager(IUnıtOfWork uow)
        {
            _uow = uow;
        }

        public async Task<User> AddAsync(User Entity)
        {
            await _uow.UserRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> filter = null, params string[] IncludeProperties)
        {
            return await _uow.UserRepository.GetAllAsync(filter, IncludeProperties);
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> filter, params string[] IncludeProperties)
        {
            return await _uow.UserRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task RemoveAsync(User Entity)
        {
            await _uow.UserRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(User Entity)
        {
            await _uow.UserRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }

}
