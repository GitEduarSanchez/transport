using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.Concepto.Entities;


namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class ConceptoConfiguration
{
    public ConceptoConfiguration(EntityTypeBuilder<ConceptoEntity> builder)
    {
        builder.ToTable("concepto");
        builder.HasKey(x => x.IdConcepto);
        builder.Property(x => x.IdConcepto).HasColumnName("idconcepto");
        builder.Property(x => x.descripcion).HasColumnName("descripcion");
    }
}
