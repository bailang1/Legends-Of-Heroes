namespace ET.Server
{
    /// <summary>
    /// 战斗单位组件系统，管理单位在战斗中的阵营等数据
    /// </summary>
    [EntitySystemOf(typeof(BattleUnitComponent))]
    [FriendOf(typeof(BattleUnitComponent))]
    public static partial class BattleUnitComponentSystem
    {
        [EntitySystem]
        private static void Awake(this BattleUnitComponent self, EBattleCamp camp)
        {
            self.Camp = camp;
            self.SeatNumber = 0;
        }

        /// <summary>
        /// 获取单位的战斗阵营（未参与战斗时返回 None）
        /// </summary>
        public static EBattleCamp BattleCamp(this Unit self)
        {
            BattleUnitComponent component = self.GetComponent<BattleUnitComponent>();
            return component == null ? EBattleCamp.None : component.Camp;
        }
    }
}
