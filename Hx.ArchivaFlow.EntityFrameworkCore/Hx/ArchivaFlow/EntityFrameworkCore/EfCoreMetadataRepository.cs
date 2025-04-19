using Hx.ArchivaFlow.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.ArchivaFlow.EntityFrameworkCore
{
    internal class EfCoreMetadataRepository(IDbContextProvider<ArchivaFlowDbContext> dbContextProvider)
        : EfCoreRepository<ArchivaFlowDbContext, Metadata>(dbContextProvider), IEfCoreMetadataRepository
    {
        public virtual async Task<Metadata> UpdateByKeysAsync(string key, Guid archiveId, string value)
        {
            var dbContext = await GetDbContextAsync();
            var entity = await dbContext.Metadata.FirstAsync(d => d.Key == key && d.ArchiveId == archiveId);
            entity.SetValue(value);
            return await UpdateAsync(entity);
        }
    }
}
