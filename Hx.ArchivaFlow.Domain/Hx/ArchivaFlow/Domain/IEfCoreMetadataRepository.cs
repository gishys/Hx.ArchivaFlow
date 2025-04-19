using Volo.Abp.Domain.Repositories;

namespace Hx.ArchivaFlow.Domain
{
    public interface IEfCoreMetadataRepository : IBasicRepository<Metadata>
    {
        Task<Metadata> UpdateByKeysAsync(string key, Guid archiveId, string value);
    }
}
