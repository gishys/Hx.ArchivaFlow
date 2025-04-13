using Hx.ArchivaFlow.Domain.Shared;

namespace Hx.ArchivaFlow.Application.Contracts
{
    public class ArchiveFileCreateDto
    {
        public ArchiveFileCreateDto(Guid catalogueId, string aliasName, byte[] documentContent, double order)
        {
            AliasName = aliasName;
            DocumentContent = documentContent;
            Order = order;
            CatalogueId = catalogueId;
            ArchiveFileType = ArchiveFileType.FileBytes;
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
            ArchiveFileType = ArchiveFileType.Path;
        }
        public string AliasName { get; set; }
        public byte[]? DocumentContent { get; set; }
        public string? FilePath { get; set; }
        public double? Order { get; set; }
        public string? FileType { get; set; }
        public double? FileSize { get; set; }
        public Guid CatalogueId { get; set; }
        public ArchiveFileType ArchiveFileType { get; set; }
    }
}