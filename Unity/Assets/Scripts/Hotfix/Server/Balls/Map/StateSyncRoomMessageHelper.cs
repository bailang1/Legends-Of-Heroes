namespace ET.Server
{

    public static partial class StateSyncRoomMessageHelper
    {
        public static void BroadCast(StateSyncRoom room, IMessage message)
        {
            // 广播的消息不能被池回收
            (message as MessageObject).IsFromPool = false;

            BattleComponent battleComponent = room.GetComponent<BattleComponent>();
            var unitComponent = battleComponent.GetComponent<UnitComponent>();
            MessageLocationSenderComponent messageLocationSenderComponent = room.Root().GetComponent<MessageLocationSenderComponent>();
            foreach (var kv in unitComponent.Children)
            {
                Unit roomPlayer = kv.Value as Unit;

                // if (!roomPlayer.IsOnline)
                // {
                //     continue;
                // }
                
                messageLocationSenderComponent.Get(LocationType.GateSession).Send(roomPlayer.Id, message);
            }
        }
    }
}