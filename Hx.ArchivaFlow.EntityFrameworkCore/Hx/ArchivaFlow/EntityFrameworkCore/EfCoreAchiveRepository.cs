using Hx.ArchivaFlow.Domain;
using Hx.ArchivaFlow.Domain.Shared;
using Microsoft.EntityFrameworkCore;
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
            if (includeDetails)
            {
                query = query.Include(d => d.Metadatas.OrderBy(d => d.Order));
            }
            return await query.FirstOrDefaultAsync(cancellationToken: cancellationToken);
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
                .WhereIf(status != null, a => a.Status == status);

            // 处理metadata条件
            if (metadata != null)
            {
                foreach (var kvp in metadata)
                {
                    if (kvp.Value == null) continue;

                    string key = kvp.Key;
                    string value = kvp.Value.ToString()!;

                    query = query.Where(a => a.Metadatas
                        .Any(m => m.Key == key && m.Value.Contains(value)));
                }
            }

            if (includeDetails)
            {
                query = query.Include(d => d.Metadatas.OrderBy(d => d.Order));
            }

            return await query
                .OrderByDescending(d => d.CreationTime)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
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
                .WhereIf(status != null, a => a.Status == status);

            if (metadata != null)
            {
                foreach (var kvp in metadata)
                {
                    if (kvp.Value == null) continue;

                    string key = kvp.Key;
                    string value = kvp.Value.ToString()!;

                    query = query.Where(a => a.Metadatas
                        .Any(m => m.Key == key && m.Value.Contains(value)));
                }
            }

            return await query.CountAsync(cancellationToken: cancellationToken);
        }
        public async Task<Archive?> FindByArchiveNoAsync(string archiveNo, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            var query = from menu in dbContext.Archives where menu.ArchiveNo == archiveNo select menu;
            if (includeDetails)
            {
                query = query.Include(d => d.Metadatas.OrderBy(d => d.Order));
            }
            return await query.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
        public async Task<Archive?> FindByBusinessKeyAsync(string businessKey, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            var query = from menu in dbContext.Archives where menu.BusinessKey == businessKey select menu;
            if (includeDetails)
            {
                query = query.Include(d => d.Metadatas.OrderBy(d => d.Order));
            }
            return await query.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
