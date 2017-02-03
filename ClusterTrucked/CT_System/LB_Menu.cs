using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked.CT_System
{
    public class LB_Menu : MonoBehaviour
    {
        private bool isOpen = false;
        private List<EX_Menu> menus = new List<EX_Menu>();

        public void Start()
        {
            menus.Add(CManager.hk_Main);
            menus.Add(CManager.hk_Player);
            menus.Add(CManager.hk_Level);
            menus.Add(CManager.hk_Truck);
            menus.Add(CManager.hk_Skill);
            menus.Add(CManager.hk_Misc);
            menus.Add(CManager.hk_Fun);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                isOpen = !isOpen;
            }
        }

        public void OnGUI()
        {
            if (!isOpen)
                return;

            foreach (EX_Menu menu in menus)
            {
                if (menu.isOpen)
                {
                    menu.window = GUILayout.Window(menu.wID, menu.window, menu.runWin, menu.title);
                }
            }
        }
    }
}
