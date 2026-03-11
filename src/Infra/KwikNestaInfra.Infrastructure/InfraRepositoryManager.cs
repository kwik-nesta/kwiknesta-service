using KwikNestaInfra.Infrastructure.Contracts;
using KwikNestaInfra.Infrastructure.Data;
using KwikNestaInfra.Infrastructure.Repositories;

namespace KwikNestaInfra.Infrastructure
{
    public class InfraRepositoryManager(InfraServiceDbContext context) : IInfraRepositoryManager
    {
        private readonly Lazy<IAuditLogRepository> _auditLogRepository =
            new Lazy<IAuditLogRepository>(() => new AuditLogRepository(context));

        private readonly InfraServiceDbContext _context = context;

        public IAuditLogRepository AuditLog => _auditLogRepository.Value;

        public async Task BeginTransaction(Func<Task> action)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await action();

                await SaveAsync();
                await transaction.CommitAsync();

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}