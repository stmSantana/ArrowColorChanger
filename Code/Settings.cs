using ModSettings;
using UnityEngine;

namespace ChangeTextures
{
    internal class ACSettings : JsonModSettings
    {
        ///internal static Settings instance = new Settings();

        [Section("Arrow color settings")]

        [Name("Red")]
        [Description("0 to 255")]
        [Slider(0, 255)]
        public int acR = 255;

        [Name("Green")]
        [Description("0 to 255")]
        [Slider(0, 255)]
        public int acG = 0;

        [Name("Blue")]
        [Description("0 to 255")]
        [Slider(0, 255)]
        public int acB = 255;

        /// [Name("Alpha")]
        /// [Description("0 to 255")]
        /// [Slider(0, 255)]
        /// public int acA = 255;

        protected override void OnConfirm()
        {
            Debug.Log("AC Settings applied!");
            Implementation.changedac = false;
        }


    }
    internal static class Settings
    {
        public static ACSettings options = new ACSettings();
        public static void OnLoad()
        {
            options = new ACSettings();
            options.AddToModSettings("Change textures Settings");
        }
    }


}
