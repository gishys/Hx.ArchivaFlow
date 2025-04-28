using Hx.Abp.Attachment.Application.Contracts;
using Hx.Abp.Attachment.Domain.Shared;
using Hx.ArchivaFlow.Application.Contracts;
using Hx.ArchivaFlow.Domain.Shared;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Hx.ArchivaFlow.Attachment.Application
{
    public class ArchiveFileAppService(
        IAttachCatalogueAppService catalogueAppService,
        HttpClient httpClient
            ) : ApplicationService, IArchiveFileAppService
    {
        private readonly IAttachCatalogueAppService _catalogueAppService = catalogueAppService;
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<ArchiveCatalogueDto>> CreateCatalogueAsync(List<ArchiveCatalogueCreateDto> input, ArchiveCatalogueCreateMode mode)
        {
            CatalogueCreateMode cMode = CatalogueCreateMode.Overlap;
            switch (mode)
            {
                case ArchiveCatalogueCreateMode.SkipExistAppend:
                    cMode = CatalogueCreateMode.SkipExistAppend;
                    break;
            }
            var result = await _catalogueAppService.CreateManyAsync(
                ObjectMapper.Map<List<ArchiveCatalogueCreateDto>, List<AttachCatalogueCreateDto>>(input), cMode);
            return ObjectMapper.Map<List<AttachCatalogueDto>, List<ArchiveCatalogueDto>>(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogueId"></param>
        /// <param name="input"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public async Task CreateFilesAsync(Guid catalogueId, List<ArchiveFileCreateDto> input, ArchiveFileCreateMode mode)
        {
            var inputDic = input.GroupBy(d => d.ArchiveFileType);
            foreach (var item in inputDic)
            {
                if (item.Key == ArchiveFileType.FileBytes)
                {
                    var list = new List<AttachFileCreateDto>();
                    foreach (var file in item.ToList())
                    {
                        if (file.DocumentContent != null)
                        {
                            list.Add(new AttachFileCreateDto()
                            {
                                FileAlias = file.AliasName,
                                DocumentContent = file.DocumentContent
                            });
                        }
                    }
                    var result = await _catalogueAppService.CreateFilesAsync(catalogueId, list);
                }
                else if (item.Key == ArchiveFileType.Path)
                {
                    var list = new List<AttachFileCreateDto>();
                    foreach (var file in item.ToList())
                    {
                        try
                        {
                            HttpResponseMessage response = await _httpClient.GetAsync(file.FilePath);
                            response.EnsureSuccessStatusCode();
                            var documentContent = await response.Content.ReadAsByteArrayAsync();
                            list.Add(new AttachFileCreateDto()
                            {
                                FileAlias = file.AliasName,
                                DocumentContent = documentContent
                            });
                        }
                        catch (HttpRequestException ex)
                        {
                            throw new UserFriendlyException(message: ex.StackTrace ?? ex.Message);
                        }
                    }
                    var result = await _catalogueAppService.CreateFilesAsync(catalogueId, list);
                }
            }
        }

        public Task DeleteCatalogueAsync(Guid id)
        {
            return _catalogueAppService.DeleteAsync(id);
        }

        public Task DeleteFileAsync(Guid id)
        {
            return _catalogueAppService.DeleteSingleFileAsync(id);
        }

        public async Task<List<ArchiveCatalogueDto>> GetListByReferenceAsync(List<GetArchiveCatalogueListInput> input)
        {
            var result = await _catalogueAppService.FindByReferenceAsync(
                ObjectMapper.Map<List<GetArchiveCatalogueListInput>, List<GetAttachListInput>>(input));
            return ObjectMapper.Map<List<AttachCatalogueDto>, List<ArchiveCatalogueDto>>(result);
        }
    }
}