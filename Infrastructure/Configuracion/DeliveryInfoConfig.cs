using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace SNET.WEBSINAI.Data.SqlServer.Configuracion
{
    public class DeliveryInfoConfig : IEntityTypeConfiguration<DeliveryInfo>
    {
        public void Configure(EntityTypeBuilder<DeliveryInfo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Address)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder
                .Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder
                .Property(e => e.State)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder
                .Property(e => e.ZipCode)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            builder
                .Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder
                .Property(e => e.CustomerId)
                .IsRequired();
        }
    }
}
