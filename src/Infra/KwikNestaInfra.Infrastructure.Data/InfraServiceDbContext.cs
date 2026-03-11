using KwikNestaIdentity.Infrastructure.Data.Configurations;
using KwikNestaInfra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KwikNestaInfra.Infrastructure.Data
{
    public class InfraServiceDbContext : DbContext
    {
        public DbSet<AuditLog> AuditLogs { get; set; }

        public InfraServiceDbContext(DbContextOptions<InfraServiceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("kn-infra-svc");
            builder.ApplyConfiguration(new AuditLogConfigurations());

            base.OnModelCreating(builder);
        }
    }
}