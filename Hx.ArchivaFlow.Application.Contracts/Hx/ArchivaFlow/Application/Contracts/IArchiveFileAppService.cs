namespace Hx.ArchivaFlow.Application.Contracts
{
    public interface IArchiveFileAppService
    {
        Task CreateFilesAsync(List<ArchiveFileCreateDto> input, ArchiveFileCreateMode mode);
        Task CreateCatalogueAsync(List<ArchiveCatalogueCreateDto> input, ArchiveCatalogueCreateMode mode);
        Task DeleteFileAsync(Guid id);
        Task DeleteCatalogueAsync(Guid id);
        Task GetListByReferenceAsync(GetArchiveCatalogueListInput input);
    }
}