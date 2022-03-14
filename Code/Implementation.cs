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

        public static bool outlineflag = false;

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
            //MelonLogger.Msg("Debug Log ========================== ChangeArrow Start = " );

            GameObject arrowGear , acGear, abrkGear;
            Material arrowMat , acMat, abrkMat;
            Shader arrowSh, acSh;

            byte colR = (byte)Settings.options.acR;
            byte colG = (byte)Settings.options.acG;
            byte colB = (byte)Settings.options.acB;
            byte colA = 255;
            byte colOR = (byte)Settings.options.acOR;
            byte colOG = (byte)Settings.options.acOG;
            byte colOB = (byte)Settings.options.acOB;
            byte colOA = 255;
            float floOW = Settings.options.acOW /100; // meter to centimeter
            outlineflag = Settings.options.acOF;

            arrowGear = Resources.Load("GEAR_Arrow").TryCast<GameObject>();
            abrkGear = Resources.Load("GEAR_BrokenArrow").TryCast<GameObject>();
            acGear = Resources.Load("GEAR_0Cube1").TryCast<GameObject>();
            if (arrowGear == null) { MelonLogger.Msg("Debug Log ========================== NULL arrowGear = "); return; }
            if (abrkGear == null) { MelonLogger.Msg("Debug Log ========================== NULL abrkGear = "); return; }
            if (acGear == null) { MelonLogger.Msg("Debug Log ========================== NULL acGear = "); return; }

            arrowMat = new Material(Resources.Load("GEAR_Arrow").TryCast<GameObject>().transform.GetChild(0).GetComponent<MeshRenderer>().materials[0]);
            abrkMat = new Material(Resources.Load("GEAR_BrokenArrow").TryCast<GameObject>().GetComponent<MeshRenderer>().materials[0]);
            acMat = new Material(Resources.Load("GEAR_0Cube1").TryCast<GameObject>().GetComponent<MeshRenderer>().materials[0]);
            if (arrowMat == null) { MelonLogger.Msg("Debug Log ========================== NULL arrowMat = "); return; }
            if (abrkMat == null) { MelonLogger.Msg("Debug Log ========================== NULL abrkMat = "); return; }
            if (acMat == null) { MelonLogger.Msg("Debug Log ========================== NULL acMat = "); return; }

            arrowSh = arrowMat.shader;
            acSh = acMat.shader;
            if (arrowSh == null) { MelonLogger.Msg("Debug Log ========================== NULL arrowSh = "); return; }
            if (acSh == null) { MelonLogger.Msg("Debug Log ========================== NULL acSh = "); return; }

            arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().material = abrkMat; // Initialization arrow material to BROKEN ARROW
            arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = new Color32(colR, colG, colB, colA); // change material color
            //arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0] = abrkMat; //  change material ( material == materials[0] )
            //arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = new Color32(colR, colG, colB, colA); 

            if (outlineflag) 
            {
                //MelonLogger.Msg("Debug Log ========================== if (outlineflag) Start= ");

                //arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().material = acMat; // change material
                ///// arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0] = acMat; // change material

                arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().material.shader = acSh; // change shader
                ///// arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].shader = acSh; // change shader
                
                Color olc = new Color32(colOR, colOG, colOB, colOA); // outline color
                arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_OutlineColor", olc); // change shader outline color
                arrowGear.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_OutlineWidth", floOW); // change shader outline width
                
                //MelonLogger.Msg("Debug Log ========================== if (outlineflag) End = ");
            }
                
            //MelonLogger.Msg("Debug Log ========================== ChangeArrow End ===== ");
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