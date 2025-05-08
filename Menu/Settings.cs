using StupidTemplate.Classes;
using StupidTemplate.Menu;
using UnityEngine;

namespace StupidTemplate
{
    internal class Settings
    {
        public static ExtGradient backgroundColor = new ExtGradient { isRainbow = false };
        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
            new ExtGradient { colors = Main.GetSolidGradient(new Color32(35,35,35,255))},//off
            new ExtGradient { colors = Main.GetSolidGradient(new Color32(138, 43, 226,255))} // on
        };
        public static Color[] textColors = new Color[]
        {
            Color.white, // Disabled
            Color.white // Enabled
        };

        public static Font currentFont = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);

        public static bool fpsCounter = false;
        public static bool disconnectButton = false;
        public static bool rightHanded = true;
        public static bool disableNotifications = true;

        public static KeyCode keyboardButton = KeyCode.Q;
        internal static int pageshit;
        public static int ButtonSound = 62;
        public static Vector3 menuSize = new Vector3(0.1f, 1f, 0.95f); // Depth, Width, Heightd
        public static int buttonsPerPage = 5;

        public static Vector3 PageButtonSize = new Vector3(0.09f, 0.9f, 0.13f); // Depth, Width, Heightd
        public static Vector3 ReturnPos = new Vector3(0.56f, 0, 0.55f);
        public static Vector3 ReturnSca = new Vector3(0.09f, 0.8f, 0.1f);
        public static Vector3 TextPos = new Vector3(0.06f, 0f, 0.155f);

        public static Vector3 ReturnTextPos = new Vector3(0.064f, 0, 0.21f);
        public static float buttonspace = 1.6f;

        public static float buttonspace2 = 0.1f;
        public static float textspace = 1.65f;

        public static Vector3 buttonpos = new Vector3(0.56f, 0f, 0.26f);
        public static Vector3 buttontpos = new Vector3(.064f, 0, .1045f);


        public static Vector3 NPpos = new Vector3(0.56f, -0.65f, 0);
        public static Vector3 NPsca = new Vector3(0.09f, 0.2f, 0.85f);
        public static Vector3 NPTpos = new Vector3(0.064f, -0.195f, 0f);

        public static Vector3 PPpos = new Vector3(0.56f, 0.65f, 0);
        public static Vector3 PPsca = new Vector3(0.09f, 0.2f, 0.85f);
        public static Vector3 PPTpos = new Vector3(0.064f, 0.195f, 0f);



        public static float fly = 6f;
        public static float Speed = 8f;
    }
}
