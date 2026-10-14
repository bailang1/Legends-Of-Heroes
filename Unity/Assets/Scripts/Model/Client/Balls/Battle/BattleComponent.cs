using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// 客户端战斗组件，保存服务端同步过来的战斗过程数据
    /// </summary>
    [ComponentOf()]
    public class BattleComponent: Entity, IAwake, IFixedUpdate
    {
        /// <summary>
        /// 当前回合编号
        /// </summary>
        public int RoundIndex;

        /// <summary>
        /// 本回合攻击序列（按出手顺序排列的单位Id）
        /// </summary>
        public List<long> AttackSequence = new List<long>();

        /// <summary>
        /// 当前出手单位Id
        /// </summary>
        public long CurrentUnitId;

        /// <summary>
        /// 战斗是否结束
        /// </summary>
        public bool IsBattleEnd;
    }
}
