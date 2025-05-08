using GunLib;
using StupidTemplate;
using StupidTemplate.Classes;
using StupidTemplate.Menu;
using UnityEngine;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace IRIS.Mods
{
    internal class SettingsMods
    {
        public static void EnterSettings()
        {
            buttonsType = 1;
            pageNumber = 0;

        }

        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void EnableFPSCounter()
        {
            fpsCounter = true;
        }

        public static void DisableFPSCounter()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = true;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = false;
        }

        public static void BGCOLOR()
        {
            string[] themes = { "black", "red", "magenta", "orange", "yellow", "green", "blue", "cyan", "purple", "white", "grey" };

            if (themes.Length == 0) return;

            Settings.pageshit++;
            if (Settings.pageshit > themes.Length)
            {
                Settings.pageshit = 1;
            }

            switch (Settings.pageshit)
            {
                case 1:
                    backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.black) };
                    break;

                case 2:
                    backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.red) };
                    break;

                case 3:
                    backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.magenta) };
                    break;

                case 4:
                    backgroundColor = new ExtGradient { colors = GetSolidGradient(new Color32(255, 140, 0, 255)) };
                    break;

                case 5:
                    backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.yellow) };
                    break;

                case 6:
                    backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.green) };
                    break;

                case 7:
                    backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.blue) };
                    break;

                case 8:
                    backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.cyan) };

                    break;

                case 9:
                    backgroundColor = new ExtGradient { colors = GetSolidGradient(new Color32(43, 8, 109, 255)) };

                    break;


                case 10:
                    backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.white) };

                    break;

                case 11:
                    backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.gray) };

                    break;

            }
            GetIndex("change background color").overlapText = "background color: " + themes[Settings.pageshit - 1];
        }
        public static void BUTTONCOLOR()
        {
            string[] themes = { "black", "red", "magenta", "orange", "yellow", "green", "blue", "cyan", "purple", "white", "grey" };

            if (themes.Length == 0) return;

            Settings.pageshit++;
            if (Settings.pageshit > themes.Length)
            {
                Settings.pageshit = 1;
            }

            switch (Settings.pageshit)
            {
                case 1:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.black) },
                    new ExtGradient { colors = GetSolidGradient(Color.grey) }
                    };
                    GunTemplate.PointerColor = Color.black;
                    GunTemplate.TriggeredPointerColor = Color.grey;
                    break;

                case 2:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.red) },
                    new ExtGradient { colors = GetSolidGradient(Color.green) }
                    };
                    GunTemplate.PointerColor = Color.red;
                    GunTemplate.TriggeredPointerColor = Color.green;
                    break;

                case 3:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.magenta) },
                    new ExtGradient { colors = GetSolidGradient(Color.red) }
                    };
                    GunTemplate.PointerColor = Color.magenta;
                    GunTemplate.TriggeredPointerColor = Color.red;
                    break;

                case 4:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(new Color32(255, 140, 0,255)) },
                    new ExtGradient { colors = GetSolidGradient(Color.blue) }
                    };
                    GunTemplate.PointerColor = new Color32(255, 140, 0, 255);
                    GunTemplate.TriggeredPointerColor = Color.blue;
                    break;

                case 5:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.yellow) },
                    new ExtGradient { colors = GetSolidGradient(Color.red) }
                    };
                    GunTemplate.PointerColor = Color.yellow;
                    GunTemplate.TriggeredPointerColor = Color.red;
                    break;

                case 6:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.green) },
                    new ExtGradient { colors = GetSolidGradient(Color.blue) }
                    };
                    GunTemplate.PointerColor = Color.green;
                    GunTemplate.TriggeredPointerColor = Color.blue;
                    break;

                case 7:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.blue) },
                    new ExtGradient { colors = GetSolidGradient(new Color32(255, 140, 0,255)) }
                    };
                    GunTemplate.PointerColor = Color.blue;
                    GunTemplate.TriggeredPointerColor = new Color32(255, 140, 0, 255);
                    break;

                case 8:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.cyan) },
                    new ExtGradient { colors = GetSolidGradient(Color.red) }
                    };

                    GunTemplate.PointerColor = Color.cyan;
                    GunTemplate.TriggeredPointerColor = Color.red;
                    break;

                case 9:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(new Color32(43,8,109,255)) },
                    new ExtGradient { colors = GetSolidGradient(new Color32(63,15,158,255)) }
                    };

                    GunTemplate.PointerColor = new Color32(43, 8, 109, 255);
                    GunTemplate.TriggeredPointerColor = new Color32(63, 15, 158, 255);
                break;



                case 10:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.white) },
                    new ExtGradient { colors = GetSolidGradient(Color.grey) }
                    };
                    GunTemplate.PointerColor = Color.white;
                    GunTemplate.TriggeredPointerColor = Color.grey;
                    break;

                case 11:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.grey) },
                    new ExtGradient { colors = GetSolidGradient(Color.white) }

                    };
                    GunTemplate.PointerColor = Color.grey;
                    GunTemplate.TriggeredPointerColor = Color.white;

                    break;

            }
            GetIndex("change button color").overlapText = "button color: " + themes[Settings.pageshit - 1];
        }

        public static void TEXTCOLOR()
        {
            string[] themes = { "black", "white", "grey" };

            if (themes.Length == 0) return;

            Settings.pageshit++;
            if (Settings.pageshit > themes.Length)
            {
                Settings.pageshit = 1;
            }

            switch (Settings.pageshit)
            {
                case 1:
                    textColors = new Color[] { Color.black, Color.black };
                    break;

                case 2:
                    textColors = new Color[] { Color.white, Color.white };
                    break;

                case 3:
                    textColors = new Color[] { Color.grey, Color.grey };
                    break;
            }
            GetIndex("change text color").overlapText = "text color: " + themes[Settings.pageshit - 1];
        }


        public static void ButtonSound()
        {
            string[] themes = { "pillow", "crystal", "inner cauldron", "elf release", "big bongo", "snow step", "normal" };

            if (themes.Length == 0) return;

            Settings.pageshit++;
            if (Settings.pageshit > themes.Length)
            {
                Settings.pageshit = 1;
            }

            switch (Settings.pageshit)
            {
                case 1:
                    Settings.ButtonSound = 109;
                    break;

                case 2:
                    Settings.ButtonSound = 22;
                    break;

                case 3:
                    Settings.ButtonSound = 79;
                    break;

                case 4:
                    Settings.ButtonSound = 141;
                    break;

                case 5:
                    Settings.ButtonSound = 73;
                    break;

                case 6:
                    Settings.ButtonSound = 147;
                    break;

                case 7:
                    Settings.ButtonSound = 62;
                    break;

            }
            GetIndex("Change Button Sound").overlapText = "Change Button Sound: " + themes[Settings.pageshit - 1];
        }











        public static void BaseT()
        {
            backgroundColor = new ExtGradient { colors = GetSolidGradient(new Color32(15, 15, 15, 255)) };
            buttonColors = new ExtGradient[]
            {
            new ExtGradient { colors = Main.GetSolidGradient(new Color32(35,35,35,255))},//off
            new ExtGradient { colors = Main.GetSolidGradient(new Color32(138, 43, 226,255))} // on
            };
            textColors = new Color[] { Color.white, Color.white };
            GunTemplate.PointerColor = new Color32(35, 35, 35, 255);
            GunTemplate.TriggeredPointerColor = new Color32(138, 43, 226, 255);
        }

        public static void Inty()
        {
            backgroundColor = new ExtGradient { colors = GetSolidGradient(new Color32(162, 131, 255, 255)) };
            buttonColors = new ExtGradient[]
            {
            new ExtGradient{colors = GetSolidGradient(Color.black) },
            new ExtGradient{colors = GetSolidGradient(Color.white) }
            };
            textColors = new Color[] { Color.white, Color.black };
            GunTemplate.PointerColor = Color.black;
            GunTemplate.TriggeredPointerColor = Color.white;
        }
        public static void T1()
        {
            backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.black) };
            buttonColors = new ExtGradient[]
            {
                    new ExtGradient { colors = GetSolidGradient(Color.yellow) },
                    new ExtGradient { colors = GetSolidGradient(Color.red) }
            };
            textColors = new Color[] { Color.white, Color.white };
            GunTemplate.PointerColor = Color.yellow;
            GunTemplate.TriggeredPointerColor = Color.red;
        }
        public static void T2()
        {
            backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.black) };
            buttonColors = new ExtGradient[]
            {
                    new ExtGradient { colors = GetSolidGradient(new Color32(43,8,109,255)) },
                    new ExtGradient { colors = GetSolidGradient(Color.magenta) }
            };
            textColors = new Color[] { Color.white, Color.white };
            GunTemplate.PointerColor = new Color32(43, 8, 109, 255);
            GunTemplate.TriggeredPointerColor = Color.magenta;
        }
        public static void T3()
        {
            backgroundColor = new ExtGradient { colors = GetSolidGradient(new Color32(98, 49, 165, 255)) };
            buttonColors = new ExtGradient[]
            {
                    new ExtGradient { colors = GetSolidGradient(new Color32(144,86,230,255)) },
                    new ExtGradient { colors = GetSolidGradient(new Color32(144,86,230,255)) }
            };
            textColors = new Color[] { Color.white, Color.green };
            GunTemplate.PointerColor = new Color32(144, 86, 230, 255);
            GunTemplate.TriggeredPointerColor = Color.green;
        }
        public static void T4()
        {
            backgroundColor = new ExtGradient { colors = GetSolidGradient(new Color32(43, 8, 109, 255)) };
            buttonColors = new ExtGradient[]
            {
                    new ExtGradient { colors = GetSolidGradient(new Color32(63,15,158,255)) },
                    new ExtGradient { colors = GetSolidGradient(new Color32(63,15,158,255)) }
            };
            textColors = new Color[] { Color.white, Color.green };
            GunTemplate.PointerColor = new Color32(63, 15, 158, 255);
            GunTemplate.TriggeredPointerColor = Color.green;
        }
        public static void T5()
        {
            backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.black) };
            buttonColors = new ExtGradient[]
            {
                    new ExtGradient { colors = GetSolidGradient(Color.red) },
                    new ExtGradient { colors = GetSolidGradient(Color.green) }
            };
            textColors = new Color[] { Color.white, Color.white };
            GunTemplate.PointerColor = Color.red;
            GunTemplate.TriggeredPointerColor = Color.green;
        }



      

        public static void BUTTONCOLOR1()
        {
            string[] themes = { "purple", "orange", "yellow", "blue", "cyan", "green", "normal" };

            if (themes.Length == 0) return;

            Settings.pageshit++;
            if (Settings.pageshit > themes.Length)
            {
                Settings.pageshit = 1;
            }

            switch (Settings.pageshit)
            {

                case 1:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(new Color32(43,8,109,255))},
                    new ExtGradient { colors = GetSolidGradient(Color.green) }

                    };


                    GunTemplate.PointerColor = new Color32(43, 8, 109, 255);

                    GunTemplate.TriggeredPointerColor = Color.green;
                    break;

                case 2:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(new Color32(255, 140, 0,255))},
                    new ExtGradient { colors = GetSolidGradient(Color.blue)}
                    };


                    GunTemplate.PointerColor = new Color32(255, 140, 0, 255);

                    GunTemplate.TriggeredPointerColor = Color.blue;
                    break;
                case 3:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.yellow)},
                    new ExtGradient { colors = GetSolidGradient(Color.red)}
                    };


                    GunTemplate.PointerColor = Color.yellow;

                    GunTemplate.TriggeredPointerColor = Color.red;
                    break;
                case 4:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.blue)},
                    new ExtGradient { colors = GetSolidGradient(Color.green)}
                    };


                    GunTemplate.PointerColor = Color.blue;

                    GunTemplate.TriggeredPointerColor = Color.green;
                    break;
                case 5:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.cyan)},
                    new ExtGradient { colors = GetSolidGradient(Color.red)}
                    };


                    GunTemplate.PointerColor = Color.cyan;

                    GunTemplate.TriggeredPointerColor = Color.red;
                    break;
                case 6:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetSolidGradient(Color.green)},
                    new ExtGradient { colors = GetSolidGradient(Color.blue)}
                    };


                    GunTemplate.PointerColor = Color.green;

                    GunTemplate.TriggeredPointerColor = Color.blue;
                    break;
                case 7:
                    buttonColors = new ExtGradient[]
                    {
                    new ExtGradient{colors = GetSolidGradient(new Color32(211,25,0,255))},
                    new ExtGradient{colors = GetSolidGradient(Color.green)}
                    };


                    GunTemplate.PointerColor = new Color32(211, 25, 0, 255);
                    GunTemplate.TriggeredPointerColor = Color.green;
                    break;

            }
        }


        public static void menulayout()
        {
            string[] slavesonsale = { "Morphine", "Mango", "Symex", "NXO", "NXO Wide", "Solace","Steal" };

            if (slavesonsale.Length == 0) return;

            Settings.pageshit++;
            if (Settings.pageshit > slavesonsale.Length)
            {
                Settings.pageshit = 1;
            }

            switch (Settings.pageshit)
            {
                case 1:
                    Settings.buttonsPerPage = 7;
                    Settings.menuSize = new Vector3(0.1f, 0.95f, 1.025f);
                    Settings.ReturnPos = new Vector3(0.56f, 0, -0.52f);
                    Settings.ReturnTextPos = new Vector3(0.064f, 0, -0.195f);
                    buttontpos = new Vector3(.064f, 0, .08f);
                    buttonpos = new Vector3(0.56f, 0f, 0.212f);
                    PageButtonSize = new Vector3(0.09f, 0.825f, 0.09f);
                    textspace = 2.7f;
                    buttonspace = 1f;
                    TextPos = new Vector3(0.06f, 0f, 0.165f);
                    NPpos = new Vector3(0.56f, -0.208f, 0.3112f);
                    NPsca = new Vector3(0.09f, 0.410f, 0.09f);
                    NPTpos = new Vector3(0.064f, -0.06f, 0.116f);

                    PPpos = new Vector3(0.56f, 0.208f, 0.3112f);
                    PPsca = new Vector3(0.09f, 0.410f, 0.09f);
                    PPTpos = new Vector3(0.064f, 0.06f, 0.116f);
                    buttonspace2 = 0.098f;
                    ReturnSca = new Vector3(0.09f, 0.8f, 0.1f);
                    break;
                case 2:
                    Settings.buttonsPerPage = 4;
                    Settings.menuSize = new Vector3(0.1f, 1f, 1f);
                    Settings.ReturnPos = new Vector3(0.56f, 0, 0.60f);
                    Settings.ReturnTextPos = new Vector3(0.064f, 0, 0.23f);
                    buttontpos = new Vector3(.064f, 0, .02f);
                    buttonpos = new Vector3(0.56f, 0f, 0.048f);
                    PageButtonSize = new Vector3(0.09f, 0.85f, 0.09f);
                    textspace = 2f;
                    buttonspace = 1.35f;
                    TextPos = new Vector3(0.06f, 0f, 0.165f);
                    NPpos = new Vector3(0.56f, 0, 0.175f);
                    NPsca = new Vector3(0.09f, 0.85f, 0.09f);
                    NPTpos = new Vector3(0.064f, 0, 0.067f);

                    PPpos = new Vector3(0.56f, 0, 0.31f);
                    PPsca = new Vector3(0.09f, 0.85f, 0.09f);
                    PPTpos = new Vector3(0.064f, 0, 0.117f);
                    buttonspace2 = 0.1f;
                    ReturnSca = new Vector3(0.09f, 0.8f, 0.1f);
                    break;
                case 3:
                    Settings.buttonsPerPage = 7;
                    Settings.menuSize = new Vector3(0.1f, 1f, 1f);
                    Settings.ReturnPos = new Vector3(0.56f, 0, -0.38f);
                    Settings.ReturnTextPos = new Vector3(0.054f, 0, -0.14f);
                    buttontpos = new Vector3(.064f, 0, .115f);
                    buttonpos = new Vector3(0.56f, 0f, 0.3f);
                    PageButtonSize = new Vector3(0.09f, 0.8f, 0.085f);
                    textspace = 2.8f;
                    buttonspace = 0.95f;
                    TextPos = new Vector3(0.06f, 0f, 0.165f);
                    NPpos = new Vector3(0.56f, -0.28f, -0.38f);
                    NPsca = new Vector3(0.09f, 0.3f, 0.08f);
                    NPTpos = new Vector3(0.064f, -0.085f, -0.145f);

                    PPpos = new Vector3(0.56f, 0.28f, -0.38f);
                    PPsca = new Vector3(0.09f, 0.3f, 0.08f);
                    PPTpos = new Vector3(0.064f, 0.085f, -0.145f);
                    buttonspace2 = 0.1f;
                    ReturnSca = new Vector3(0.09f, 0.15f, 0.1f);
                    break;
                    case 4:

                    Settings.buttonsPerPage = 7;
                    Settings.menuSize = new Vector3(0.1f, 0.85f, 0.94f);
                    Settings.ReturnPos = new Vector3(0.56f, 0, -0.38f);
                    Settings.ReturnTextPos = new Vector3(0.054f, 0, -0.14f);
                    buttontpos = new Vector3(.064f, 0, .11f);
                    buttonpos = new Vector3(0.56f, 0f, 0.285f);
                    PageButtonSize = new Vector3(0.09f, 0.7f, 0.08f);
                    textspace = 2.8f;
                    buttonspace = 0.95f;
                    TextPos = new Vector3(0.06f, 0f, 0.155f);
                    NPpos = new Vector3(0.56f, -0.225f, -0.38f);
                    NPsca = new Vector3(0.09f, 0.25f, 0.08f);
                    NPTpos = new Vector3(0.064f, -0.065f, -0.145f);

                    PPpos = new Vector3(0.56f, 0.225f, -0.38f);
                    PPsca = new Vector3(0.09f, 0.25f, 0.08f);
                    PPTpos = new Vector3(0.064f, 0.065f, -0.145f);
                    buttonspace2 = 0.1f;
                    ReturnSca = new Vector3(0.09f, 0.185f, 0.08f);

                    break;
                    case 5:

                    Settings.buttonsPerPage = 7;
                    Settings.menuSize = new Vector3(0.1f, 1.05f, 0.94f);
                    Settings.ReturnPos = new Vector3(0.56f, 0, -0.38f);
                    Settings.ReturnTextPos = new Vector3(0.054f, 0, -0.14f);
                    buttontpos = new Vector3(.064f, 0, .11f);
                    buttonpos = new Vector3(0.56f, 0f, 0.285f);
                    PageButtonSize = new Vector3(0.09f, 0.9f, 0.08f);
                    textspace = 2.8f;
                    buttonspace = 0.95f;
                    TextPos = new Vector3(0.06f, 0f, 0.155f);

                    NPpos = new Vector3(0.56f, -0.3f, -0.38f);
                    NPsca = new Vector3(0.09f, 0.3f, 0.08f);
                    NPTpos = new Vector3(0.064f, -0.085f, -0.145f);

                    PPpos = new Vector3(0.56f, 0.3f, -0.38f);
                    PPsca = new Vector3(0.09f, 0.3f, 0.08f);
                    PPTpos = new Vector3(0.064f, 0.085f, -0.145f);
                    buttonspace2 = 0.1f;
                    ReturnSca = new Vector3(0.09f, 0.28f, 0.08f);

                    break;
                    case 6:
                    Settings.buttonsPerPage = 8;
                    Settings.menuSize = new Vector3(0.1f, 0.9f, 0.85f);
                    Settings.ReturnPos = new Vector3(0.5f, 0, -0.48f);
                    Settings.ReturnTextPos = new Vector3(0.064f, 0, -0.18f);
                    buttontpos = new Vector3(.064f, 0, .13f);
                    buttonpos = new Vector3(0.56f, 0f, 0.34f);
                    PageButtonSize = new Vector3(0.09f, 0.78f, 0.08f);
                    textspace = 2.8f;
                    buttonspace = 0.95f;
                    TextPos = new Vector3(0.05f, 0f, 0.13f);
                    NPpos = new Vector3(0.5f, -0.375f, -0.48f);
                    NPsca = new Vector3(0.09f, 0.15f, 0.1f);
                    NPTpos = new Vector3(0.064f, -0.112f, -0.18f);

                    PPpos = new Vector3(0.5f, 0.375f, -0.48f);
                    PPsca = new Vector3(0.09f, 0.15f, 0.1f);
                    PPTpos = new Vector3(0.06f, 0.112f, -0.18f);
                    buttonspace2 = 0.1f;
                    ReturnSca = new Vector3(0.09f, 0.48f, 0.1f);
                    break;

                case 7:
                    Settings.buttonsPerPage = 5;
                    Settings.menuSize = new Vector3(0.1f, 1f, 0.95f);
                    Settings.ReturnPos = new Vector3(0.56f, 0, 0.55f);
                    Settings.ReturnTextPos = new Vector3(0.064f, 0, 0.21f);
                    buttontpos = new Vector3(.064f, 0, .1045f);
                    buttonpos = new Vector3(0.56f, 0f, 0.26f);
                    textspace = 1.65f;
                    buttonspace = 1.6f;
                    PageButtonSize = new Vector3(0.09f, 0.9f, 0.13f);
                    NPpos = new Vector3(0.56f, -0.65f, 0);
                    NPsca = new Vector3(0.09f, 0.2f, 0.85f);
                    NPTpos = new Vector3(0.064f, -0.195f, 0f);
                    TextPos = new Vector3(0.06f, 0f, 0.155f);

                    PPpos = new Vector3(0.56f, 0.65f, 0);
                    PPsca = new Vector3(0.09f, 0.2f, 0.85f);
                    PPTpos = new Vector3(0.064f, 0.195f, 0f);
                    buttonspace2 = 0.1f;
                    ReturnSca = new Vector3(0.09f, 0.8f, 0.1f);
                    break;

            }

        }
    }
}
