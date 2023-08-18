using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EShoppingAPI.Business.Abstract;
using EShoppingAPI.DAL.Abstract.DataManagment;
using EShoppingAPI.Entity.Poco;

namespace EShoppingAPI.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnıtOfWork _uow;

        public CategoryManager(IUnıtOfWork uow)
        {
            _uow = uow;
        }



        public async Task<Category> GetAsync(Expression<Func<Category, bool>> filter, params string[] IncludeProperties)
        {
            return await _uow.CategoryRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>> filter = null, params string[] IncludeProperties)
        {
            return await _uow.CategoryRepository.GetAllAsync(filter, IncludeProperties);
        }

        public async Task<Category> AddAsync(Category Entity)
        {
            await _uow.CategoryRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task UpdateAsync(Category Entity)
        {
            await _uow.CategoryRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task RemoveAsync(Category Entity)
        {
            await _uow.CategoryRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }


    }

}


