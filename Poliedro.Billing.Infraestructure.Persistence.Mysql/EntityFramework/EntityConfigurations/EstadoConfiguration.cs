using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Poliedro.Billing.Domain.Estado.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class EstadoConfiguration
{
    public EstadoConfiguration(EntityTypeBuilder<EstadoEntity> builder)
    {
        builder.ToTable("estado");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("idestado");
        builder.Property(x => x.Descripcion).HasColumnName("descripcion");
    }
}
