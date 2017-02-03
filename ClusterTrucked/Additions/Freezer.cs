using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked.Additions
{
    public class Freezer : MonoBehaviour
    {
        private DateTime frozen;
        private RigidState rs;

        public void Start()
        {
            frozen = DateTime.Now;
            carCheckDamage[] cars = GameObject.FindObjectsOfType(typeof(carCheckDamage)) as carCheckDamage[];
            foreach (carCheckDamage c in cars)
            {
                if (c.transform.root.GetComponent<car>().gameObject == gameObject)
                {
                    rs = new RigidState((Rigidbody)typeof(carCheckDamage).GetField("rig", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(c));
                }
            }
        }

        public void Update()
        {
            if ((DateTime.Now - frozen).TotalMilliseconds >= 1000)
            {
                rs.unFreeze();
                GameObject.Destroy(this);
            }
        }

        private class RigidState
        {
            public RigidState(Rigidbody rigid)
            {
                mRigidbody = rigid;
                mDamageCheck = mRigidbody.GetComponent<carCheckDamage>();
                mBeforeColdVelocity = mRigidbody.velocity;
                mBeforeColdAngularVelocity = mRigidbody.angularVelocity;
                mRigidbody.velocity = Vector3.zero;
                mRigidbody.angularVelocity = Vector3.zero;
                mRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                mRigidbody.useGravity = false;
                mRigidbody.isKinematic = true;
                mDamageCheck.SetImmunity(false);
            }

            public void unFreeze()
            {
                if (mRigidbody == null)
                {
                    return;
                }
                mRigidbody.constraints = RigidbodyConstraints.None;
                mRigidbody.isKinematic = false;
                mRigidbody.velocity = mBeforeColdVelocity;
                mRigidbody.angularVelocity = mBeforeColdAngularVelocity;
                mRigidbody.useGravity = true;
                mDamageCheck.SetImmunity(false);
            }

            public Vector3 mBeforeColdAngularVelocity;

            public Vector3 mBeforeColdVelocity;

            private carCheckDamage mDamageCheck;

            public Rigidbody mRigidbody;
        }
    }
}
