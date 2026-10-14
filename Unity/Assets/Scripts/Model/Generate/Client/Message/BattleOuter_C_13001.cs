using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// Battle Start ///////////////////////////////////
    /// </summary>
    /// <summary>
    /// 战斗回合开始：同步本回合的攻击序列（出手顺序）
    /// </summary>
    [MemoryPackable]
    [Message(BattleOuter.Room2C_BattleRoundStart)]
    public partial class Room2C_BattleRoundStart : MessageObject, IMessage
    {
        public static Room2C_BattleRoundStart Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Room2C_BattleRoundStart), isFromPool) as Room2C_BattleRoundStart;
        }

        [MemoryPackOrder(0)]
        public int RoundIndex { get; set; }

        [MemoryPackOrder(1)]
        public List<long> AttackSequence { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RoundIndex = default;
            this.AttackSequence.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    /// <summary>
    /// 战斗出手：同步当前出手的单位
    /// </summary>
    [MemoryPackable]
    [Message(BattleOuter.Room2C_BattleTurn)]
    public partial class Room2C_BattleTurn : MessageObject, IMessage
    {
        public static Room2C_BattleTurn Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Room2C_BattleTurn), isFromPool) as Room2C_BattleTurn;
        }

        [MemoryPackOrder(0)]
        public int RoundIndex { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RoundIndex = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    /// <summary>
    /// 战斗结束：同步胜负结果
    /// </summary>
    [MemoryPackable]
    [Message(BattleOuter.Room2C_BattleEnd)]
    public partial class Room2C_BattleEnd : MessageObject, IMessage
    {
        public static Room2C_BattleEnd Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Room2C_BattleEnd), isFromPool) as Room2C_BattleEnd;
        }

        [MemoryPackOrder(0)]
        public int RoundIndex { get; set; }

        [MemoryPackOrder(1)]
        public bool HeroAllDead { get; set; }

        [MemoryPackOrder(2)]
        public bool EnemyAllDead { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RoundIndex = default;
            this.HeroAllDead = default;
            this.EnemyAllDead = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    /// <summary>
    /// Battle End ///////////////////////////////////
    /// </summary>
    public static class BattleOuter
    {
        public const ushort Room2C_BattleRoundStart = 13002;
        public const ushort Room2C_BattleTurn = 13003;
        public const ushort Room2C_BattleEnd = 13004;
    }
}