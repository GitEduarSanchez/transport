using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.Ciudad.Entities;
using Poliedro.Billing.Domain.Ciudad.Ports;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class CiudadConfiguration
{
    public CiudadConfiguration(EntityTypeBuilder<CiudadEntity> builder)
    {
        builder.ToTable("ciudad");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("idciudad");
        builder.Property(x => x.Descripcion).HasColumnName("descripcion");
        builder.Property(x => x.Iddepartamento).HasColumnName("iddepartamento");
    }
}
