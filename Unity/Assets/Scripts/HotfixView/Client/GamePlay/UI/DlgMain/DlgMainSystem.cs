using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgMain))]
    public static class DlgMainSystem
    {

        public static void RegisterUIEvent(this DlgMain self)
        {
            self.View.EBtnFunction1Button.AddListenerAsync(self.Root(), self.OnStartBattleClick);
        }

        public static void ShowWindow(this DlgMain self, Entity contextData = null)
        {
        }

        public static async ETTask OnStartBattleClick(this DlgMain self)
        {
            var response = await EnterMapHelper.StartBattleAsync(self.Fiber(), 1);
        }

    }
}
