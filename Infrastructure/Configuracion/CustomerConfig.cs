using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace SNET.WEBSINAI.Data.SqlServer.Configuracion
{
    public class CustomersConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder
                .Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder
                .Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");
        }
    }
}
