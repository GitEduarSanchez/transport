using WorkerServiceBilling;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();

public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices(services =>
                {
                    // Configurar CORS
                    services.AddCors(options =>
                    {
                        options.AddPolicy("AllowLocalhost4200", builder =>
                        {
                            builder.WithOrigins("http://localhost:4200")  // Permite solicitudes desde este origen
                                   .AllowAnyMethod()                    // Permite cualquier método (GET, POST, PUT, DELETE)
                                   .AllowAnyHeader();                   // Permite cualquier cabecera
                        });
                    });

                    services.AddControllers();  // Asegúrate de tener servicios de controlador configurados
                });

                webBuilder.Configure(app =>
                {
                    app.UseCors("AllowLocalhost4200");  // Aplica la política CORS
                    app.UseRouting();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                });
            });
