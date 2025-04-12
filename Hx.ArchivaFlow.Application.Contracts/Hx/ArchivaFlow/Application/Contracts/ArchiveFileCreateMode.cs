namespace Hx.ArchivaFlow.Application.Contracts
{
    public enum ArchiveFileCreateMode
    {
        /// <summary>
        /// 文件存在则覆盖
        /// </summary>
        Create = 0,
        /// <summary>
        /// 文件存在抛异常
        /// </summary>
        CreateNew = 1,
    }
}
