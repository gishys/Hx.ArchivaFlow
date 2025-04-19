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
            string contentType,
            MediaCatagory mediaType,
            SecretLevelCategory secretLevel,
            RetensionPeriodCategory retensionPeriod,
            List<Metadata> metadatas)
        {
            await ValidateArchiveNoUniquenessAsync(archiveNo);
            await ValidateArchiveBusinessKeyUniquenessAsync(businessKey);
            var archive = new Archive(id, archiveNo, title, year, filingDate, status, businessKey, remarks, contentType, mediaType, secretLevel, retensionPeriod);
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
            string contentType,
            MediaCatagory mediaType,
            SecretLevelCategory secretLevel,
            RetensionPeriodCategory retensionPeriod,
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
                await ValidateArchiveBusinessKeyUniquenessAsync(newBusinessKey);
                archiveToUpdate.SetBusinessKey(newBusinessKey);
            }
            if (!string.Equals(archiveToUpdate.Remarks, newRemarks))
            {
                archiveToUpdate.SetRemarks(newRemarks);
            }
            if (!string.Equals(archiveToUpdate.ContentType, contentType))
            {
                archiveToUpdate.SetContentType(contentType);
            }
            if (archiveToUpdate.MediaType != mediaType)
            {
                archiveToUpdate.SetMediaType(mediaType);
            }
            if (archiveToUpdate.SecretLevel != secretLevel)
            {
                archiveToUpdate.SetSecretLevel(secretLevel);
            }
            if (archiveToUpdate.RetentionPeriod != retensionPeriod)
            {
                archiveToUpdate.SetRetentionPeriod(retensionPeriod);
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
        /// 更新元数据值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="archiveId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<Metadata> UpdateByKeysAsync(string key, Guid archiveId, string value)
        {
            return await _metadataRepository.UpdateByKeysAsync(key, archiveId, value);
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
                throw new BusinessException("档案编号已经存在！")
                    .WithData("ArchiveNo", archiveNo);
            }
        }
        private async Task ValidateArchiveBusinessKeyUniquenessAsync(string businessKey)
        {
            var existing = await _archiveRepository.FindByBusinessKeyAsync(businessKey);
            if (existing != null)
            {
                throw new BusinessException("业务编号已经存在！")
                    .WithData("BusinessKey", businessKey);
            }
        }
    }
}