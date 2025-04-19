namespace Hx.ArchivaFlow.Domain.Shared
{
    public enum SecretLevelCategory : byte
    {
        /// <summary>
        /// 公开
        /// </summary>
        Public = 0,
        /// <summary>
        /// 内部
        /// </summary>
        Internal = 1,
        /// <summary>
        /// 秘密
        /// </summary>
        Confidential = 2,
        /// <summary>
        /// 机密
        /// </summary>
        Secret = 3,
        /// <summary>
        /// 绝密
        /// </summary>
        TopSecret = 4
    }
}
