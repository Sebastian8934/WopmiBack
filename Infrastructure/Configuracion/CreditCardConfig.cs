using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace SNET.WEBSINAI.Data.SqlServer.Configuracion
{
    public class CreditCardConfig : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CardNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder
                .Property(e => e.CardholderName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder
                .Property(e => e.ExpirationDate)
                .IsRequired()
                .HasMaxLength(7)
                .HasColumnType("varchar(7)");

            builder
                .Property(e => e.Cvv)
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnType("varchar(4)");

        }
    }
}
