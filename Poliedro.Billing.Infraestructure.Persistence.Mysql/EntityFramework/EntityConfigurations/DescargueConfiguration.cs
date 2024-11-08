using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.Descargue.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class DescargueConfiguration
{

    public DescargueConfiguration(EntityTypeBuilder<DescargueEntity> builder)
    {
        builder.ToTable("descargue");
        builder.HasKey(x => x.iddescargue);
        builder.Property(x => x.iddescargue).HasColumnName("iddescargue");
        builder.Property(x => x.descriocion).HasColumnName("descriocion");
    }

}
