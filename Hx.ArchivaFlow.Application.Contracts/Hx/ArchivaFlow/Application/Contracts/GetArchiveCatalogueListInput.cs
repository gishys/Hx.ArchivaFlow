namespace Hx.ArchivaFlow.Application.Contracts
{
    public class GetArchiveCatalogueListInput
    {
        public required string Reference { get; set; }
        public int ReferenceType { get; set; }
        public string? CatalogueName { get; set; }
    }
}
