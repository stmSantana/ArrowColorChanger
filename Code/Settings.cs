using ModSettings;
using UnityEngine;
using MelonLoader;
//using System.Reflection;

namespace ArrowColorChanger
{
    internal class ACSettings : JsonModSettings
    {
        [Section("Arrow color settings")]

        [Name("Red")]
        [Description("0 to 255 , Please reload the save data to enable it.")]
        [Slider(0, 255)]
        public int acR = 200;

        [Name("Green")]
        [Description("0 to 255 , Please reload the save data to enable it.")]
        [Slider(0, 255)]
        public int acG = 180;

        [Name("Blue")]
        [Description("0 to 255 , Please reload the save data to enable it.")]
        [Slider(0, 255)]
        public int acB = 160;


        [Section("Arrow outline size")]

        [Name("Enable outline")]
        [Description("Outline around the arrow")]
        public bool acOF = true;

        [Name("Width")]
        [Description("1 to 10 (Default 0.3), Please reload the save data to enable it.")]
        [Slider(0f, 10f)]
        public float acOW = 0.3f;


        [Section("Arrow outline color settings")]

        [Name("Red")]
        [Description("0 to 255 , Please reload the save data to enable it.")]
        [Slider(0, 255)]
        public int acOR = 250;

        [Name("Green")]
        [Description("0 to 255 , Please reload the save data to enable it.")]
        [Slider(0, 255)]
        public int acOG = 250;

        [Name("Blue")]
        [Description("0 to 255 , Please reload the save data to enable it.")]
        [Slider(0, 255)]
        public int acOB = 10;

        ///[Name("Alpha")]
        ///[Description("0 to 255")]
        ///[Slider(0, 255)]
        ///public int acOA = 127;


        protected override void OnConfirm()
        {
            base.OnConfirm();
            
            Implementation.outlineflag = acOF;
            //MelonLogger.Msg("Debug Log ========================== OnConfirm acOF= " + acOF);
            
            Implementation.ChangeArrow();
            
            Debug.Log("AC Settings applied!");
        }

    }
    internal static class Settings
    {
        public static ACSettings options = new ACSettings();
        public static void OnLoad() 
        {
            options.AddToModSettings("Arrow Color Changer Settings", MenuType.Both);  // or MenuType.MainMenuOnly, or MenuType.Both
        }

    }

}