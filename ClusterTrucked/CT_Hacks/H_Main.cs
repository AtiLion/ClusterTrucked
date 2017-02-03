using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked.CT_Hacks
{
    public class H_Main : EX_Menu
    {
        public H_Main() : base(new Rect(10, 10, 200, 200), "ClusterTrucked by AtiLion", 0, true) {}

        public override void runWin(int id)
        {
            if (GUILayout.Button("Player Menu"))
            {
                CManager.hk_Player.isOpen = !CManager.hk_Player.isOpen;
            }
            if (GUILayout.Button("Truck Menu"))
            {
                CManager.hk_Truck.isOpen = !CManager.hk_Truck.isOpen;
            }
            if (GUILayout.Button("Level Menu"))
            {
                CManager.hk_Level.isOpen = !CManager.hk_Level.isOpen;
            }
            if (GUILayout.Button("Skill Menu"))
            {
                CManager.hk_Skill.isOpen = !CManager.hk_Skill.isOpen;
            }
            if (GUILayout.Button("Misc Menu"))
            {
                CManager.hk_Misc.isOpen = !CManager.hk_Misc.isOpen;
            }
            if (GUILayout.Button("Fun Menu"))
            {
                CManager.hk_Fun.isOpen = !CManager.hk_Fun.isOpen;
            }
            GUILayout.Label("Created by AtiLion");
            base.runWin(id);
        }
    }
}
