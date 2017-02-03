using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked.CT_Hacks
{
    public class H_Skill : EX_Menu
    {
        private string sPoints = "0";

        public H_Skill() : base(new Rect(10, 10, 200, 200), "Skill Menu", 4, false) {}

        public override void runWin(int id)
        {
            if (GUILayout.Button("Unlock All Skills"))
            {
                abilityInfo[] abinfo = GameObject.FindObjectsOfType(typeof(abilityInfo)) as abilityInfo[];
                foreach (abilityInfo abi in abinfo)
                {
                    abi.UnlockMe();
                }
            }
            GUILayout.Label("Style Points:");
            sPoints = GUILayout.TextField(sPoints);
            if (GUILayout.Button("Get Style Points"))
            {
                float sP;
                if (float.TryParse(sPoints, out sP))
                {
                    pointsHandler.AddPoints(sP);
                }
            }
            base.runWin(id);
        }
    }
}
