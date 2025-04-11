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
        public List<MetadataDto>? Metadatas { get; set; }
    }
}
