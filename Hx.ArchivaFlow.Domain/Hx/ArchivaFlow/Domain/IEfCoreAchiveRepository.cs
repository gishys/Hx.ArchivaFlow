using Hx.ArchivaFlow.Domain.Shared;
using Volo.Abp.Domain.Repositories;

namespace Hx.ArchivaFlow.Domain
{
    public interface IEfCoreAchiveRepository : IBasicRepository<Archive, Guid>
    {
        Task<List<Archive>> GetPagedListAsync(
            string? archiveNo,
            string? businessKey,
            int? year,
            DateTime? startFilingDate,
            DateTime? endFilingDate,
            ArchiveStatus? status,
            IDictionary<string, object>? metadata,
            int skipCount,
            int maxResultCount,
            bool includeDetails = false,
            CancellationToken cancellationToken = default);
        Task<long> GetCountAsync(
            string? archiveNo,
            string? businessKey,
            int? year,
            DateTime? startFilingDate,
            DateTime? endFilingDate,
            ArchiveStatus? status,
            IDictionary<string, object>? metadata,
            CancellationToken cancellationToken = default);
        Task<Archive?> FindByArchiveNoAsync(string archiveNo, CancellationToken cancellationToken = default);
        Task<Archive?> FindByBusinessKeyAsync(string businessKey, CancellationToken cancellationToken = default);
    }
}
