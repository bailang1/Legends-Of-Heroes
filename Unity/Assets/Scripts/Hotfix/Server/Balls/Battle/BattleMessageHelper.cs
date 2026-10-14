namespace ET.Server
{
    /// <summary>
    /// 战斗消息助手：把战斗过程消息同步给客户端
    /// </summary>
    public static class BattleMessageHelper
    {
        /// <summary>
        /// 广播战斗消息给我方玩家
        /// 怪物（敌方）没有客户端连接，不发送
        /// </summary>
        public static void Broadcast(BattleComponent battle, IMessage message)
        {
            // 广播的消息不能被池回收
            (message as MessageObject).IsFromPool = false;

            UnitComponent unitComponent = battle.GetComponent<UnitComponent>();
            if (unitComponent == null)
            {
                return;
            }

            // 网络底层做了优化，同一条消息不会多次序列化
            MessageLocationSenderOneType oneType = battle.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession);
            foreach (Entity child in unitComponent.Children.Values)
            {
                if (child is not Unit unit || unit.BattleCamp() != EBattleCamp.Hero)
                {
                    continue;
                }
                oneType.Send(unit.Id, message);
            }
        }
    }
}
