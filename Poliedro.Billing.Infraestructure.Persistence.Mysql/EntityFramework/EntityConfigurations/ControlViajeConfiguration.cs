using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.ControlViaje.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class ControlViajeConfiguration
{
    public ControlViajeConfiguration(EntityTypeBuilder<ControlViajeEntity> builder)
    {
        builder.ToTable("controlviaje");
        builder.HasKey(x => x.idControlViaje);
        builder.Property(x => x.fecha).HasColumnName("fecha");
        builder.Property(x => x.guia).HasColumnName("guia");
        builder.Property(x => x.idVehiculoTrailer).HasColumnName("idvehiculotrailer");
    }
}
