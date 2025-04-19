using Hx.ArchivaFlow.Domain.Shared;

namespace Hx.ArchivaFlow.Application.Contracts
{
    public class MetadataDto
    {
        public required string Key { get; set; }
        public required string Value { get; set; }
        public MetadataDataType DataType { get; set; }
        public Guid ArchiveId { get; set; }
        public string? NavigationProperty { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        public double Order { get; set; }

        /// <summary>
        /// 元数据标题
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// 是否静态
        /// </summary>
        public bool IsStatic { get; set; }
    }
}
