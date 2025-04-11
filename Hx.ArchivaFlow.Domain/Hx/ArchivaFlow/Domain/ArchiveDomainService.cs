using Hx.ArchivaFlow.Domain.Shared;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Hx.ArchivaFlow.Domain
{
    public class ArchiveDomainService(
        IEfCoreAchiveRepository archiveRepository,
        IEfCoreMetadataRepository metadataRepository) : DomainService
    {
        private readonly IEfCoreAchiveRepository _archiveRepository = archiveRepository;
        private readonly IEfCoreMetadataRepository _metadataRepository = metadataRepository;

        /// <summary>
        /// 创建档案
        /// </summary>
        public async Task<Archive> CreateArchiveAsync(
            Guid id,
            string archiveNo,
            string title,
            int year,
            DateTime? filingDate,
            ArchiveStatus status,
            string businessKey,
            string? remarks,
            List<Metadata> metadatas)
        {
            await ValidateArchiveNoUniquenessAsync(archiveNo);
            var archive = new Archive(id, archiveNo, title, year, filingDate, status, businessKey, remarks);
            foreach (var metadata in metadatas)
            {
                await _metadataRepository.InsertAsync(metadata);
            }
            return await _archiveRepository.InsertAsync(archive);
        }

        /// <summary>
        /// 更新档案信息
        /// </summary>
        public async Task<Archive> UpdateArchiveAsync(
            Archive archiveToUpdate,
            string newTitle,
            int newYear,
            DateTime? newFilingDate,
            ArchiveStatus newStatus,
            string newBusinessKey,
            string? newRemarks,
            List<Metadata> metadatas)
        {
            if (!string.Equals(archiveToUpdate.Title, newTitle))
            {
                archiveToUpdate.SetTitle(newTitle);
            }
            if (archiveToUpdate.Year != newYear)
            {
                archiveToUpdate.SetYear(newYear);
            }
            if (archiveToUpdate.FilingDate != newFilingDate)
            {
                archiveToUpdate.SetFilingDate(newFilingDate);
            }
            if (archiveToUpdate.Status != newStatus)
            {
                archiveToUpdate.SetStatus(newStatus);
            }
            if (!string.Equals(archiveToUpdate.BusinessKey, newBusinessKey))
            {
                archiveToUpdate.SetBusinessKey(newBusinessKey);
            }
            if (!string.Equals(archiveToUpdate.Remarks, newRemarks))
            {
                archiveToUpdate.SetRemarks(newRemarks);
            }
            archiveToUpdate.UpdateMetadata(metadatas);

            return await _archiveRepository.UpdateAsync(archiveToUpdate);
        }

        /// <summary>
        /// 删除档案
        /// </summary>
        public async Task DeleteArchiveAsync(Guid archiveId)
        {
            await _archiveRepository.DeleteAsync(archiveId);
        }

        /// <summary>
        /// 获取单个档案
        /// </summary>
        public async Task<Archive?> GetArchiveAsync(Guid archiveId)
        {
            return await _archiveRepository.FindAsync(archiveId);
        }
        private async Task ValidateArchiveNoUniquenessAsync(string archiveNo)
        {
            var existing = await _archiveRepository.FindByArchiveNoAsync(archiveNo);
            if (existing != null)
            {
                throw new BusinessException("菜单名称已经存在！")
                    .WithData("ArchiveNo", archiveNo);
            }
        }
    }
}