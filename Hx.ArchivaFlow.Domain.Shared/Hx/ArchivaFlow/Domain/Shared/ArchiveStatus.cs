namespace Hx.ArchivaFlow.Domain.Shared
{
    /// <summary>
    /// 档案状态枚举
    /// </summary>
    public enum ArchiveStatus : byte
    {
        Draft = 0,        // 草稿
        PendingReview = 1,// 待审核
        Rejected = 2,     // 已驳回
        Active = 3,       // 已生效（归档完成）
        Archived = 4,     // 已封存（长期保存）
        CheckedOut = 5,   // 已借出
        Locked = 6,       // 已锁定
        Expired = 7,      // 已过期
        Suspended = 8,    // 已暂停
        Destroyed = 9,    // 已销毁
        Superseded = 10   // 已替代
    }
}
