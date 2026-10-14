namespace ET.Client
{
    /// <summary>
    /// 战斗回合开始：更新本回合攻击序列
    /// </summary>
    [MessageHandler(SceneType.Demo)]
    [FriendOf(typeof(BattleComponent))]
    public class Room2C_BattleRoundStartHandler : MessageHandler<Scene, Room2C_BattleRoundStart>
    {
        protected override async ETTask Run(Scene root, Room2C_BattleRoundStart message)
        {
            Scene currentScene = root.CurrentScene();
            BattleComponent battle = currentScene?.GetComponent<BattleComponent>();
            if (battle != null)
            {
                battle.RoundIndex = message.RoundIndex;
                battle.AttackSequence.Clear();
                battle.AttackSequence.AddRange(message.AttackSequence);
            }

            Log.Info($"[战斗] 回合开始:{message.RoundIndex} 攻击序列:[{string.Join(",", message.AttackSequence)}]");
            await ETTask.CompletedTask;
        }
    }
}
