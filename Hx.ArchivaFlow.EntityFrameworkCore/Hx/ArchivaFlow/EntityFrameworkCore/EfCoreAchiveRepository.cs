using Hx.ArchivaFlow.Domain;
using Hx.ArchivaFlow.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.ArchivaFlow.EntityFrameworkCore
{
    public class EfCoreAchiveRepository(IDbContextProvider<ArchivaFlowDbContext> dbContextProvider)
        : EfCoreRepository<ArchivaFlowDbContext, Archive, Guid>(dbContextProvider), IEfCoreAchiveRepository
    {
        public override async Task<Archive?> FindAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            var query = from menu in dbContext.Archives where menu.Id == id select menu;
            if (includeDetails) { query.Include(d => d.Metadatas); }
            return await query.FirstAsync(cancellationToken: cancellationToken);
        }
        public async Task<List<Archive>> GetPagedListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();
            var query = dbSet
                .WhereIf(!string.IsNullOrEmpty(archiveNo), a => a.ArchiveNo.Contains($"{archiveNo}"))
                .WhereIf(!string.IsNullOrEmpty(businessKey), a => a.BusinessKey.Contains($"{businessKey}"))
                .WhereIf(year != null, a => a.Year == year)
                .WhereIf(startFilingDate != null, a => a.FilingDate >= startFilingDate)
                .WhereIf(endFilingDate != null, a => a.FilingDate <= endFilingDate)
                .WhereIf(status != null, a => a.Status == status)
                .WhereIf(metadata != null, a => a.Metadatas.Any(m => metadata != null && metadata.Any(e => m.Key == e.Key && m.Value == e.Value.ToString())));
            if (includeDetails) { query.Include(d => d.Metadatas); }
            return await query.OrderByDescending(d => d.CreationTime).PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken: cancellationToken);
        }
        public async Task<long> GetCountAsync(
            string? archiveNo,
            string? businessKey,
            int? year,
            DateTime? startFilingDate,
            DateTime? endFilingDate,
            ArchiveStatus? status,
            IDictionary<string, object>? metadata,
            CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();
            var query = dbSet
                .WhereIf(!string.IsNullOrEmpty(archiveNo), a => a.ArchiveNo.Contains($"{archiveNo}"))
                .WhereIf(!string.IsNullOrEmpty(businessKey), a => a.BusinessKey.Contains($"{businessKey}"))
                .WhereIf(year != null, a => a.Year == year)
                .WhereIf(startFilingDate != null, a => a.FilingDate >= startFilingDate)
                .WhereIf(endFilingDate != null, a => a.FilingDate <= endFilingDate)
                .WhereIf(status != null, a => a.Status == status)
                .WhereIf(metadata != null && metadata.Count > 0, a => a.Metadatas.Any(m => metadata != null && metadata.Any(e => m.Key == e.Key && m.Value == e.Value.ToString())));
            return await query.CountAsync(cancellationToken: cancellationToken);
        }
        public async Task<Archive> FindByArchiveNoAsync(string archiveNo, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            var query = from menu in dbContext.Archives where menu.ArchiveNo == archiveNo select menu;
            return await query.FirstAsync(cancellationToken: cancellationToken);
        }
    }
}
