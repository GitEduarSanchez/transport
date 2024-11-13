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
        builder.Property(x => x.Id).HasColumnName("idControlViajeOrigen");
        builder.Property(x => x.idcontrolviaje).HasColumnName("idcontrolviaje");
        builder.Property(x => x.idorigen).HasColumnName("idorigen");
        builder.Property(x => x.idciudad).HasColumnName("idciudad");

        
    }
}
