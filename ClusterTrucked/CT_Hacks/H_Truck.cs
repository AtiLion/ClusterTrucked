using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked.CT_Hacks
{
    public class H_Truck : EX_Menu
    {
        private bool immortalTrucks = false;

        private int prevNumber = 0;

        public H_Truck() : base(new Rect(10, 10, 200, 200), "Truck Menu", 3, false) {}

        public void Update()
        {
            if (Variables.lPlayer == null || Variables.lPlayer.gameObject == null)
                return;

            if (immortalTrucks)
            {
                carCheckDamage[] cars = GameObject.FindObjectsOfType(typeof(carCheckDamage)) as carCheckDamage[];
                foreach (carCheckDamage c in cars)
                {
                    c.SetImmunity(false);
                }
                prevNumber = car.numberOfTrucks;
            }
        }

        public override void runWin(int id)
        {
            immortalTrucks = GUILayout.Toggle(immortalTrucks, "Immortal Trucks");
            base.runWin(id);
        }
    }
}
