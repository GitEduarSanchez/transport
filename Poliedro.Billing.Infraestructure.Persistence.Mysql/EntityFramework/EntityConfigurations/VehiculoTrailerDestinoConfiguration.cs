using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.VehiculoTrailerDestino.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class VehiculoTrailerDestinoConfiguration
{
    public VehiculoTrailerDestinoConfiguration(EntityTypeBuilder<VehiculoTrailerDestinoEntity> builder)
    {
        builder.ToTable("vehiculotrailer_destino");
        builder.HasKey(x => x.VehiculoTrailerDestino);
        builder.Property(x => x.VehiculoTrailerDestino).HasColumnName("vehiculotrailer_destino");
        builder.Property(x => x.dvehiculotrailer).HasColumnName("dvehiculotrailer");
        builder.Property(x => x.iddestino).HasColumnName("iddestino");
        builder.Property(x => x.idcuidad).HasColumnName("idcuidad");
    }
}
