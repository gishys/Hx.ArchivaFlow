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
        /// 备注信息
        /// </summary>
        public string? Remarks { get; private set; }

        /// <summary>
        /// 关联的元数据集合
        /// </summary>
        public virtual ICollection<Metadata> Metadatas { get; private set; } = new HashSet<Metadata>();

        // 赋值构造函数
        public Archive(Guid id, string archiveNo, string title, int year, DateTime? filingDate, ArchiveStatus status, string businessKey, string? remarks)
        {
            Id = id;
            ArchiveNo = archiveNo;
            Title = title;
            Year = year;
            FilingDate = filingDate;
            Status = status;
            BusinessKey = businessKey;
            Remarks = remarks;
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
                        metadata.NavigationProperty
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
