using KwikNestaInfra.Infrastructure.Contracts;

namespace KwikNestaInfra.Infrastructure
{
    public interface IInfraRepositoryManager
    {
        IAuditLogRepository AuditLog { get; }

        Task BeginTransaction(Func<Task> action);
        Task SaveAsync();
    }
}