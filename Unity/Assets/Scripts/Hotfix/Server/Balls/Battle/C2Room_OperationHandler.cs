using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.RoomRoot)]
    public class C2Room_OperationHandler : MessageHandler<Scene, C2Room_Operation>
    {
        protected override async ETTask Run(Scene root, C2Room_Operation message)
        {
            if (message.OperateInfos == null || message.OperateInfos.Count == 0)
            {
                Log.Error($"reveice null operate info");
                return;
            }
            var roomManager = root.GetComponent<StateSyncRoomManagerComponent>();
            // if (roomManager.PlayerToRoom.TryGetValue(message.PlayerId, out var playerId))
            // {//在房间内战斗中
            //     
            // }
            // else
            // {
            //     return;
            // }

            StateSyncRoom room = roomManager.GetRoom(message.PlayerId);
            // StateSyncRoom room = root.GetComponent<StateSyncRoom>();
            // StateSyncRoomServerComponent roomServerComponent = room.GetComponent<StateSyncRoomServerComponent>();
            // StateSyncRoomPlayer roomPlayer = room.GetChild<StateSyncRoomPlayer>(message.PlayerId);
            var battleComponent = room.GetComponent<BattleComponent>();
            // Log.Info($"rev C2Room_Operation");
            Room2C_Operation room2COperation = Room2C_Operation.Create();
            room2COperation.OperateInfos = new List<OperateReplyInfo>();
            Unit unit =  battleComponent.GetChild<Unit>(message.PlayerId);
            if (unit == null)
            {
                Log.Error($"cant not find unit, player id : {message.PlayerId}");
                return;
            }
            foreach (OperateInfo operateInfo in message.OperateInfos)
            {
                EOperateType operateType = (EOperateType)operateInfo.OperateType;
                switch (operateType)
                {
                    case EOperateType.Move:
                    {
                        //收到移动消息，往前移动，如果有地形，需要判定前方位置是否可以移动。
                        //移动逻辑挪到移动组件处理
                        // float speed = unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.Speed);
                        // speed = speed == 0 ? 3 : speed;
                        // float3 v3 = unit.Position + operateInfo.Vec3 * speed / DefineCore.LogicFrame;
                        // unit.Position = v3;
                        if ((EInputType)operateInfo.InputType == EInputType.KeyUp)
                        {
                            unit.GetComponent<PlayerMoveComponent>().StopMove();
                        }
                        else
                        {
                            unit.Forward = operateInfo.Vec3;
                            unit.GetComponent<PlayerMoveComponent>().StartMove();
                        }
                        // Room2C_JoystickMove m2CJoystickMove = Room2C_JoystickMove.Create();
                        // m2CJoystickMove.Position = unit.Position;
                        // m2CJoystickMove.MoveForward = unit.Forward; 
                        // m2CJoystickMove.Id = unit.Id;
                        //
                        // MapMessageHelper.Broadcast(unit, m2CJoystickMove);
                        break;
                    }
                    case EOperateType.Attack:
                    {
                        
                        break;
                    }
                    case EOperateType.Skill1:
                    {
                        //主动技能1
                        if (unit?.GetComponent<SkillComponent>()?.SpellSkill(ESkillAbstractType.ActiveSkill) == true)
                        {
                            OperateReplyInfo info = OperateReplyInfo.Create();
                            info.OperateType = (int)operateType;
                            info.Status = 0;
                            room2COperation.OperateInfos.Add(info);
                        }
                        break;
                    }
                    case EOperateType.Skill2:
                    {
                        //主动技能2
                        if (unit?.GetComponent<SkillComponent>()?.SpellSkill(ESkillAbstractType.ActiveSkill, 1) == true)
                        {
                            OperateReplyInfo info = OperateReplyInfo.Create();
                            info.OperateType = (int)operateType; info.Status = 0;
                            room2COperation.OperateInfos.Add(info);
                        }
                        break;
                    }
                }
            }
            if(room2COperation.OperateInfos?.Count > 0) MapMessageHelper.SendToClient(unit, room2COperation);

            await ETTask.CompletedTask;
        }
    }
    
}