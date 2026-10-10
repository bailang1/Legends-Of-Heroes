using System;
using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(BattleComponent))]
    [FriendOf(typeof(BattleComponent))]
    public static partial class BattleComponentSystem
    {
        public static void InitFriend(this BattleComponent self, List<long> unitInfos)
        {
            for (int i = 0; i < unitInfos.Count; ++i)
            {
                var unitId = unitInfos[i];
                // self.PlayerIds.Add(unitId);
               var player = UnitFactory.Create(self, unitId, EUnitType.RoomPlayer);
                // self.AddChildWithId<Unit>(player, unitId);
            }
        }

        public static void InitEnemy(this BattleComponent self, int Id)
        {
            // self.StartTime = startTime;
            for (int i = 0; i < 5; ++i)
            {
                var monster = UnitFactory.Create(self, i, EUnitType.Monster);
                // self.EnemyIds.Add(i);
            }
        }

        [EntitySystem]
        private static void Awake(this BattleComponent self)
        {
            self.AddComponent<UnitComponent>();
        }

        [EntitySystem]
        private static void FixedUpdate(this BattleComponent self)
        {
            // self.UpdateRoomPlayer();
        }

        /// <summary>
        /// 暂定每帧同步角色位置/朝向信息
        /// </summary>
        /// <param name="self"></param>
        private static void UpdateRoomPlayer(this BattleComponent self)
        {
            M2C_SyncUnitTransforms sync = M2C_SyncUnitTransforms.Create();

            // foreach (StateSyncRoomPlayer roomPlayer in self.Children.Values)
            // {
            //     if (roomPlayer.IsOnline)
            //     {
            //         Unit unit = roomPlayer.Unit;
            //         if (unit == null)
            //             continue;
            //         TransformInfo info = TransformInfo.Create();
            //         info.UnitId = unit.Id;
            //         info.Forward = unit.Forward;
            //         info.Position = unit.Position;
            //         sync.TransformInfos.Add(info);
            //     }
            // }
            // StateSyncRoomMessageHelper.BroadCast(self.GetParent<StateSyncRoom>(), sync);
        }
    }
}