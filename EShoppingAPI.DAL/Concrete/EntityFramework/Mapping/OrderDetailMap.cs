using EShoppingAPI.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using EShoppingAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EShoppingAPI.DAL.Concrete.EntityFramework.Mapping
{
    public class OrderDetailMap : BaseMap<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasOne(q => q.Product).WithMany(q => q.OrderDetail).HasForeignKey(q => q.OrderID).OnDelete(DeleteBehavior.Cascade);

        }

    }
}
