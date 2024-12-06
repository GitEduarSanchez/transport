using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.unidad_medida.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class unidad_medidaConfiguration
{
    public unidad_medidaConfiguration(EntityTypeBuilder<unidad_medidaEntity> builder)
    {
        builder.ToTable("unidad_medida");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("idunidad_medida");
        builder.Property(x => x.descripcion).HasColumnName("descripcion");
        
    }
}
