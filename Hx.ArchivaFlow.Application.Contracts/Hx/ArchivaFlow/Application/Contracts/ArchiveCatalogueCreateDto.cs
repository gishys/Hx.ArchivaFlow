namespace Hx.ArchivaFlow.Application.Contracts
{
    public class ArchiveCatalogueCreateDto
    {
        /// <summary>
        /// 目录名称
        /// </summary>
        public required string CatalogueName { get; set; }
        /// <summary>
        /// 业务类型标识
        /// </summary>
        public int ReferenceType { get; set; }
        /// <summary>
        /// 业务Id
        /// </summary>
        public required string Reference { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// 子文件夹
        /// </summary>
        public ICollection<ArchiveCatalogueCreateDto>? Children { get; set; }
        /// <summary>
        /// 子文件
        /// </summary>
        public List<ArchiveFileCreateDto>? ArchiveFiles { get; set; }
    }
}
