using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 战斗组件（挂在房间实体 StateSyncRoom 上），承载一场回合制战斗
    /// 只保存战斗过程数据，逻辑见 BattleComponentSystem / BattleTurnHelper
    /// </summary>
    [ComponentOf(typeof(StateSyncRoom))]
    public class BattleComponent: Entity, IAwake, IFixedUpdate
    {
        /// <summary>
        /// 战斗状态
        /// </summary>
        public EBattleState State;

        /// <summary>
        /// 当前回合编号，从1开始
        /// </summary>
        public int RoundIndex;

        /// <summary>
        /// 攻击序列：本回合按出手顺序排列的单位Id
        /// </summary>
        public List<long> AttackSequence;

        /// <summary>
        /// 当前出手序号，指向 AttackSequence 的下标
        /// </summary>
        public int TurnIndex;

        /// <summary>
        /// 本回合已累计时间（秒），用于控制出手间隔
        /// </summary>
        public float TurnElapsedTime;
    }

}
