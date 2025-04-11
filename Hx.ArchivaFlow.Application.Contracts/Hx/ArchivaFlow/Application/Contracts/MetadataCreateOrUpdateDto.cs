using Hx.ArchivaFlow.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.ArchivaFlow.Application.Contracts
{
    public class MetadataCreateOrUpdateDto
    {
        public required string Key { get; set; }
        public required string Value { get; set; }
        public MetadataDataType DataType { get; set; }
        public Guid ArchiveId { get; set; }
        public string? NavigationProperty { get; set; }
    }
}
