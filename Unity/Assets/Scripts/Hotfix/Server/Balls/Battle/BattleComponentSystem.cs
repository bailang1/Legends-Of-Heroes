using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 回合制战斗组件系统（挂载在房间实体上）
    /// 负责战斗生命周期、攻击序列推进与出手调度
    /// </summary>
    [EntitySystemOf(typeof(BattleComponent))]
    [FriendOf(typeof(BattleComponent))]
    public static partial class BattleComponentSystem
    {
        /// <summary>
        /// 每次出手之间的间隔时间（秒），占位值
        /// </summary>
        private const float TurnInterval = 1f;

        /// <summary>
        /// 初始化我方单位
        /// </summary>
        public static void InitFriend(this BattleComponent self, List<long> unitInfos)
        {
            for (int i = 0; i < unitInfos.Count; ++i)
            {
                UnitFactory.Create(self, unitInfos[i], EUnitType.RoomPlayer);
            }
        }

        /// <summary>
        /// 初始化敌方单位
        /// </summary>
        public static void InitEnemy(this BattleComponent self, int Id)
        {
            for (int i = 0; i < 5; ++i)
            {
                UnitFactory.Create(self, i, EUnitType.Monster);
            }
        }

        [EntitySystem]
        private static void Awake(this BattleComponent self)
        {
            self.AddComponent<UnitComponent>();
            self.State = EBattleState.None;
            self.RoundIndex = 0;
            self.TurnIndex = 0;
            self.TurnElapsedTime = 0f;
            self.AttackSequence = new List<long>();
        }

        /// <summary>
        /// 开始战斗：进入进行中状态并构建首个回合的攻击序列
        /// </summary>
        public static void StartBattle(this BattleComponent self)
        {
            if (self.State == EBattleState.Running)
            {
                return;
            }

            self.State = EBattleState.Running;
            self.RoundIndex = 1;
            self.TurnIndex = 0;
            self.TurnElapsedTime = 0f;
            self.RefreshAttackSequence();

            Log.Info($"开始战斗 回合:{self.RoundIndex} 攻击序列:[{string.Join(",", self.AttackSequence)}]");
            self.NotifyRoundStart();
        }

        /// <summary>
        /// 构建当前回合的攻击序列（按出手速度排序）
        /// </summary>
        public static void RefreshAttackSequence(this BattleComponent self)
        {
            self.AttackSequence = BattleTurnHelper.BuildAttackSequence(self);
        }

        [EntitySystem]
        private static void FixedUpdate(this BattleComponent self)
        {
            if (self.State != EBattleState.Running)
            {
                return;
            }

            // 回合制战斗不需要每帧推进，用累计时间控制出手间隔
            self.TurnElapsedTime += DefineCore.FixedDeltaTime;
            if (self.TurnElapsedTime < TurnInterval)
            {
                return;
            }

            self.TurnElapsedTime = 0f;
            self.NextTurn();
        }

        /// <summary>
        /// 推进到下一次出手，序列耗尽则开启新回合并重新构建攻击序列
        /// </summary>
        public static void NextTurn(this BattleComponent self)
        {
            if (self.CheckBattleEnd())
            {
                return;
            }

            while (true)
            {
                if (self.TurnIndex >= self.AttackSequence.Count)
                {
                    // 本回合结束：开启新回合并重新构建攻击序列
                    self.RoundIndex++;
                    self.TurnIndex = 0;
                    self.RefreshAttackSequence();
                    Log.Info($"进入回合:{self.RoundIndex} 攻击序列:[{string.Join(",", self.AttackSequence)}]");
                    self.NotifyRoundStart();

                    if (self.AttackSequence.Count == 0)
                    {
                        self.CheckBattleEnd();
                        return;
                    }
                    continue;
                }

                long unitId = self.AttackSequence[self.TurnIndex];
                self.TurnIndex++;

                Unit unit = self.GetComponent<UnitComponent>().Get(unitId);
                if (unit == null || !BattleTurnHelper.IsAlive(unit))
                {
                    // 单位已阵亡，跳过本次出手
                    continue;
                }

                self.ExecuteTurn(unit);
                return;
            }
        }

        /// <summary>
        /// 执行一次出手
        /// 占位：当前为简单普攻，后续替换为技能选择、目标选择与效果结算系统
        /// </summary>
        public static void ExecuteTurn(this BattleComponent self, Unit unit)
        {
            EBattleCamp enemyCamp = unit.BattleCamp() == EBattleCamp.Hero ? EBattleCamp.Enemy : EBattleCamp.Hero;
            Unit target = BattleTurnHelper.FindFirstAliveUnit(self, enemyCamp);
            if (target == null)
            {
                return;
            }

            self.DealDamage(unit, target);

            Log.Debug($"[占位] 回合:{self.RoundIndex} 出手:{unit.Id} 目标:{target.Id}");

            // 同步出手消息给客户端
            Room2C_BattleTurn turn = Room2C_BattleTurn.Create();
            turn.RoundIndex = self.RoundIndex;
            turn.UnitId = unit.Id;
            BattleMessageHelper.Broadcast(self, turn);
        }

        /// <summary>
        /// 占位：简单伤害结算，后续接入属性/技能/效果系统
        /// </summary>
        public static void DealDamage(this BattleComponent self, Unit attacker, Unit target)
        {
            NumericComponent attackerNumeric = attacker.GetComponent<NumericComponent>();
            NumericComponent targetNumeric = target.GetComponent<NumericComponent>();

            int damage = attackerNumeric == null ? 0 : attackerNumeric.GetAsInt(NumericType.Attack);
            int hp = targetNumeric.GetAsInt(NumericType.Hp);
            int finalHp = hp - damage;
            if (finalHp < 0)
            {
                finalHp = 0;
            }
            targetNumeric.Set(NumericType.Hp, finalHp);
        }

        /// <summary>
        /// 判断战斗是否结束，结束则切换状态并做收尾处理
        /// </summary>
        public static bool CheckBattleEnd(this BattleComponent self)
        {
            bool heroAllDead = BattleTurnHelper.IsCampAllDead(self, EBattleCamp.Hero);
            bool enemyAllDead = BattleTurnHelper.IsCampAllDead(self, EBattleCamp.Enemy);
            if (!heroAllDead && !enemyAllDead)
            {
                return false;
            }

            self.State = EBattleState.End;
            Log.Info($"战斗结束 回合:{self.RoundIndex} 我方全灭:{heroAllDead} 敌方全灭:{enemyAllDead}");
            self.NotifyBattleEnd();
            return true;
        }

        /// <summary>
        /// 通知客户端回合开始，同步本回合出手顺序
        /// </summary>
        private static void NotifyRoundStart(this BattleComponent self)
        {
            Room2C_BattleRoundStart message = Room2C_BattleRoundStart.Create();
            message.RoundIndex = self.RoundIndex;
            message.AttackSequence.AddRange(self.AttackSequence);
            BattleMessageHelper.Broadcast(self, message);
        }

        /// <summary>
        /// 通知客户端战斗结束，同步胜负结果
        /// </summary>
        private static void NotifyBattleEnd(this BattleComponent self)
        {
            Room2C_BattleEnd message = Room2C_BattleEnd.Create();
            message.RoundIndex = self.RoundIndex;
            message.HeroAllDead = BattleTurnHelper.IsCampAllDead(self, EBattleCamp.Hero);
            message.EnemyAllDead = BattleTurnHelper.IsCampAllDead(self, EBattleCamp.Enemy);
            BattleMessageHelper.Broadcast(self, message);
        }
    }
}
