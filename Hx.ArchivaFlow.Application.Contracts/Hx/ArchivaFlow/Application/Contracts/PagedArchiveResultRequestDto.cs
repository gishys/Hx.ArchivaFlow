using Hx.ArchivaFlow.Domain.Shared;
using Volo.Abp.Application.Dtos;

namespace Hx.ArchivaFlow.Application.Contracts
{
    public class PagedArchiveResultRequestDto : PagedResultRequestDto
    {
        public string? ArchiveNo { get; set; }
        public string? BusinessKey { get; set; }
        public int? Year { get; set; }
        public DateTime? StartFilingDate { get; set; }
        public DateTime? EndFilingDate { get; set; }
        public ArchiveStatus? Status { get; set; }
        public Dictionary<string, string>? Metadata { get; set; }
    }
}
