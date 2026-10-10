using System;

namespace ET.Server
{
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_StartBattleHandler : MessageSessionHandler<C2G_StartBattle, G2C_StartBattle>
    {
        protected override async ETTask Run(Session session, C2G_StartBattle request, G2C_StartBattle response)
        {
            Player player = session.GetComponent<SessionPlayerComponent>().Player;
            if (player == null)
            {
                response.Error = ErrorCode.ERR_PlayerNotFound;
                response.Message = "Player not found";
                return;
            }

            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.Match;

            G2Match_CreateRoom g2MatchCreateRoom = G2Match_CreateRoom.Create();
            g2MatchCreateRoom.PlayerId = player.Id;
            g2MatchCreateRoom.RoomName = "M";
            g2MatchCreateRoom.Mode = RoomMode.ModeFree;
            g2MatchCreateRoom.MaxPlayers = request.monsterId;
            g2MatchCreateRoom.Password = "";

            Match2G_CreateRoom match2GCreateRoom = await session.Root().GetComponent<MessageSender>().Call(startSceneConfig.ActorId, g2MatchCreateRoom) as Match2G_CreateRoom;

            response.Error = match2GCreateRoom.Error;
            response.Message = match2GCreateRoom.Message;
            //后续添加阵型信息
            // response.RoomInfo = match2GCreateRoom.RoomInfo;
        }
    }
}