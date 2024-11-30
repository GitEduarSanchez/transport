using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.CategoriaDocumento.Entities;
using Poliedro.Billing.Domain.CategoriaDocumento.Ports;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class CategoriaDocumentoConfiguration
{
    public CategoriaDocumentoConfiguration(EntityTypeBuilder<CategoriaDocumentoEntity> builder)
    {
        builder.ToTable("CategoriaDocumento");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("idCategoriaDocumento");
        builder.Property(x => x.descripcion).HasColumnName("descripcion");
    
    }
}
