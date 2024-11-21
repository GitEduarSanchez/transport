using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.pais.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class paisConfiguration
{
    public paisConfiguration(EntityTypeBuilder<paisEntity> builder)
    {
        builder.ToTable("pais");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("idpais");
        builder.Property(x => x.Descripcion).HasColumnName("descripcion");
        
    }
}
