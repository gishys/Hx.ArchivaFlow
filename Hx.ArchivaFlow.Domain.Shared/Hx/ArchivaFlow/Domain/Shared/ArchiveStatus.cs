namespace Hx.ArchivaFlow.Domain.Shared
{
    /// <summary>
    /// 档案状态枚举
    /// </summary>
    public enum ArchiveStatus : byte
    {
        Draft = 0,     // 草稿
        Active = 1,    // 已归档
        Archived = 2   // 已封存
    }
}
