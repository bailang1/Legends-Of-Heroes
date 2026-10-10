using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterBattleUnitCreate_CreateUnitView: AEvent<Scene, AfterBattleUnitCreate>
    {
        protected override async ETTask Run(Scene scene, AfterBattleUnitCreate args)
        {
            Unit unit = args.Unit;
            // Unit View层
            string assetsName = $"Player";
            GlobalComponent globalComponent = scene.Root().GetComponent<GlobalComponent>();
            GameObject go = null;
            switch (unit.Type())
            {
                case EUnitType.Player:
                {
                    GameObject prefab = await scene.GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);

                    go = UnityEngine.Object.Instantiate(prefab, globalComponent.Unit, true);
                    Transform iconTrans = go.transform.Find("Root/Sprite");
                    if (iconTrans != null)
                    {
                        SpriteRenderer spriteRenderer = iconTrans.GetComponent<SpriteRenderer>();
                        if (spriteRenderer != null)
                        {
                            spriteRenderer.sprite = scene.GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>($"Avatar{unit.Config().Id - 1000}");
                        }
                    }

                    int hp = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp);
                    if (hp > 10)
                        go.transform.localScale = Vector3.one * hp / 50f;
                    break;
                }
                case EUnitType.Bullet:
                {
                    GameObject prefab = await scene.GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>("Bullet_001");
                    go = UnityEngine.Object.Instantiate(prefab, globalComponent.Unit, true);
                    break;
                }
            }

            go.transform.position = unit.Position;
            // unit.AddComponent<GameObjectComponent>().Init(go);
            // unit.AddComponent<AnimatorComponent>();
            await ETTask.CompletedTask;
        }
    }
}