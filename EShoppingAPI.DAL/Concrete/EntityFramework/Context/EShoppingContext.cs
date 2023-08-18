using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShoppingAPI.DAL.Concrete.EntityFramework.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EShoppingAPI.DAL.Concrete.EntityFramework.Context
{
    public class EShoppingContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source= LAPTOP-3MT9G9C1\\SQLEXPRESS;Initial Catalog=EShopping;" +
                    "Integrated Security=True; TrustServerCertificate=True ");
            }




            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderDetailMap());
           

            base.OnModelCreating(modelBuilder);
        }

    }
}
