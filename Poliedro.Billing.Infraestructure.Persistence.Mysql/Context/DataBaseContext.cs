﻿using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.Concepto.Entities;
using Poliedro.Billing.Domain.Ciudad.Entities;
using Poliedro.Billing.Domain.pais.Entities;
using Poliedro.Billing.Domain.ControlViajeProducto.Entities;
using Poliedro.Billing.Domain.Conductor.Entities;
using Poliedro.Billing.Domain.Producto.Entities;
using Poliedro.Billing.Domain.unidad_medida.Entities;
using Poliedro.Billing.Domain.ControlViaje.Entities;
using Poliedro.Billing.Domain.Estado.Entities;
using Poliedro.Billing.Domain.Descargue.Entities;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;
using Poliedro.Billing.Domain.CategoriaDocumento.Entities;
using Poliedro.Billing.Domain.departamento.Entities;
using Poliedro.Billing.Domain.Origen.Entities;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

public class DataBaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ConductorEntity> Conductor { get; set; }
    public DbSet<ProductoEntity> Producto { get; set; } 
    public DbSet<unidad_medidaEntity> unidad_medida { get; set; }
    public DbSet<ConceptoEntity> Concepto { get; set; }
    public DbSet<ControlViajeEntity> ControlViaje { get; set; }
    public DbSet<EstadoEntity> Estado { get; set; }
    public DbSet<CiudadEntity> Ciudad { get; set; }
    public DbSet<paisEntity> pais { get; set; }
    public DbSet<departamentoEntity> departamento { get; set; }
    public DbSet<DescargueEntity> Descargue { get; set; }
    public DbSet<ControlViajeProductoEntity> ControlViajeProducto { get; set; }
     public DbSet<CategoriaDocumentoEntity> CategoriaDocumento { get; set; }
    
    public DbSet<OrigenEntity> Origen { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        EntityConfiguration(modelBuilder);
    }

    private static void EntityConfiguration(ModelBuilder modelBuilder)
    {
        new ConductorConfiguration(modelBuilder.Entity<ConductorEntity>());
        new ProductoConfiguration(modelBuilder.Entity<ProductoEntity>());
        new unidad_medidaConfiguration(modelBuilder.Entity<unidad_medidaEntity>());
        new ConceptoConfiguration(modelBuilder.Entity<ConceptoEntity>());
        new ControlViajeConfiguration(modelBuilder.Entity<ControlViajeEntity>());
        new CiudadConfiguration(modelBuilder.Entity<CiudadEntity>());
        new paisConfiguration(modelBuilder.Entity<paisEntity>());
        new departamentoConfiguration(modelBuilder.Entity<departamentoEntity>());
        new ControlViajeProductoConfiguration(modelBuilder.Entity<ControlViajeProductoEntity>());
        new DescargueConfiguration(modelBuilder.Entity<DescargueEntity>());
        new EstadoConfiguration(modelBuilder.Entity<EstadoEntity>());
        new CategoriaDocumentoConfiguration(modelBuilder.Entity<CategoriaDocumentoEntity>());
        new OrigenConfiguration(modelBuilder.Entity<OrigenEntity>());
    }
    }
    



   