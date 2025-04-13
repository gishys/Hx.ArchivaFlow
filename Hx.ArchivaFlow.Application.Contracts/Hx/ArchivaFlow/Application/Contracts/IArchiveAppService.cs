using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hx.ArchivaFlow.Application.Contracts
{
    public interface IArchiveAppService : IApplicationService
    {
        /// <summary>
        /// 创建或更新档案及元数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        Task<ArchiveDto> CreateOrUpdateArchiveAsync(ArchiveCreateOrUpdateDto input);
        /// <summary>
        /// 查询单个档案
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ArchiveDto?> GetArchiveAsync(Guid id);
        /// <summary>
        /// 分页查询档案
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ArchiveDto>> GetPagedAsync(PagedArchiveResultRequestDto input);
        /// <summary>
        /// 删除档案
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteArchiveAsync(Guid id);
        /// <summary>
        /// 创建档案文件
        /// </summary>
        /// <param name="input"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        Task CreateFilesAsync(List<ArchiveFileCreateDto> input, ArchiveFileCreateMode mode);
        /// <summary>
        /// 创建档案目录
        /// </summary>
        /// <param name="input"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        Task CreateCatalogueAsync(List<ArchiveCatalogueCreateDto> input, ArchiveCatalogueCreateMode mode);
        /// <summary>
        /// 删除档案文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        Task DeleteFileAsync(Guid id);
        /// <summary>
        /// 删除档案目录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        Task DeleteCatalogueAsync(Guid id);
        /// <summary>
        /// 通过业务编号获取档案目录及文件列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        Task GetListByReferenceAsync(GetArchiveCatalogueListInput input);
    }
}
