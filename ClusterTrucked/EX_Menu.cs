using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ClusterTrucked
{
    public class EX_Menu : MonoBehaviour
    {
        public bool isOpen;
        public string title;
        public Rect window;
        public int wID;

        public EX_Menu(Rect window, string title, int wID, bool isOpen)
        {
            this.isOpen = isOpen;
            this.title = title;
            this.window = window;
            this.wID = wID;
        }

        public virtual void runWin(int id)
        {
            if (id != 0)
            {
                if (GUILayout.Button("Exit"))
                {
                    isOpen = false;
                }
            }
            GUI.DragWindow();
        }
    }
}
