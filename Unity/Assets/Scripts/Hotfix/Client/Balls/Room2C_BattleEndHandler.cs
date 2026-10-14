namespace ET.Client
{
    /// <summary>
    /// 战斗结束：更新战斗结果
    /// </summary>
    [MessageHandler(SceneType.Demo)]
    [FriendOf(typeof(BattleComponent))]
    public class Room2C_BattleEndHandler : MessageHandler<Scene, Room2C_BattleEnd>
    {
        protected override async ETTask Run(Scene root, Room2C_BattleEnd message)
        {
            Scene currentScene = root.CurrentScene();
            BattleComponent battle = currentScene?.GetComponent<BattleComponent>();
            if (battle != null)
            {
                battle.RoundIndex = message.RoundIndex;
                battle.IsBattleEnd = true;
            }

            Log.Info($"[战斗] 结束 回合:{message.RoundIndex} 我方全灭:{message.HeroAllDead} 敌方全灭:{message.EnemyAllDead}");
            await ETTask.CompletedTask;
        }
    }
}
