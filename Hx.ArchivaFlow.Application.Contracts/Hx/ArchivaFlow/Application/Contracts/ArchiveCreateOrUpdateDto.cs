using Hx.ArchivaFlow.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.ArchivaFlow.Application.Contracts
{
    public class ArchiveCreateOrUpdateDto
    {
        public Guid? Id { get; set; }
        public required string ArchiveNo { get; set; }
        public required string Title { get; set; }
        public int Year { get; set; }
        public DateTime FilingDate { get; set; }
        public ArchiveStatus Status { get; set; }
        public required string BusinessKey { get; set; }
        public required string Remarks { get; set; }
        public List<MetadataCreateOrUpdateDto>? Metadatas { get; set; }
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

        /// <summary>
        /// 全宗号
        /// </summary>
        public required string FundsCode { get; set; }

        /// <summary>
        /// 保管单位
        /// </summary>
        public string? CustodianUnit { get; set; }

        /// <summary>
        /// 存放位置
        /// </summary>
        public string? StorageLocation { get; set; }

        /// <summary>
        /// 档案馆代号
        /// </summary>
        public string? ArchivalCode { get; set; }

        /// <summary>
        /// 档案门类代码
        /// </summary>
        public string? ArchivalCategory { get; set; }
    }
}
