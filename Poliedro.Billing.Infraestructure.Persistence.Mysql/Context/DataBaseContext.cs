using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.Concepto.Entities;
using Poliedro.Billing.Domain.Conductor.Entities;
using Poliedro.Billing.Domain.ViajeOrigen.Entities;
using Poliedro.Billing.Domain.Destino.Entities;
using Poliedro.Billing.Domain.Producto.Entities;
using Poliedro.Billing.Domain.ControlViaje.Entities;
using Poliedro.Billing.Domain.Estado.Entities;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

public class DataBaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ConductorEntity> Conductor { get; set; }
    public DbSet<ViajeOrigenEntity> ViajeOrigen { get; set; }
    public DbSet<ProductoEntity> Producto { get; set; } 
    public DbSet<ConceptoEntity> Concepto { get; set; }
    public DbSet<ControlViajeEntity> ControlViaje { get; set; }
    public DbSet<EstadoEntity> Estado { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        EntityConfiguration(modelBuilder);
    }

    private static void EntityConfiguration(ModelBuilder modelBuilder)
    {
        new ConductorConfiguration(modelBuilder.Entity<ConductorEntity>());
        new ProductoConfiguration(modelBuilder.Entity<ProductoEntity>());
        new ConceptoConfiguration(modelBuilder.Entity<ConceptoEntity>());
        new ControlViajeConfiguration(modelBuilder.Entity<ControlViajeEntity>());
        new DestinoConfiguration(modelBuilder.Entity<DestinoEntity>());
        new EstadoConfiguration(modelBuilder.Entity<EstadoEntity>());
    }
    }



   