namespace RouterManager.Models
{
    public enum RouterStatus
    {
        /// <summary>
        /// 未连接/离线 
        /// </summary>
        Unlink = 0,

        /// <summary>
        /// 空闲
        /// </summary>
        Free = 1,

        /// <summary>
        /// 锁定-占用
        /// </summary>
        Locked = 2,

        /// <summary>
        /// 禁用
        /// </summary>
        Disabled = 3

    }
}