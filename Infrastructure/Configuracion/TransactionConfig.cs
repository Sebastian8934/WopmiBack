using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace SNET.WEBSINAI.Data.SqlServer.Configuracion
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("[Transaction]");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.TransactionNumber)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder
                .Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder
                .Property(e => e.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder
                .Property(e => e.BaseFee)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder
                .Property(e => e.DeliveryFee)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder
                .Property(e => e.CreatedAt)
                .HasMaxLength(10)
                .HasColumnType("dateTime");

            builder
                .Property(e => e.UpdatedAt)
                .HasMaxLength(10)
                .HasColumnType("decimal");

        }
    }
}
