using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OCTM.Domain.Models;

namespace OCTM.Infra.Data.Mappings
{    
    public class ContainerShipMap : IEntityTypeConfiguration<ContainerShip>
    {
        public void Configure(EntityTypeBuilder<ContainerShip> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Color)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();   
        }
    }
}
