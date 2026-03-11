using KwikNesta.Shared.Contracts;
using KwikNesta.Shared.Implementations;
using KwikNestaInfra.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KwikNestaInfra.Infrastructure
{
    public static class InfraServiceDIExtensions
    {
        public static IServiceCollection ConfigureInfraServices(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                throw new ArgumentNullException("Connection string not set.");

            services.AddDbContext<InfraServiceDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services.AddScoped<IInfraRepositoryManager, InfraRepositoryManager>()
                .AddScoped<IAppAuditService, AppAuditService>();
        }

        public static WebApplication RunInfraServiceMigrations(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                using var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<InfraServiceDbContext>();
                db.Database.Migrate();
            }

            return app;
        }
    }
}