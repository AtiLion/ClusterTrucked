using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked.CT_Hacks
{
    public class H_Misc : EX_Menu
    {
        public H_Misc() : base(new Rect(10, 10, 200, 200), "Misc Menu", 5, false) {}

        public override void runWin(int id)
        {
            GUILayout.Label("Request what to add here ;D");
            base.runWin(id);
        }
    }
}
