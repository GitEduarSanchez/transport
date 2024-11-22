using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.departamento.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class departamentoConfiguration
{
    public departamentoConfiguration(EntityTypeBuilder<departamentoEntity> builder)
    {
        builder.ToTable("departamento");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("iddepartamento");
        builder.Property(x => x.descripcion).HasColumnName("descripcion");
        builder.Property(x => x.idpais).HasColumnName("idpais");
    }
}
