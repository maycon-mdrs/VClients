using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using VClients.Api.Context;
using VClients.Api.Extensions;
using VClients.Api.Repositories;
using VClients.Api.Repositories.Interfaces;
using VClients.Api.Services;
using VClients.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

/*
 * https://www.mailslurp.com/blog/how-to-set-appsettings-config-property-with-environment-variable/
 */
//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var postgresConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(postgresConnection));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

/*
 * https://stackoverflow.com/questions/48285408/how-to-disable-cors-completely-in-webapi
 */
app.UseCors(policy => policy
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();