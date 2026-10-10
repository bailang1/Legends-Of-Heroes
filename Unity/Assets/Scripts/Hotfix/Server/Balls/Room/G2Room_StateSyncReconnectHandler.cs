using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.RoomRoot)]
    public class G2Room_StateSyncReconnectHandler : MessageHandler<Scene, G2Room_StateSyncReconnect, Room2G_StateSyncReconnect>
    {
        protected override async ETTask Run(Scene root, G2Room_StateSyncReconnect request, Room2G_StateSyncReconnect response)
        {
            var room = root.GetComponent<StateSyncRoomManagerComponent>();
            if (room.PlayerToRoom.TryGetValue(request.PlayerId, out var player))
            {//在房间内战斗中
                
            }
            else
            {
                
            }
            // UnitComponent lsUnitComponent = room.World.GetComponent<UnitComponent>();
            // foreach (long playerId in room.PlayerIds)
            // {
            //     Unit lsUnit = lsUnitComponent.GetChild<Unit>(playerId);
            //     response.UnitInfos.Add(new UnitInfo() {PlayerId = playerId, Position = lsUnit.Position, Rotation = lsUnit.Rotation});    
            // }

            // response.Frame = room.AuthorityFrame;
            await ETTask.CompletedTask;
        }
    }
}