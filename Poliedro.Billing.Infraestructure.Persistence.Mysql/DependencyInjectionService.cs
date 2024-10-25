using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poliedro.Billing.Domain.Concepto.Ports;
using Poliedro.Billing.Domain.Conductor.Ports;
using Poliedro.Billing.Domain.Origen.Ports;
using Poliedro.Billing.Domain.Destino.Ports;
using Poliedro.Billing.Domain.ControlViaje.Ports;
using Poliedro.Billing.Domain.Estado.Ports;
using Poliedro.Billing.Domain.Ports;
using Poliedro.Billing.Domain.Producto.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Adapter;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Conductor.Adapter;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Estado.Adapter;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Origen.Adapter;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Destino.Adapter;



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
         services.AddTransient<IOrigenRepository, OrigenRepository>();
        services.AddTransient<IDestinoRepository, DestinoRepository>();
        services.AddTransient<IControlViajeRepository, ControlViaje.Adapter.ControlViajeRepository>();
        return services;
    }
}
