using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.categoria_documento.Entities;
using Poliedro.Billing.Domain.categoria_documento.Ports;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class categoria_documentoConfiguration
{
    public categoria_documentoConfiguration(EntityTypeBuilder<categoria_documentoEntity> builder)
    {
        builder.ToTable("categoria_documento");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("idcategoria_documento");
        builder.Property(x => x.Descripcion).HasColumnName("descripcion");
    
    }
}
