using Hx.ArchivaFlow.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.ArchivaFlow.EntityFrameworkCore
{
    internal class EfCoreMetadataRepository(IDbContextProvider<ArchivaFlowDbContext> dbContextProvider)
        : EfCoreRepository<ArchivaFlowDbContext, Metadata, Guid>(dbContextProvider), IEfCoreMetadataRepository
    {
    }
}
