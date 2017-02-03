using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked.CT_Hacks
{
    public class H_Player : EX_Menu
    {
        private bool fly = false;
        public bool godmode = false;
        private float speedhack = 1.2f;

        private float prevSpeedhack = 1.2f;
        private player ply = null;

        public H_Player() : base(new Rect(10, 10, 200, 200), "Player Menu", 1, false) {}

        public void Update()
        {
            if (Variables.lPlayer == null || Variables.lPlayer.gameObject == null)
                return;

            if (fly)
            {
                Variables.lPlayer.hasTouchedGround = true;
                if (Input.GetKey(KeyCode.Space))
                {
                    Vector3 pos = Variables.lPlayer.transform.position;
                    pos.y += 0.5f;
                    Variables.lPlayer.transform.position = pos;
                }
            }
            if (speedhack != prevSpeedhack || ply == null || ply == Variables.lPlayer)
            {
                typeof(player).GetField("airSpeed", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(Variables.lPlayer, speedhack);
                typeof(player).GetField("forceAmount", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(Variables.lPlayer, speedhack * 1000);
                prevSpeedhack = speedhack;
                ply = Variables.lPlayer;
            }
        }

        public override void runWin(int id)
        {
            fly = GUILayout.Toggle(fly, "Fly Hack");
            //godmode = GUILayout.Toggle(godmode, "God Mode");
            GUILayout.Label("Speed: " + speedhack);
            speedhack = (float)Math.Round(GUILayout.HorizontalSlider(speedhack, 0f, 10f), 1);
            base.runWin(id);
        }
    }
}
