using Hx.ArchivaFlow.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.ArchivaFlow.Domain
{
    /// <summary>
    /// 元数据值对象
    /// </summary>
    [Table("Metadata")]
    public class Metadata : AuditedEntity<Guid>
    {
        /// <summary>
        /// 元数据键（唯一标识）
        /// </summary>
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Key { get; private set; }

        /// <summary>
        /// 元数据值
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public string Value { get; private set; }

        /// <summary>
        /// 数据类型（用于解析值类型）
        /// </summary>
        public MetadataDataType DataType { get; private set; }

        /// <summary>
        /// 关联的档案ID
        /// </summary>
        public Guid ArchiveId { get; private set; }

        /// <summary>
        /// 导航属性：所属档案
        /// </summary>
        public virtual Archive Archive { get; private set; }

        /// <summary>
        /// 元数据导航属性（扩展预留）
        /// </summary>
        public string NavigationProperty { get; private set; }

        // 赋值构造函数
        public Metadata(Guid id, string key, string value, MetadataDataType dataType, Guid archiveId, Archive archive, string navigationProperty)
        {
            Id = id;
            Key = key;
            Value = value;
            DataType = dataType;
            ArchiveId = archiveId;
            Archive = archive;
            NavigationProperty = navigationProperty;
        }
    }
}
