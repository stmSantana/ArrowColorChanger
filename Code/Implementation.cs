using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using MelonLoader;
using HarmonyLib;


namespace ChangeTextures
{
    internal class Implementation : MelonMod
    {

        public static bool changedac = false;

        public override void OnApplicationStart()
        {
            ///Settings.instance.AddToModSettings(BuildInfo.Name); 
            Settings.OnLoad();/// ModSettings

            LoggerInstance.Msg($"Version {BuildInfo.Version}");
        }


        ///public override void OnSceneWasInitialized(int level, string name)
        ///public override void OnGUI()
        public static void ChangeArrow()
        {

            if (!changedac) /// adding textures
            {
                Material   arrowMat;
                GameObject arrowGear;
                Material   acMat;
                GameObject acGear;

                byte colR = (byte)Settings.options.acR;
                byte colG = (byte)Settings.options.acG;
                byte colB = (byte)Settings.options.acB;
                byte colA = 255;

                ///for (int i = 0; i <  testGear.Count; i++)
                ///{
                    arrowGear = Resources.Load("GEAR_Arrow").TryCast<GameObject>();
                    acGear = Resources.Load("GEAR_ArrowCol").TryCast<GameObject>();
                    if (arrowGear == null) return;
                    if (acGear == null) return;

                    ///MelonLogger.Msg("Debug========================================D1====== " + changedac); 

                    arrowMat = new Material(Resources.Load("GEAR_Arrow").TryCast<GameObject>().transform.GetChild(0).GetComponent<MeshRenderer>().materials[0]);
                    acMat = new Material(Resources.Load("GEAR_ArrowCol").TryCast<GameObject>().transform.GetChild(0).GetComponent<MeshRenderer>().materials[0]);

                    ///arrowMat.name = ("GEAR_" + "Arrow" + "_mat"); /// mat /// name is not used
                    ///knifeMat.name = ("GEAR_" + "Knife" + "_Mat"); /// Mat /// name is not used

                    acMat.mainTexture = acGear.transform.GetChild(1).GetComponent<MeshRenderer>().materials[0].mainTexture; // child(1) is a white shaft texture.
                    arrowMat.mainTexture = arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].mainTexture;

                    ///arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].mainTexture = acMat.mainTexture;  // material is not changed.
                    ///arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = new Color32(255, 128, 64, 1);     // change material color
                    arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = new Color32(colR, colG, colB, colA); // change material color
                    
                    ///MelonLogger.Msg("Debug========================================D2====== ");

                ///}

                changedac = true;
                ///MelonLogger.Msg("Debug========================================D3====== " + changedac);

            }
        }

    }
    
    [HarmonyPatch(typeof(GameManager), "Update")]
    internal class GameManager_Update
    {
        private static void Postfix()
        {
            Implementation.ChangeArrow();
        }
    }
    
}
