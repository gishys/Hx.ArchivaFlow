using Hx.ArchivaFlow.Domain.Shared;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.ArchivaFlow.Domain
{
    /// <summary>
    /// 档案聚合根实体
    /// </summary>
    public class Archive : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 档案编号（唯一业务标识）
        /// </summary>
        public string ArchiveNo { get; private set; }

        /// <summary>
        /// 档案题名
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 所属年度
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// 归档日期
        /// </summary>
        public DateTime? FilingDate { get; private set; }

        /// <summary>
        /// 档案状态（使用枚举定义状态机）
        /// </summary>
        public ArchiveStatus Status { get; private set; }

        /// <summary>
        /// 业务关联标识（用于关联外部业务系统）
        /// </summary>
        public string BusinessKey { get; private set; }

        /// <summary>
        /// 内容分类
        /// </summary>
        public string ContentType { get; private set; }

        /// <summary>
        /// 载体形式
        /// </summary>
        public MediaCatagory MediaType { get; private set; }

        /// <summary>
        /// 保密等级
        /// </summary>

        public SecretLevelCategory SecretLevel { get; private set; }

        /// <summary>
        /// 保管期限
        /// </summary>
        public RetensionPeriodCategory RetentionPeriod { get; private set; }

        /// <summary>
        /// 全宗号
        /// </summary>
        public string FundsCode { get; private set; }

        /// <summary>
        /// 保管单位
        /// </summary>
        public string? CustodianUnit { get; private set; }

        /// <summary>
        /// 存放位置
        /// </summary>
        public string? StorageLocation { get; private set; }

        /// <summary>
        /// 档案馆代号
        /// </summary>
        public string? ArchivalCode { get; private set; }

        /// <summary>
        /// 档案门类代码
        /// </summary>
        public string? ArchivalCategory { get; private set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string? Remarks { get; private set; }

        /// <summary>
        /// 关联的元数据集合
        /// </summary>
        public virtual ICollection<Metadata> Metadatas { get; private set; } = new HashSet<Metadata>();

        // 赋值构造函数
        public Archive(
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
            RetensionPeriodCategory retentionPeriod,
            string fundsCode,
            string? custodianUnit,
            string? storageLocation,
            string? archivalCode = null,
            string? archivalCategory = null)
        {
            Id = id;
            ArchiveNo = archiveNo;
            Title = title;
            Year = year;
            FilingDate = filingDate;
            Status = status;
            BusinessKey = businessKey;
            Remarks = remarks;
            ContentType = contentType;
            MediaType = mediaType;
            SecretLevel = secretLevel;
            RetentionPeriod = retentionPeriod;
            FundsCode = fundsCode;
            CustodianUnit = custodianUnit;
            StorageLocation = storageLocation;
            ArchivalCode = archivalCode;
            ArchivalCategory = archivalCategory;
        }
        public void SetArchiveNo(string archiveNo)
        {
            ArchiveNo = archiveNo;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetYear(int year)
        {
            Year = year;
        }

        public void SetFilingDate(DateTime? filingDate)
        {
            FilingDate = filingDate;
        }

        public void SetStatus(ArchiveStatus status)
        {
            Status = status;
        }

        public void SetBusinessKey(string businessKey)
        {
            BusinessKey = businessKey;
        }

        public void SetRemarks(string? remarks)
        {
            Remarks = remarks;
        }

        public void SetContentType(string contentType)
        {
            ContentType = contentType;
        }

        public void SetMediaType(MediaCatagory mediaType)
        {
            MediaType = mediaType;
        }

        public void SetSecretLevel(SecretLevelCategory secretLevel)
        {
            SecretLevel = secretLevel;
        }

        public void SetRetentionPeriod(RetensionPeriodCategory retentionPeriod)
        {
            RetentionPeriod = retentionPeriod;
        }

        public void SetFundsCode(string fundsCode)
        {
            FundsCode = fundsCode;
        }

        public void SetCustodianUnit(string? custodianUnit)
        {
            CustodianUnit = custodianUnit;
        }

        public void SetStorageLocation(string? storageLocation)
        {
            StorageLocation = storageLocation;
        }

        public void SetArchivalCode(string? archivalCode)
        {
            ArchivalCode = archivalCode;
        }

        public void SetArchivalCategory(string? archivalCategory)
        {
            ArchivalCategory = archivalCategory;
        }

        public void UpdateMetadata(List<Metadata> metadatas)
        {
            foreach (var metadata in metadatas)
            {
                metadata.SetArchiveId(Id);
            }
            var existingMetadatas = Metadatas.ToDictionary(m => m.Key);
            foreach (var metadata in metadatas)
            {
                if (existingMetadatas.TryGetValue(metadata.Key, out var existing))
                {
                    existing.Update(
                        metadata.Value,
                        metadata.DataType,
                        metadata.NavigationProperty,
                        metadata.Order,
                        metadata.Title
                    );
                    existingMetadatas.Remove(metadata.Key);
                }
                else
                {
                    Metadatas.Add(metadata);
                }
            }
            foreach (var toRemove in existingMetadatas.Values)
            {
                Metadatas.Remove(toRemove);
            }
        }
    }
}