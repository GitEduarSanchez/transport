using Autofac.Core;
using Microsoft.AspNetCore.Hosting;
using Poliedro.Billing.Api;
using Poliedro.Billing.Application;
using Poliedro.Billing.Infraestructure.Persistence.Mysql;
using WorkerServiceBilling;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services
    .AddWebApi()
    .AddApplication()
    .AddPersistence(config);

builder.Services.AddControllers();
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);
builder.Services.AddHostedService<Worker>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();
app.Run();


