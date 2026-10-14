namespace ET.Client
{
    /// <summary>
    /// 战斗出手：更新当前出手单位
    /// </summary>
    [MessageHandler(SceneType.Demo)]
    [FriendOf(typeof(BattleComponent))]
    public class Room2C_BattleTurnHandler : MessageHandler<Scene, Room2C_BattleTurn>
    {
        protected override async ETTask Run(Scene root, Room2C_BattleTurn message)
        {
            Scene currentScene = root.CurrentScene();
            BattleComponent battle = currentScene?.GetComponent<BattleComponent>();
            if (battle != null)
            {
                battle.RoundIndex = message.RoundIndex;
                battle.CurrentUnitId = message.UnitId;
            }

            Log.Info($"[战斗] 回合:{message.RoundIndex} 出手单位:{message.UnitId}");
            await ETTask.CompletedTask;
        }
    }
}
