using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace SNET.WEBSINAI.Data.SqlServer.Configuracion
{
    public class TransactionItemtConfig : IEntityTypeConfiguration<TransactionItem>
    {
        public void Configure(EntityTypeBuilder<TransactionItem> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.TransactionId)
                .IsRequired();

            builder
                .Property(e => e.ProductId)
                .IsRequired();

            builder
                .Property(e => e.Quantity)
                .IsRequired();

            builder
                .Property(e => e.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

        }
    }
}
