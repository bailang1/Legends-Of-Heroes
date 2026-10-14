namespace ET.Server
{
    /// <summary>
    /// 单位在一场回合制战斗中的战斗数据（阵营、站位等）
    /// 附加在 Unit 上，仅在本场战斗生命周期内有效，不参与序列化传输
    /// </summary>
    [ComponentOf(typeof(Unit))]
    public class BattleUnitComponent : Entity, IAwake<EBattleCamp>
    {
        /// <summary>
        /// 所属阵营（我方/敌方）
        /// </summary>
        public EBattleCamp Camp;

        /// <summary>
        /// 站位序号（占位，后续用于前后排等选敌规则）
        /// </summary>
        public int SeatNumber;
    }
}
