using UnityEngine;
using MelonLoader;

//using HarmonyLib;
//using System;
//using System.IO;
//using System.Linq;
//using System.Collections.Generic;
//using System.Reflection;
//using ModSettings;

namespace ArrowColorChanger
{
    internal class Implementation : MelonMod
    {

        public static bool changedac = false;

        public override void OnApplicationStart()
        {
            Settings.OnLoad();/// ModSettings
            LoggerInstance.Msg($"Version {BuildInfo.Version}");

        }

        public override void OnSceneWasInitialized(int level, string name)
        {
            ChangeArrow();
        }

        public static void ChangeArrow()
        {

            if (!changedac) /// adding textures
            {
                //MelonLogger.Msg("Debug Log ============================================== changedac = " + changedac);
                Material arrowMat;
                GameObject arrowGear;
                Material acMat;
                GameObject acGear;

                byte colR = (byte)Settings.options.acR;
                byte colG = (byte)Settings.options.acG;
                byte colB = (byte)Settings.options.acB;
                byte colA = 255;

                arrowGear = Resources.Load("GEAR_Arrow").TryCast<GameObject>();
                acGear = Resources.Load("GEAR_ArrowCol").TryCast<GameObject>();
                if (arrowGear == null) return;
                if (acGear == null) return;

                arrowMat = new Material(Resources.Load("GEAR_Arrow").TryCast<GameObject>().transform.GetChild(0).GetComponent<MeshRenderer>().materials[0]);
                acMat = new Material(Resources.Load("GEAR_ArrowCol").TryCast<GameObject>().transform.GetChild(0).GetComponent<MeshRenderer>().materials[0]);
                if (arrowMat == null) return;
                if (acMat == null) return;

                acMat.mainTexture = acGear.transform.GetChild(1).GetComponent<MeshRenderer>().materials[0].mainTexture; // child(1) is a white shaft texture.
                arrowMat.mainTexture = arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].mainTexture;
                arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = new Color32(colR, colG, colB, colA); // change material color

                changedac = true;
            }
        }

    }

    /*
  [HarmonyPatch(typeof(GameManager), "Update")]
  internal class GameManager_Update
  {
      private static void Postfix()
      {
          Implementation.ChangeArrow();
      }
  }
   */

}