using Hx.ArchivaFlow.Application.Contracts;
using Hx.ArchivaFlow.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hx.ArchiveFlow.Application
{
    public class ArchiveAppService(
        ArchiveDomainService archiveDomainService,
        IEfCoreAchiveRepository archiveRepository,
        IEfCoreMetadataRepository metadataRepository,
        IServiceProvider serviceProvider) : ApplicationService, IArchiveAppService
    {
        private readonly ArchiveDomainService _archiveDomainService = archiveDomainService;
        private readonly IEfCoreAchiveRepository _archiveRepository = archiveRepository;
        private readonly IEfCoreMetadataRepository _metadataRepository = metadataRepository;
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        /// <summary>
        /// 创建或更新档案及元数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public async Task<ArchiveDto> CreateOrUpdateArchiveAsync(ArchiveCreateOrUpdateDto input)
        {
            if (input.Id.HasValue)
            {
                var existingArchive = await _archiveRepository.GetAsync(input.Id.Value);
                var metadataArchiveId = existingArchive.Id;
                var metadatas = input.Metadatas?
                    .Select(m => new Metadata(
                        m.Key,
                        m.Value,
                        m.DataType,
                        metadataArchiveId,
                        m.NavigationProperty,
                        m.Order,
                        m.Title,
                        m.IsStatic))
                    .ToList() ?? [];

                foreach (var metadata in metadatas)
                {
                    metadata.ValidateDataType();
                }

                var archive = await _archiveDomainService.UpdateArchiveAsync(
                    existingArchive,
                    input.Title,
                    input.Year,
                    input.FilingDate,
                    input.Status,
                    input.BusinessKey,
                    input.Remarks,
                    input.ContentType,
                    input.MediaType,
                    input.SecretLevel,
                    input.RetentionPeriod,
                    metadatas);

                return ObjectMapper.Map<Archive, ArchiveDto>(archive);
            }
            else
            {
                var archiveId = GuidGenerator.Create();
                var metadatas = input.Metadatas?
                    .Select(m => new Metadata(
                        m.Key,
                        m.Value,
                        m.DataType,
                        archiveId,
                        m.NavigationProperty,
                        m.Order,
                        m.Title,
                        m.IsStatic))
                    .ToList() ?? [];

                foreach (var metadata in metadatas)
                {
                    metadata.ValidateDataType();
                }

                var archive = await _archiveDomainService.CreateArchiveAsync(
                    archiveId,
                    input.ArchiveNo,
                    input.Title,
                    input.Year,
                    input.FilingDate,
                    input.Status,
                    input.BusinessKey,
                    input.Remarks,
                    input.ContentType,
                    input.MediaType,
                    input.SecretLevel,
                    input.RetentionPeriod,
                    metadatas);

                return ObjectMapper.Map<Archive, ArchiveDto>(archive);
            }
        }

        /// <summary>
        /// 查询单个档案
        /// </summary>
        /// <param name="businessKey"></param>
        /// <returns></returns>
        public async Task<ArchiveDto?> GetArchiveByBusinessKeyAsync(string businessKey)
        {
            var archive = await _archiveRepository.FindByBusinessKeyAsync(businessKey);
            return ObjectMapper.Map<Archive?, ArchiveDto?>(archive);
        }

        /// <summary>
        /// 查询单个档案
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ArchiveDto?> GetArchiveAsync(Guid id)
        {
            var archive = await _archiveRepository.FindAsync(id);
            return ObjectMapper.Map<Archive?, ArchiveDto?>(archive);
        }

        /// <summary>
        /// 更新元数据值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="archiveId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<MetadataDto> UpdateByKeysAsync(string key, Guid archiveId, string value)
        {
            var entity = await _archiveDomainService.UpdateByKeysAsync(key, archiveId, value);
            return ObjectMapper.Map<Metadata, MetadataDto>(entity);
        }

        /// <summary>
        /// 分页查询档案
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [RemoteService(IsEnabled = false)]
        public async Task<PagedResultDto<ArchiveDto>> GetPagedAsync(PagedArchiveResultRequestDto input)
        {
            var totalCount = await _archiveRepository.GetCountAsync(
                input.ArchiveNo,
                input.BusinessKey,
                input.Year,
                input.StartFilingDate,
                input.EndFilingDate,
                input.Status,
                input.Metadata
                );
            var archives = await _archiveRepository.GetPagedListAsync(
                input.ArchiveNo,
                input.BusinessKey,
                input.Year,
                input.StartFilingDate,
                input.EndFilingDate,
                input.Status,
                input.Metadata,
                input.SkipCount,
                input.MaxResultCount);
            var archiveDtos = ObjectMapper.Map<List<Archive>, List<ArchiveDto>>(archives);
            return new PagedResultDto<ArchiveDto>(totalCount, archiveDtos);
        }

        /// <summary>
        /// 删除档案
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteArchiveAsync(Guid id)
        {
            await _archiveRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 创建档案文件
        /// </summary>
        /// <param name="input"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        [RemoteService(IsEnabled = false)]
        public async Task CreateFilesAsync(Guid catalogueId, List<ArchiveFileCreateDto> input, ArchiveFileCreateMode mode)
        {
            var archiveFile = _serviceProvider.GetService<IArchiveFileAppService>()
                ?? throw new UserFriendlyException("[IArchiveFileAppService]未注册服务！");
            await archiveFile.CreateFilesAsync(catalogueId, input, mode);
        }
        /// <summary>
        /// 创建档案目录
        /// </summary>
        /// <param name="input"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public async Task CreateCatalogueAsync(List<ArchiveCatalogueCreateDto> input, ArchiveCatalogueCreateMode mode)
        {
            var archiveFile = _serviceProvider.GetService<IArchiveFileAppService>()
                ?? throw new UserFriendlyException("[IArchiveFileAppService]未注册服务！");
            await archiveFile.CreateCatalogueAsync(input, mode);
        }
        /// <summary>
        /// 删除档案文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public async Task DeleteFileAsync(Guid id)
        {
            var archiveFile = _serviceProvider.GetService<IArchiveFileAppService>()
                ?? throw new UserFriendlyException("[IArchiveFileAppService]未注册服务！");
            await archiveFile.DeleteFileAsync(id);
        }
        /// <summary>
        /// 删除档案目录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public async Task DeleteCatalogueAsync(Guid id)
        {
            var archiveFile = _serviceProvider.GetService<IArchiveFileAppService>()
                ?? throw new UserFriendlyException("[IArchiveFileAppService]未注册服务！");
            await archiveFile.DeleteCatalogueAsync(id);
        }
        /// <summary>
        /// 通过业务编号获取档案目录及文件列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        [RemoteService(IsEnabled = false)]
        public async Task<List<ArchiveCatalogueDto>> GetListByReferenceAsync(List<GetArchiveCatalogueListInput> input)
        {
            var archiveFile = _serviceProvider.GetService<IArchiveFileAppService>()
                ?? throw new UserFriendlyException("[IArchiveFileAppService]未注册服务！");
            return await archiveFile.GetListByReferenceAsync(input);
        }
    }
}