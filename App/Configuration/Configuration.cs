using App.Infrastructure.Data;
using App.Middlewares;
using Microsoft.EntityFrameworkCore;
using MediatR;
using App.Infrastructure.ReadOnlyData;

namespace App.Configuration
{
    public static class Configuration
    {
        public static void ConfigureApplicationHandlers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Program));
        }

        public static void ConfigureDatabasesContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Write-Read
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Database")));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            // Read-only
            services.AddScoped<IReadOnlyContext, ReadOnlyContext>(options => 
                new ReadOnlyContext(configuration.GetConnectionString("ReadOnlyDatabase")));
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}