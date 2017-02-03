using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked.CT_System
{
    public class LB_Info : MonoBehaviour
    {
        public void Update()
        {
            if (Variables.lPlayer == null || Variables.lPlayer.gameObject == null)
            {
                Variables.lPlayer = GameObject.FindObjectOfType<player>();
            }
        }
    }
}
