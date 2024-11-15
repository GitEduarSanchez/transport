using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Poliedro.Billing.Domain.controlviaje_origen.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class controlviaje_origenConfiguration
{
    public controlviaje_origenConfiguration(EntityTypeBuilder<controlviaje_origenEntity> builder)
    {
        builder.ToTable("controlviaje_origen");
        builder.HasKey(x => x.idcontrolviaje_origen);
        builder.Property(x => x.idcontrolviaje_origen).HasColumnName("idcontrolviaje_origen");
        builder.Property(x => x.idcontrolviaje).HasColumnName("idcontrolviaje");
        builder.Property(x => x.idorigen).HasColumnName("idorigen");
        builder.Property(x => x.idciudad).HasColumnName("idciudad");

        
    }
}
