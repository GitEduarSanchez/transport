using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.TipoVehiculo.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class TipoVehiculoConfiguration
{
    public TipoVehiculoConfiguration(EntityTypeBuilder<TipoVehiculoEntity> builder)
    {
        builder.ToTable("tipovehiculo");
        builder.HasKey(x => x.IdTipoVehiculo);
        builder.Property(x => x.IdTipoVehiculo).HasColumnName("idtipovehiculo");
        builder.Property(x => x.descripcion).HasColumnName("descripcion");
    }
}
