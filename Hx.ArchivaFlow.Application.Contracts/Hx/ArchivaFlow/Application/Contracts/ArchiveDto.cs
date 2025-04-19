using Hx.ArchivaFlow.Domain.Shared;

namespace Hx.ArchivaFlow.Application.Contracts
{
    public class ArchiveDto
    {
        public Guid Id { get; set; }
        public required string ArchiveNo { get; set; }
        public required string Title { get; set; }
        public int Year { get; set; }
        public DateTime FilingDate { get; set; }
        public ArchiveStatus Status { get; set; }
        public required string BusinessKey { get; set; }
        public required string Remarks { get; set; }
        public List<MetadataDto>? Metadatas { get; set; }
        /// <summary>
        /// 内容分类
        /// </summary>
        public required string ContentType { get; set; }

        /// <summary>
        /// 载体形式
        /// </summary>
        public MediaCatagory MediaType { get; set; }

        /// <summary>
        /// 保密等级
        /// </summary>

        public SecretLevelCategory SecretLevel { get; set; }

        /// <summary>
        /// 保管期限
        /// </summary>
        public RetensionPeriodCategory RetentionPeriod { get; set; }
    }
}
