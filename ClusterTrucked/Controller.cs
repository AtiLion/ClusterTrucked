using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using ClusterTrucked.Overrides;

namespace ClusterTrucked
{
    public class Controller : MonoBehaviour
    {
        private static GameObject go_Hacks;
        private static GameObject go_System;

        public void Start()
        {
            go_Hacks = new GameObject();
            go_System = new GameObject();

            DontDestroyOnLoad(go_Hacks);
            DontDestroyOnLoad(go_System);

            CManager.injSystem(go_System);
            CManager.injHacks(go_Hacks);

            Application.targetFrameRate = -1;
        }
    }
}
