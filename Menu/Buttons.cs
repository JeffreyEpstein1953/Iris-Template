using StupidTemplate.Classes;
using StupidTemplate.Menu;
using StupidTemplate.Mods;
using UnityEngine;
using GorillaNetworking;
using Photon.Pun;
using IRIS.Mods;

namespace IRIS.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "settings", method =()=> Main.buttonsType=1, isTogglable=false },
                new ButtonInfo { buttonText = "computer", method =()=>Main.buttonsType=4, isTogglable = false},
                new ButtonInfo { buttonText = "player", method =()=>Main.buttonsType = 5, isTogglable = false},
                new ButtonInfo { buttonText = "rig", method =()=> Main.buttonsType = 6, isTogglable = false},
                new ButtonInfo { buttonText = "visuals", method =()=> Main.buttonsType = 7, isTogglable = false},
                new ButtonInfo { buttonText = "fun", method =()=>  Main.buttonsType = 8, isTogglable = false},
                new ButtonInfo { buttonText = "master", method=() => Main.buttonsType = 9, isTogglable = false},
                new ButtonInfo { buttonText = "op", method =()=> Main.buttonsType = 10, isTogglable = false},

            },

            new ButtonInfo[] { // settings
                new ButtonInfo { buttonText = "menu", method =() => Main.buttonsType = 2, isTogglable = false},
                new ButtonInfo { buttonText = "mods", method =() => Main.buttonsType = 3, isTogglable = false},
                new ButtonInfo { buttonText = "change menu layout", method = () => SettingsMods.menulayout(), isTogglable = false },

            },

            new ButtonInfo[] { // menu
                new ButtonInfo { buttonText = "change background color", method = () => SettingsMods.BGCOLOR(), isTogglable = false },
                new ButtonInfo { buttonText = "change button color", method = () => SettingsMods.BUTTONCOLOR(), isTogglable = false },
                new ButtonInfo { buttonText = "change text color", method = () => SettingsMods.TEXTCOLOR(), isTogglable = false },
                new ButtonInfo { buttonText = "change button sound", method = () => SettingsMods.ButtonSound(), isTogglable = false },
                new ButtonInfo { buttonText = "right hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand()},


                new ButtonInfo { buttonText = "⇣theme presets⇣", isTogglable = false },
                new ButtonInfo { buttonText = "base theme", method = () => SettingsMods.BaseT(), isTogglable = false },
                new ButtonInfo { buttonText = "intelect", method = () => SettingsMods.Inty(), isTogglable = false },
                new ButtonInfo { buttonText = "midnight", method = () => SettingsMods.T1(), isTogglable = false },
                new ButtonInfo { buttonText = "midnight v2", method = () => SettingsMods.T2(), isTogglable = false },
                new ButtonInfo { buttonText = "og outcast", method = () => SettingsMods.T3(), isTogglable = false },

                new ButtonInfo { buttonText = "monke mod menu", method = () => SettingsMods.T5(), isTogglable = false },
                new ButtonInfo { buttonText = "steal", method = () => SettingsMods.T4(), isTogglable = false },
            },

            new ButtonInfo[] { // mod



            },


            new ButtonInfo[] { // room
                new ButtonInfo { buttonText = "quit game", method = () => Application.Quit(), isTogglable = false },
                new ButtonInfo { buttonText = "disconenct", method = () => PhotonNetwork.Disconnect(), isTogglable = false },
                new ButtonInfo { buttonText = "disconenct [lp | backspace]", isTogglable = true, method =() => Global.LPD()},
                new ButtonInfo { buttonText = "join random", method = () => PhotonNetworkController.Instance.AttemptToJoinPublicRoom(GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Forest, Tree Exit").GetComponent<GorillaNetworkJoinTrigger>(), 0), isTogglable = false },
                new ButtonInfo { buttonText = "usw servers", method = () => PhotonNetwork.ConnectToRegion("usw"), isTogglable = false },
                new ButtonInfo { buttonText = "eu servers", method = () => PhotonNetwork.ConnectToRegion("eu"), isTogglable = false },
                new ButtonInfo { buttonText = "Gun 1", method = () => Global.Gun1(), isTogglable = true },
                new ButtonInfo { buttonText = "Gun 2", method = () => Global.Gun2(), isTogglable = true },

            },

            new ButtonInfo[] { // player

            },
            new ButtonInfo[] { // rig

            },
            new ButtonInfo[] { // visuals


            },

            new ButtonInfo[] { // fun

            },
            new ButtonInfo[] { // master


            },
            new ButtonInfo[] { // op


            },


            new ButtonInfo[] { // ignore
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
            },

        };
    }
}
