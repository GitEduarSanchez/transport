﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliedro.Billing.Domain.Destino.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

public class DestinoConfiguration
{
    public DestinoConfiguration(EntityTypeBuilder<DestinoEntity> builder)
    {
        builder.ToTable("Destino");
        builder.HasKey(x => x.idDestino);
        builder.Property(x => x.idDestino).HasColumnName("idDestino");
        builder.Property(x => x.Descripcion).HasColumnName("Desripcion");
    }
}
