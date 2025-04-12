namespace Hx.ArchivaFlow.Application.Contracts
{
    public enum ArchiveCatalogueCreateMode
    {
        /// <summary>
        /// 目录存在则覆盖
        /// </summary>
        Create = 1,
        /// <summary>
        /// 目录存在则抛异常
        /// </summary>
        CreateNew = 2,
        /// <summary>
        /// 追加存在目录抛异常
        /// </summary>
        Append = 3,
        /// <summary>
        /// 删除所有重新创建
        /// </summary>
        Rebuild = 4,
        /// <summary>
        /// 跳过存在追加
        /// </summary>
        SkipExistAppend = 5,
    }
}
