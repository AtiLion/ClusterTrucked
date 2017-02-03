using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using ClusterTrucked.CT_System;
using ClusterTrucked.CT_Hacks;

namespace ClusterTrucked
{
    public class CManager
    {
        //SYSTEM MODS
        public static LB_Menu lib_Menu;
        public static LB_Info lib_Info;

        //HACK MODS
        public static H_Main hk_Main;
        public static H_Player hk_Player;
        public static H_Level hk_Level;
        public static H_Truck hk_Truck;
        public static H_Skill hk_Skill;
        public static H_Misc hk_Misc;
        public static H_Fun hk_Fun;

        public static void injHacks(GameObject go)
        {
            hk_Main = go.AddComponent<H_Main>();
            hk_Player = go.AddComponent<H_Player>();
            hk_Level = go.AddComponent<H_Level>();
            hk_Truck = go.AddComponent<H_Truck>();
            hk_Skill = go.AddComponent<H_Skill>();
            hk_Misc = go.AddComponent<H_Misc>();
            hk_Fun = go.AddComponent<H_Fun>();
        }

        public static void injSystem(GameObject go)
        {
            lib_Menu = go.AddComponent<LB_Menu>();
            lib_Info = go.AddComponent<LB_Info>();
        }
    }
}
