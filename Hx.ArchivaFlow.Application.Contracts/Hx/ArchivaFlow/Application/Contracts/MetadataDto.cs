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
    }
}
