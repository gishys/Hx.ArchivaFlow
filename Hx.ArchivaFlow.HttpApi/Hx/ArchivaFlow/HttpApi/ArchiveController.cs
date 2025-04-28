using Hx.ArchivaFlow.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Hx.ArchivaFlow.HttpApi
{
    [ApiController]
    [Route("api/app/archive")]
    public class ArchiveController(
        IArchiveAppService archiveAppService) : AbpControllerBase
    {
        private readonly IArchiveAppService _archiveAppService = archiveAppService;

        [HttpPost]
        [Route("files")]
        public async Task CreateFilesAsync(Guid catalogueId, double order, ArchiveFileCreateMode mode)
        {
            var files = Request.Form.Files;
            if (files.Count > 0)
            {
                var inputs = new List<ArchiveFileCreateDto>();
                foreach (var file in files)
                {
                    byte[] fileBytes;
                    using (var fileStream = file.OpenReadStream())
                    using (var ms = new MemoryStream())
                    {
                        fileStream.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                    var attachFile = new ArchiveFileCreateDto(catalogueId, file.Name, fileBytes, order);
                    inputs.Add(attachFile);
                }
                await _archiveAppService.CreateFilesAsync(catalogueId, inputs, mode);
            }
            throw new UserFriendlyException(message: "上传文件为空！");
        }
        [HttpPost]
        [Route("paged")]
        public Task<PagedResultDto<ArchiveDto>> GetPagedAsync(PagedArchiveResultRequestDto input)
        {
            return _archiveAppService.GetPagedAsync(input);
        }
        [HttpPost]
        [Route("archive-file-list-by-reference")]
        public Task<List<ArchiveCatalogueDto>> GetListByReferenceAsync(List<GetArchiveCatalogueListInput> input)
        {
            return _archiveAppService.GetListByReferenceAsync(input);
        }
    }
}
