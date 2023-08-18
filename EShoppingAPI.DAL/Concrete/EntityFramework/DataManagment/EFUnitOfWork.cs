using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShoppingAPI.DAL.Abstract.DataManagment;
using EShoppingAPI.DAL.Abstract;
using EShoppingAPI.Entity.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using EShoppingAPI.DAL.Concrete.EntityFramework.Context;

namespace EShoppingAPI.DAL.Concrete.EntityFramework.DataManagment
{
    public class EFUnitOfWork : IUnıtOfWork
    {
        private readonly EShoppingContext _eShoppingContext;
        private readonly IHttpContextAccessor _contextAccessor;
        public EFUnitOfWork(EShoppingContext eShoppingContext, IHttpContextAccessor contextAccessor)
        {
            _eShoppingContext = eShoppingContext;
            _contextAccessor = contextAccessor;

            CategoryRepository = new EFCategoryRepository(_eShoppingContext);
            UserRepository = new EFUserRepository(_eShoppingContext);
            OrderRepository = new EFOrderRepository(_eShoppingContext);
            OrderDetailRepository = new EFOrderDetailRepository(_eShoppingContext);
            ProductRepository = new EFProductRepository(_eShoppingContext);

        }
        public ICategoryRepository CategoryRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderDetailRepository OrderDetailRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IUserRepository UserRepository { get; }

        public async Task<int> SaveChangeAsync()
        {
            foreach (var item in _eShoppingContext.ChangeTracker.Entries<AuditableEntity>())
            {
                if (item.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    item.Entity.AddedTime = DateTime.Now;
                    item.Entity.UpdateTime = DateTime.Now;
                    item.Entity.AddedUser = 1;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.GUID= Guid.NewGuid();
                    item.Entity.AddedIPV4Adress = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    item.Entity.UpdatedIPV4Adress = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                    if (item.Entity.IsActive == null)
                    {
                        item.Entity.IsActive = true;
                    }

                    item.Entity.IsDeleted = false;

                }
                else if (item.State == EntityState.Modified)
                {
                    item.Entity.UpdateTime = DateTime.Now;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.UpdatedIPV4Adress = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }

            }
            return await _eShoppingContext.SaveChangesAsync();

        }
    }

}
