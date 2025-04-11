using Hx.ArchivaFlow.Application.Contracts;
using Hx.ArchivaFlow.Domain;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hx.ArchiveFlow.Application
{
    public class ArchiveAppService(ArchiveDomainService archiveDomainService,
        IEfCoreAchiveRepository archiveRepository,
        IEfCoreMetadataRepository metadataRepository) : ApplicationService
    {
        private readonly ArchiveDomainService _archiveDomainService = archiveDomainService;
        private readonly IEfCoreAchiveRepository _archiveRepository = archiveRepository;
        private readonly IEfCoreMetadataRepository _metadataRepository = metadataRepository;

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
                        m.NavigationProperty))
                    .ToList() ?? [];

                var archive = await _archiveDomainService.UpdateArchiveAsync(
                    existingArchive,
                    input.Title,
                    input.Year,
                    input.FilingDate,
                    input.Status,
                    input.BusinessKey,
                    input.Remarks,
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
                        m.NavigationProperty))
                    .ToList() ?? [];

                var archive = await _archiveDomainService.CreateArchiveAsync(
                    archiveId,
                    input.ArchiveNo,
                    input.Title,
                    input.Year,
                    input.FilingDate,
                    input.Status,
                    input.BusinessKey,
                    input.Remarks,
                    metadatas);

                return ObjectMapper.Map<Archive, ArchiveDto>(archive);
            }
        }

        /// <summary>
        /// 查询单个档案
        /// </summary>
        public async Task<ArchiveDto?> GetArchiveAsync(Guid id)
        {
            var archive = await _archiveRepository.FindAsync(id);
            return ObjectMapper.Map<Archive?, ArchiveDto?>(archive);
        }

        /// <summary>
        /// 分页查询档案
        /// </summary>
        public async Task<PagedResultDto<ArchiveDto>> GetPagedArchivesAsync(PagedArchiveResultRequestDto input)
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
        public async Task DeleteArchiveAsync(Guid id)
        {
            await _archiveRepository.DeleteAsync(id);
        }
    }
}