using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked.Overrides
{
    public class OV_Player : MonoBehaviour
    {
        public void Die(int cause)
        {
            if (Variables.lPlayer == null || Variables.lPlayer.gameObject == null)
                return;

            if (CManager.hk_Player.godmode)
                return;

            Manager man = (Manager)typeof(player).GetField("man", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Variables.lPlayer);
            GameManager gMan = (GameManager)typeof(player).GetField("gMan", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Variables.lPlayer);

            if (man == null || gMan == null)
                return;

            if (!Variables.lPlayer.dead && !gMan.won)
            {
                if (man != null)
                {
                    gMan.LoseLevel();
                }
                Variables.lPlayer.dead = true;
                Variables.lPlayer.deathSounds.volume = UnityEngine.Random.Range(0.4f, 0.5f);
                Variables.lPlayer.deathSounds.pitch = UnityEngine.Random.Range(0.95f, 1.05f);
                if (cause == 0)
                    Variables.lPlayer.deathSounds.PlayOneShot(Variables.lPlayer.splat[UnityEngine.Random.Range(0, Variables.lPlayer.splat.Length)]);
                if (cause == 1)
                    Variables.lPlayer.deathSounds.PlayOneShot(Variables.lPlayer.burn[UnityEngine.Random.Range(0, Variables.lPlayer.burn.Length)]);
                if (cause == 2)
                    Variables.lPlayer.deathSounds.PlayOneShot(Variables.lPlayer.laser[UnityEngine.Random.Range(0, Variables.lPlayer.laser.Length)]);
            }
        }
    }
}
