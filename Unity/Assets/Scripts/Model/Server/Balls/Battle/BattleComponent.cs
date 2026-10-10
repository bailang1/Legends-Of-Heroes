using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(StateSyncRoom))]
    public class BattleComponent: Entity, IAwake, IFixedUpdate
    {
    }

}