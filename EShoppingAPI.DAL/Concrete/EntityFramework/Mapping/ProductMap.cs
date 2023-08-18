using EShoppingAPI.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using EShoppingAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EShoppingAPI.DAL.Concrete.EntityFramework.Mapping
{
    public class ProductMap : BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(q => q.Name).HasMaxLength(1000).IsRequired();
            builder.HasOne(q => q.Category).WithMany(x => x.Products).HasForeignKey(q => q.CategoryID).OnDelete(DeleteBehavior.Cascade);


        }

    }
}
