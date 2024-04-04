using Microsoft.EntityFrameworkCore;
using VClients.Api.Context;

namespace VClients.Api.Extensions;

public static class MigrationExtensiond
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        context.Database.Migrate();
    }
}