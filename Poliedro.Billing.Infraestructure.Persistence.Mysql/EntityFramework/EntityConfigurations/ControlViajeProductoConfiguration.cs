using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.ControlViajeProducto.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class ControlViajeProductoConfiguration
{
    public ControlViajeProductoConfiguration(EntityTypeBuilder<ControlViajeProductoEntity> builder)
    {
        builder.ToTable("controlviaje_producto");
        builder.HasKey(x => x.idControlViajeProducto);
        builder.Property(x => x.idControlViajeProducto).HasColumnName("idcontrolviaje_producto");
        builder.Property(x => x.idControlViaje).HasColumnName("idcontrolviaje");
        builder.Property(x => x.idProducto).HasColumnName("idproducto");
    }
}
