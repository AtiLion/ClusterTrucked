using System;
using System.Reflection;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using ClusterTrucked.Overrides;

namespace ClusterTrucked
{
    public class Hook : MonoBehaviour
    {
        private static Thread t_inj;
        private static AppDomain mainDomain = AppDomain.CurrentDomain;
        private static GameObject go_code = null;
        private static Controller ctrl = null;

        public static void hook()
        {
            try
            {
                Debug.Log("Attempting Hook...");
                t_inj = new Thread(new ThreadStart(inject));
                mainDomain.AssemblyLoad += new AssemblyLoadEventHandler(onASMLoaded);
                t_inj.Start();
                Debug.Log("Hook Successful!");
            }
            catch (Exception ex)
            {
                Debug.Log("Hook Failed!");
                Debug.LogException(ex);
            }
        }

        private static void inject()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    if (go_code == null || ctrl == null)
                    {
                        Debug.Log("Attempting Injection...");
                        go_code = new GameObject();
                        ctrl = go_code.AddComponent<Controller>();
                        DontDestroyOnLoad(go_code);
                        Debug.Log("Injection Successful!");
                    }
                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                Debug.Log("Injection Failed!");
                Debug.LogException(ex);
            }
        }

        private static void injectMethods()
        {
            MethodInfo[] miOrg = 
            {
                //typeof(player).GetMethod("Die", BindingFlags.Public | BindingFlags.Instance),
                typeof(GameManager).GetMethod("LoseLevel", BindingFlags.Public | BindingFlags.Instance),
            };

            MethodInfo[] miRep = 
            {
                //typeof(OV_Player).GetMethod("Die", BindingFlags.Public | BindingFlags.Instance),
                typeof(OV_GameManager).GetMethod("LoseLevel", BindingFlags.Public | BindingFlags.Instance),
            };

            for (int i = 0; i < miOrg.Length; i++)
            {
                RedirectionHelper.RedirectCalls(miOrg[i], miRep[i]);
            }
        }

        private static void onASMLoaded(object sender, AssemblyLoadEventArgs args)
        {
            Debug.Log("Loaded: " + args.LoadedAssembly.FullName);
            if (args.LoadedAssembly.FullName.ToLower().Contains("csharp") && !args.LoadedAssembly.FullName.ToLower().Contains("first"))
            {
                //injectMethods();
            }
        }
    }
}
