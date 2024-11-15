using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poliedro.Billing.Domain.Concepto.Ports;
using Poliedro.Billing.Domain.Ciudad.Ports;
using Poliedro.Billing.Domain.Conductor.Ports;
using Poliedro.Billing.Domain.ControlViaje.Ports;
using Poliedro.Billing.Domain.ControlViajeProducto.Ports;
using Poliedro.Billing.Domain.Descargue.Ports;
using Poliedro.Billing.Domain.Ports;
using Poliedro.Billing.Domain.Trailer.Ports;
using Poliedro.Billing.Domain.Producto.Ports;
using Poliedro.Billing.Domain.Origen.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Adapter;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Concepto.Adapter;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Conductor.Adapter;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.ControlViajeProducto.Adapter;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Trailer.Adapter;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Producto.Adapter;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Estado.Adapter;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Descargue.Adapter;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Origen.Adapter;
using Poliedro.Billing.Domain.Estado.Entities.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Ciudad;


namespace Poliedro.Billing.Infraestructure.Persistence.Mysql;

public static class DependencyInjectionService
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION") ?? configuration.GetConnectionString("MysqlConnection");
        services.AddDbContext<DataBaseContext>(
            options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)
        ));

        services.AddTransient<IMessageProvider, MessageProvider>();
        services.AddTransient<IConductorRepository, ConductorRepository>();
        services.AddTransient<IProductoRepository, ProductoRepository>();
        services.AddTransient<IConceptoRepository, ConceptoRepository>();
        services.AddTransient<ITrailerRepository, TrailerRepository>();

        services.AddTransient<IControlViajeRepository, ControlViaje.Adapter.ControlViajeRepository>();
        services.AddTransient<IEstadoRepository, EstadoRepository>();
        services.AddTransient<ICiudadRepository, CiudadRepository>();
        services.AddTransient<IView_CiudadRepository, View_CiudadRepository>();
        services.AddTransient<IControlViajeProductoRepository, ControlViajeProductoRepository>();
        services.AddTransient<IDescargueRepository, DescargueRepository>();
        services.AddTransient<IOrigenRepository, OrigenRepository>();
        return services;
    }
}
