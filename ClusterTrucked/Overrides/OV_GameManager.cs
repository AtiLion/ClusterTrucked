using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked.Overrides
{
    public class OV_GameManager : MonoBehaviour
    {
        public void LoseLevel()
        {
            /*if (CManager.hk_Player.godmode)
            {
                Variables.lPlayer.dead = false;
                return;
            }*/

            GameManager gMan = (GameManager)typeof(player).GetField("gMan", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Variables.lPlayer);
            bool done = (bool)typeof(GameManager).GetField("done", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gMan);

            if (!GameManager.Playtesting)
            {
                if (!done)
                {
                    gMan.scoreCheck.CutIt(false);
                    typeof(GameManager).GetType().GetMethod("LevelOver", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gMan, new object[0]);
                    gMan.won = false;
                    GameManager.mapDeaths++;
                    gMan.StartCoroutine("popUI", gMan.deathScreen.transform);
                }
            }
            else if(!done)
            {
                typeof(GameManager).GetType().GetMethod("LevelOver", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gMan, new object[0]);
                gMan.won = false;
                gMan.StartCoroutine("popUI", gMan.deathScreen.transform);
            }
        }
    }
}
