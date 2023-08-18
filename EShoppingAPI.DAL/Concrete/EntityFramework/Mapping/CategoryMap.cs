using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShoppingAPI.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using EShoppingAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShoppingAPI.DAL.Concrete.EntityFramework.Mapping
{
    public class CategoryMap : BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.Property(q => q.Name).HasMaxLength(500).IsRequired();
            //builder.HasMany(q=>q.Products).WithOne(q => q.Category).HasForeignKey(q=>q.Category).HasForeignKey(q=>q.CategoryID).OnDelete(DeleteBehavior.Cascade);//


        }




    }
}
