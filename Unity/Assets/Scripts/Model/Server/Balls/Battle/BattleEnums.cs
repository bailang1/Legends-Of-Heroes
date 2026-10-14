namespace ET.Server
{
    /// <summary>
    /// 回合制战斗状态
    /// </summary>
    public enum EBattleState : byte
    {
        /// <summary>
        /// 未开始
        /// </summary>
        None = 0,
        /// <summary>
        /// 进行中
        /// </summary>
        Running = 1,
        /// <summary>
        /// 已结束
        /// </summary>
        End = 2,
    }

    /// <summary>
    /// 战斗阵营
    /// </summary>
    public enum EBattleCamp : byte
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0,
        /// <summary>
        /// 我方（玩家）
        /// </summary>
        Hero = 1,
        /// <summary>
        /// 敌方（怪物）
        /// </summary>
        Enemy = 2,
    }
}
