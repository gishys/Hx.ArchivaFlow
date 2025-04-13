using Volo.Abp.Application.Services;

namespace Hx.ArchivaFlow.Application.Contracts
{
    public interface IArchiveFileAppService : IApplicationService
    {
        Task CreateFilesAsync(Guid catalogueId, List<ArchiveFileCreateDto> input, ArchiveFileCreateMode mode);
        Task<List<ArchiveCatalogueDto>> CreateCatalogueAsync(List<ArchiveCatalogueCreateDto> input, ArchiveCatalogueCreateMode mode);
        Task DeleteFileAsync(Guid id);
        Task DeleteCatalogueAsync(Guid id);
        Task<List<ArchiveCatalogueDto>> GetListByReferenceAsync(List<GetArchiveCatalogueListInput> input);
    }
}