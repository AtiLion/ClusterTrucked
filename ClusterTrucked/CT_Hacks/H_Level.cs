using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked.CT_Hacks
{
    public class H_Level : EX_Menu
    {
        private bool instaWin = false;
        private bool alwaysAce = false;
        private bool noTime = false;
        private bool constTricks = false;

        public H_Level() : base(new Rect(10, 10, 200, 200), "Level Menu", 2, false) {}

        public void Update()
        {
            if (Variables.lPlayer == null || Variables.lPlayer.gameObject == null)
                return;

            if (instaWin)
            {
                ((GameManager)typeof(player).GetField("gMan", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Variables.lPlayer)).WinLevel();
            }
            if (alwaysAce)
            {
                ((GameManager)typeof(player).GetField("gMan", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Variables.lPlayer)).scoreCheck.firstTry = true;
            }
            if (noTime)
            {
                GameManager.totalTime = 0;
                GameManager.mapTime = 0.001f;
            }
            if (constTricks)
            {
                scoreHandler.Instance.AddScore(1000f, "360 NO SCOPE", 2);
            }
        }

        public override void runWin(int id)
        {
            instaWin = GUILayout.Toggle(instaWin, "Instant Win");
            alwaysAce = GUILayout.Toggle(alwaysAce, "Always Ace");
            noTime = GUILayout.Toggle(noTime, "No Timer");
            constTricks = GUILayout.Toggle(constTricks, "Constant Tricks");
            base.runWin(id);
        }
    }
}
