using BepInEx;
using GunLib;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    internal class Global
    {
        public static void ReturnHome()
        {
            buttonsType = 0;
            pageNumber = 0;
        }
        public static void LPD()
        {
            if (ControllerInputPoller.instance.leftControllerPrimaryButton || UnityInput.Current.GetKey(KeyCode.Backspace))
            {
                PhotonNetwork.Disconnect();
            }
        }

        //how to use gunlib
        public static void Gun1()
        {
            //no need to hold any button because gun always shows on vr, hold rmb to show gun on pc
            GunTemplate.StartBothGuns(() =>
            {


            }, true); //True for locking on, false for no lock on
        }

        public static void Gun2()
        {
            if (!ControllerInputPoller.instance.rightGrab && !Mouse.current.rightButton.isPressed) return; //requires rg or rmb to be pressed to show gun

            GunTemplate.StartBothGuns(() =>
            {

            }, true); //True for locking on, false for no lock on
        }

    }
}
