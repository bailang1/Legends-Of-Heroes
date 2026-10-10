namespace ET.Client
{
    [EntitySystemOf(typeof(BattleComponent))]
    [FriendOf(typeof(BattleComponent))]
    public static partial class BattleComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.BattleComponent self)
        {
            self.AddComponent<UnitComponent>();
        }
        [EntitySystem]
        private static void FixedUpdate(this ET.Client.BattleComponent self)
        {

        }
    }
}
