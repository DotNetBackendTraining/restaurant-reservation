using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Db.Configuration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable(i => i.HasCheckConstraint("CK_OrderItems_Quantity", "Quantity >= 0"));

        builder.HasData(ModelsData.OrderItems());
    }
}