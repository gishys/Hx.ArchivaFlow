namespace Hx.ArchivaFlow.Application.Contracts
{
    public class ArchiveFileCreateDto
    {
        public ArchiveFileCreateDto(string aliasName, byte[] documentContent, double order)
        {
            AliasName = aliasName;
            DocumentContent = documentContent;
            Order = order;
        }
        public ArchiveFileCreateDto(
            string aliasName,
            string filePath,
            double? order,
            string? fileType,
            double? fileSize,
            Guid catalogueId)
        {
            AliasName = aliasName;
            FilePath = filePath;
            Order = order;
            FileType = fileType;
            FileSize = fileSize;
            CatalogueId = catalogueId;
        }
        public required string AliasName { get; set; }
        public byte[]? DocumentContent { get; set; }
        public string? FilePath { get; set; }
        public double? Order { get; set; }
        public string? FileType { get; set; }
        public double? FileSize { get; set; }
        public Guid CatalogueId { get; set; }
    }
}