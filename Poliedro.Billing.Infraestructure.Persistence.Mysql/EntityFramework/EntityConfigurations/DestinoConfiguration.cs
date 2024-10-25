using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.Destino.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class DestinoConfiguration
{
    public DestinoConfiguration(EntityTypeBuilder<DestinoEntity> builder)
    {
        builder.ToTable("destino");
        builder.HasKey(x => x.iddestino);
        builder.Property(x => x.iddestino).HasColumnName("iddestino");
        builder.Property(x => x.descripcion).HasColumnName("descripcion");
    }
}
