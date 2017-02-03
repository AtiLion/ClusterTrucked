using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using ClusterTrucked.Additions;

namespace ClusterTrucked.CT_Hacks
{
    public class H_Fun : EX_Menu
    {
        private bool explosium = false;
        private bool nogravity = false;
        private bool freezetag = false;
        private bool jumpingtrucks = false;
        private bool rainingtrucks = false;

        public H_Fun() : base(new Rect(10, 10, 200, 200), "Fun Menu", 6, false) {}

        public void Update()
        {
            if (explosium)
            {
                if (Variables.lPlayer.lastCar != null && Variables.lPlayer.lastCar.gameObject.GetComponent<TimeBomb>() == null)
                {
                    Variables.lPlayer.lastCar.gameObject.AddComponent<TimeBomb>();
                }
            }
            if (nogravity)
            {
                carCheckDamage[] cars = GameObject.FindObjectsOfType(typeof(carCheckDamage)) as carCheckDamage[];
                foreach (carCheckDamage c in cars)
                {
                    ((Rigidbody)typeof(carCheckDamage).GetField("rig", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(c)).useGravity = false;
                }
            }
            if (freezetag)
            {
                if (Variables.lPlayer.lastCar != null && Variables.lPlayer.lastCar.gameObject.GetComponent<Freezer>() == null)
                {
                    Variables.lPlayer.lastCar.gameObject.AddComponent<Freezer>();
                }
            }
        }

        public override void runWin(int id)
        {
            explosium = GUILayout.Toggle(explosium, "Explosium");
            nogravity = GUILayout.Toggle(nogravity, "0 Gravity");
            freezetag = GUILayout.Toggle(freezetag, "Freeze Tag");
            //jumpingtrucks = GUILayout.Toggle(jumpingtrucks, "Jumping Trucks");
            //rainingtrucks = GUILayout.Toggle(rainingtrucks, "Raining Trucks");
            GUILayout.Label("");
            GUILayout.Label("Explosium: Trucks explode 1 second after being landed on!");
            GUILayout.Label("0 Gravity: Trucks have no gravity good luck");
            GUILayout.Label("Freeze Tag: Trucks freeze upon being touched");
            //GUILayout.Label("Jumping Trucks: Trucks randomly get launched in the air");
            //GUILayout.Label("Raining Trucks: It's raining trucks hallelujah!!");
            base.runWin(id);
        }
    }
}
