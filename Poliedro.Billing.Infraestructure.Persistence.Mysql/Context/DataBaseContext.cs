using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.Concepto.Entities;
using Poliedro.Billing.Domain.Ciudad.Entities;
using Poliedro.Billing.Domain.ControlViajeProducto.Entities;
using Poliedro.Billing.Domain.Ciudad.Entities;
using Poliedro.Billing.Domain.ControlViajeProducto.Entities;
using Poliedro.Billing.Domain.Conductor.Entities;
using Poliedro.Billing.Domain.Destino.Entities;
using Poliedro.Billing.Domain.Producto.Entities;
using Poliedro.Billing.Domain.ControlViaje.Entities;
using Poliedro.Billing.Domain.Estado.Entities;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.EntityFramework.EntityConfigurations;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

public class DataBaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ConductorEntity> Conductor { get; set; }
    public DbSet<ProductoEntity> Producto { get; set; } 
    public DbSet<ConceptoEntity> Concepto { get; set; }
    public DbSet<ControlViajeEntity> ControlViaje { get; set; }
    public DbSet<EstadoEntity> Estado { get; set; }
    public DbSet<DescargueEntity> Descargue { get; set; }
    public DbSet<DestinoEntity> Destino { get; set; }
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
        new DestinoConfiguration(modelBuilder.Entity<DestinoEntity>());
        new EstadoConfiguration(modelBuilder.Entity<EstadoEntity>());
    }
    }

public class DescargueEntity
{
}


