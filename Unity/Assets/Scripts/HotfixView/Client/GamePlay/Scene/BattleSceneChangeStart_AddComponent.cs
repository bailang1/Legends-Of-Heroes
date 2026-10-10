using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class BattleSceneChangeStart_AddComponent : AEvent<Scene, BattleSceneChangeStart>
    {
        protected override async ETTask Run(Scene root, BattleSceneChangeStart args)
        {
            try
            {
                //删除大地图player
                CurrentScenesComponent currentScenesComponent = root.GetComponent<CurrentScenesComponent>();
                var instanceId = currentScenesComponent.InstanceId;
                currentScenesComponent.Scene?.Dispose(); // 删除之前的CurrentScene，创建新的
                Scene currentScene = SceneChangeHelper.Create(instanceId, args.mapName, currentScenesComponent);
                // Scene currentScene = root.CurrentScene();
                //关闭所有UI,并打开遮罩UI
                root.GetComponent<UIComponent>().CloseAllWindow();
                // await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Loading);
                
                ResourcesLoaderComponent resourcesLoaderComponent = currentScene.GetComponent<ResourcesLoaderComponent>();

                // 加载战斗场景资源
                await resourcesLoaderComponent.LoadSceneAsync($"Assets/Bundles/Scenes/{args.mapName}.unity", LoadSceneMode.Single);
         
                // currentScene.AddComponent<OperaComponent>();
                var battleComponent = currentScene.GetOrAddComponent<BattleComponent>();
                //生成角色
                // M2C_CreateMyUnit m2CCreateMyUnit = waitCreateMyUnit.Message;
                UnitInfo unitInfo = UnitInfo.Create();//模拟数据 应该服务器发过来
                unitInfo.ConfigId = 1001;
                unitInfo.UnitId = 1;
                unitInfo.Type = (int)EUnitType.RoomPlayer;
                unitInfo.Position = new float3(-1,0,0);
                unitInfo.Forward = Vector3.forward;
                UnitFactory.Create(battleComponent, unitInfo);

                for (int i = 0; i < 5; i++)
                {
                    UnitInfo uInfo = UnitInfo.Create();//模拟数据 应该服务器发过来
                    uInfo.ConfigId = 1001;
                    uInfo.UnitId = 2+i;
                    uInfo.Type = (int)EUnitType.RoomPlayer;
                    uInfo.Position = new float3(1*i,0,0);
                    uInfo.Forward = -Vector3.forward;
                    UnitFactory.Create(battleComponent, uInfo);
                }
                root.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Battle);
                //告诉服务器客户端准备好了, 然后就开始同步 战斗消息
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }
    }
}
