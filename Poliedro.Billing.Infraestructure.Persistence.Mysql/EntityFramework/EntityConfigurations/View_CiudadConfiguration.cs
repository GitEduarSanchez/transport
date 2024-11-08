using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.Ciudad.Entities;
using Poliedro.Billing.Domain.Ciudad.Ports;
using Poliedro.Billing.Domain.View_Ciudad.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class View_CiudadConfiguration
{
    private EntityTypeBuilder<View_CiudadEntity> entityTypeBuilder;

    public View_CiudadConfiguration(EntityTypeBuilder<CiudadEntity> builder)
    {
        builder.ToTable("v_ciudad");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("idciudad");
        builder.Property(x => x.Descripcion).HasColumnName("descripcion");
        builder.Property(x => x.Iddepartamento).HasColumnName("iddepartamento");
    }

    public View_CiudadConfiguration(EntityTypeBuilder<View_CiudadEntity> entityTypeBuilder)
    {
        this.entityTypeBuilder = entityTypeBuilder;
    }
}
