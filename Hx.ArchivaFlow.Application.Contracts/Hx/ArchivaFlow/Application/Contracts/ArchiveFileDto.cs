namespace Hx.ArchivaFlow.Application.Contracts
{
    public class ArchiveFileDto
    {
        /// <summary>
        /// 文件别名
        /// </summary>
        public required string FileAlias { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int SequenceNumber { get; set; }
        public Guid Id { get; set; }
        public required string FilePath { get; set; }
        public required string FileName { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public required string FileType { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public int FileSize { get; set; }
        /// <summary>
        /// Attach catalogue id of this attach file.
        /// </summary>
        public Guid? CatalogueId { get; set; }
    }
}
