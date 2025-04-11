using Hx.ArchivaFlow.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.ArchivaFlow.EntityFrameworkCore
{
    public class EfCoreAchiveRepository(IDbContextProvider<ArchivaFlowDbContext> dbContextProvider) 
        : EfCoreRepository<ArchivaFlowDbContext, Archive, Guid>(dbContextProvider), IEfCoreAchiveRepository
    {

    }
}
