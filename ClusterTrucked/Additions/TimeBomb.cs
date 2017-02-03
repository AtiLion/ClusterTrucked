using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked.Additions
{
    public class TimeBomb : MonoBehaviour
    {
        private DateTime start;

        public void Start()
        {
            start = DateTime.Now;
        }

        public void Update()
        {
            if ((DateTime.Now - start).TotalMilliseconds >= 1000)
            {
                carCheckDamage[] cars = GameObject.FindObjectsOfType(typeof(carCheckDamage)) as carCheckDamage[];
                foreach (carCheckDamage c in cars)
                {
                    if (c.transform.root.GetComponent<car>().gameObject == gameObject)
                    {
                        c.Explode();
                    }
                }
                GameObject.Destroy(this);
            }
        }
    }
}
