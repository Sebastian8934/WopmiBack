using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace SNET.WEBSINAI.Data.SqlServer.Configuracion
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder
                .Property(e => e.Description)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder
                .Property(e => e.Price)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder
                .Property(e => e.StockQuantity)
                .IsRequired();

        }
    }
}
