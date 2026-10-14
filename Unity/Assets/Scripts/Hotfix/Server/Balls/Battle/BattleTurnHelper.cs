using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 回合制战斗业务逻辑：攻击序列构建、单位查询、阵营判定等
    /// 按 ET 规范，复杂业务逻辑集中在此 Helper，System 只负责数据管理
    /// </summary>
    public static class BattleTurnHelper
    {
        /// <summary>
        /// 取出战斗中所有存活的单位
        /// </summary>
        public static List<Unit> GetAliveUnits(BattleComponent self)
        {
            List<Unit> units = new List<Unit>();
            UnitComponent unitComponent = self.GetComponent<UnitComponent>();
            if (unitComponent == null)
            {
                return units;
            }

            foreach (Entity child in unitComponent.Children.Values)
            {
                if (child is not Unit unit || unit.IsDisposed)
                {
                    continue;
                }

                if (IsAlive(unit))
                {
                    units.Add(unit);
                }
            }

            return units;
        }

        /// <summary>
        /// 单位是否存活（生命值大于0）
        /// </summary>
        public static bool IsAlive(Unit unit)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            return numericComponent != null && numericComponent.GetAsInt(NumericType.Hp) > 0;
        }

        /// <summary>
        /// 单位出手速度
        /// </summary>
        public static int GetSpeed(Unit unit)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            return numericComponent == null ? 0 : numericComponent.GetAsInt(NumericType.Speed);
        }

        /// <summary>
        /// 按出手速度从高到低构建攻击序列，速度相同时按单位Id升序，保证顺序稳定可复现
        /// </summary>
        public static List<long> BuildAttackSequence(BattleComponent self)
        {
            List<Unit> units = GetAliveUnits(self);
            units.Sort(CompareUnitBySpeed);

            List<long> sequence = new List<long>(units.Count);
            foreach (Unit unit in units)
            {
                sequence.Add(unit.Id);
            }
            return sequence;
        }

        private static int CompareUnitBySpeed(Unit a, Unit b)
        {
            int speedA = GetSpeed(a);
            int speedB = GetSpeed(b);
            if (speedA != speedB)
            {
                return speedB.CompareTo(speedA);
            }
            return a.Id.CompareTo(b.Id);
        }

        /// <summary>
        /// 查找指定阵营中第一个存活单位
        /// </summary>
        public static Unit FindFirstAliveUnit(BattleComponent self, EBattleCamp camp)
        {
            foreach (Unit unit in GetAliveUnits(self))
            {
                if (unit.BattleCamp() == camp)
                {
                    return unit;
                }
            }
            return null;
        }

        /// <summary>
        /// 判断指定阵营是否全部阵亡
        /// </summary>
        public static bool IsCampAllDead(BattleComponent self, EBattleCamp camp)
        {
            return FindFirstAliveUnit(self, camp) == null;
        }
    }
}
