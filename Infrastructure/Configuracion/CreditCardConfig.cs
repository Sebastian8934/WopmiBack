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
                .HasMaxLength(20);

            builder
                .Property(e => e.CardholderName)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(e => e.ExpirationDate)
                .IsRequired()
                .HasMaxLength(7);

            builder
                .Property(e => e.Cvv)
                .IsRequired()
                .HasMaxLength(3);

            builder
                .Property(e => e.CustomerId)
                .IsRequired();

            // Configuración de la clave foránea
            builder.HasOne(e => e.Customer)
                .WithMany(c => c.CreditCards)
                .HasForeignKey(e => e.CustomerId);
                //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}
