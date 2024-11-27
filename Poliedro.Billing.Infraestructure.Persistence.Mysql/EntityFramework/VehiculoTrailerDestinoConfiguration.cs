using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.VehiculoTrailerDestino.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class VehiculoTrailerDestinoConfiguration
{
    public VehiculoTrailerDestinoConfiguration(EntityTypeBuilder<VehiculoTrailerDestinoEntity> builder)
    {
        builder.ToTable("vehiculotrailerdestino");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.dvehiculotrailer).HasColumnName("idvehiculotrailer");
        builder.Property(x => x.iddestino).HasColumnName("iddestino");
        builder.Property(x => x.idcuidad).HasColumnName("idciudad");
    }
}
