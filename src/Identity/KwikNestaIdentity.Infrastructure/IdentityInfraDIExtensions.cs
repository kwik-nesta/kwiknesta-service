using KwikNestaIdentity.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KwikNestaIdentity.Infrastructure
{
    public static class IdentityInfraDIExtensions
    {
        public static IServiceCollection ConfigureIdentityServiceDbContexts(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? 
                throw new ArgumentNullException("DefaultConnection");

            services.AddDbContext<IdentityServiceDbContext>(options =>
                options.UseNpgsql(connectionString,
                    m => m.MigrationsAssembly(typeof(IdentityServiceDbContext).Assembly.FullName)));

            return services;
        }

        public static WebApplication RunIdentityServiceMigrations(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                using var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<IdentityServiceDbContext>();
                db.Database.Migrate();
            }

            return app;
        }
    }
}