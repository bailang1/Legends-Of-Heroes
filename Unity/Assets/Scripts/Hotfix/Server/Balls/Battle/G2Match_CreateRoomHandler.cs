using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Match)]
    public class G2Match_CreateRoomHandler : MessageHandler<Scene, G2Match_CreateRoom, Match2G_CreateRoom>
    {
        protected override async ETTask Run(Scene scene, G2Match_CreateRoom request, Match2G_CreateRoom response)
        {
            StateSyncRoomManagerComponent roomManagerComponent = scene.GetComponent<StateSyncRoomManagerComponent>();
            if (roomManagerComponent == null)
            {
                roomManagerComponent = scene.AddComponent<StateSyncRoomManagerComponent>();
            }

            long playerId = request.PlayerId;
            StateSyncRoom room = roomManagerComponent.CreateRoom(
                request.RoomName,
                request.Mode,
                request.MaxPlayers,
                request.Password,
                playerId
            );
            
            BattleComponent battleComponent = room.GetOrAddComponent<BattleComponent>();
            // UnitFactory.Create2(battleComponent, playerId, EUnitType.RoomPlayer);
            battleComponent.InitFriend(new List<long>(){playerId});//TEST MONSTER id
            battleComponent.InitEnemy(request.MaxPlayers);

            // 构建攻击序列并开始回合制战斗
            battleComponent.StartBattle();
            
            response.Error = ErrorCode.ERR_Success;
            response.Message = "Create room success";
            response.RoomInfo = roomManagerComponent.GetRoomInfo(room.RoomId);
            await ETTask.CompletedTask;
        }
    }
}