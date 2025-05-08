using IRIS.Menu;
using BepInEx;
using GorillaNetworking;
using HarmonyLib;
using Photon.Pun;
using StupidTemplate.Classes;
using StupidTemplate.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static IRIS.Menu.Buttons;
using static StupidTemplate.Settings;

namespace StupidTemplate.Menu
{
    [HarmonyPatch(typeof(GorillaLocomotion.GTPlayer))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    public class Main : MonoBehaviour
    {
        public static Material Hello = new Material(Shader.Find("GorillaTag/UberShader"));
        public static Material M1 = null; 
        public static Material M2 = null;


        public static void Prefix()
        {
            // Initialize Menu
            try
            {
                bool toOpen = (!rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton) || (rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton);
                bool keyboardOpen = UnityInput.Current.GetKey(keyboardButton);

                if (menu == null)
                {
                    if (toOpen || keyboardOpen)
                    {
                        CreateMenu();
                        RecenterMenu(rightHanded, keyboardOpen);
                        if (reference == null)
                        {
                            CreateReference(rightHanded);
                        }
                    }
                }
                else
                {
                    if ((toOpen || keyboardOpen))
                    {
                        RecenterMenu(rightHanded, keyboardOpen);
                    }
                    else
                    {
                        GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(true);

                        Rigidbody comp = menu.AddComponent(typeof(Rigidbody)) as Rigidbody;
                        if (rightHanded)
                        {
                            comp.velocity = GorillaLocomotion.GTPlayer.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                        }
                        else
                        {
                            comp.velocity = GorillaLocomotion.GTPlayer.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                        }

                        UnityEngine.Object.Destroy(menu, 0);
                        menu = null;

                        UnityEngine.Object.Destroy(reference);
                        reference = null;
                    }
                }
            }
            catch (Exception exc)
            {
                UnityEngine.Debug.LogError(string.Format("{0} // Error initializing at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }

            // Constant
            try
            {
                // Pre-Execution
                if (fpsObject != null)
                {
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                }

                // Execute Enabled mods
                foreach (ButtonInfo[] buttonlist in buttons)
                {
                    foreach (ButtonInfo v in buttonlist)
                    {
                        if (v.enabled)
                        {
                            if (v.method != null)
                            {
                                try
                                {
                                    v.method.Invoke();
                                }
                                catch (Exception exc)
                                {
                                    UnityEngine.Debug.LogError(string.Format("{0} // Error with mod {1} at {2}: {3}", PluginInfo.Name, v.buttonText, exc.StackTrace, exc.Message));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                UnityEngine.Debug.LogError(string.Format("{0} // Error with executing mods at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }
            try
            {
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motd (1)").GetComponent<TextMeshPro>().text = "Iris.wtf Template";
                TextMeshPro textMeshPro = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdtext").GetComponent<TextMeshPro>();
                textMeshPro.text = "<color=#ff00ff>DEVELOPERS NOTICE</color>\n\nTHE OWNERS/DEVELOPERS OF THIS MENU ARE NOT RESPONSIBLE FOR ANY BANS CAUSED BY THIS MENU. CERTAIN FEATURES WILL NOT STAY UNDETECTED FOREVER.\n\n\n<color=#ff0000>USE AT YOUR OWN RISK IF THE GAME HAS RECENTLY UPDATED</color>";
                //textMeshPro.alignment = TextAlignmentOptions.Top;

                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/CodeOfConduct").GetComponent<TextMeshPro>().text = "ROOM INFO";
                TextMeshPro textMeshPro2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/COC Text").GetComponent<TextMeshPro>();
                if (PhotonNetwork.InRoom)
                {
                    string roomName = PhotonNetwork.CurrentRoom.Name.ToUpper();
                    string playerCount = PhotonNetwork.CurrentRoom.PlayerCount.ToString().ToUpper();
                    string maxPlayers = PhotonNetwork.CurrentRoom.MaxPlayers.ToString().ToUpper();
                    string ping = PhotonNetwork.GetPing().ToString().ToUpper();
                    string isMaster = PhotonNetwork.IsMasterClient ? "YES" : "NO";
                    string masterClient = PhotonNetwork.MasterClient.NickName.ToUpper();
                    textMeshPro2.text = $"\nIN ROOM: {roomName}\nPLAYERS: {playerCount}/{maxPlayers}\n" + $"PING: {ping}ms\nAM I MASTER CLIENT?: {isMaster}\nMASTER CLIENT: {masterClient}\n\nDEVELOPERS:\nOUTCAST\nFLYINGUNDERTHERADAR";
                }
                else
                {
                    textMeshPro2.text = "\nNOT CONNECTED TO A ROOM\n\nDEVELOPERS:\nFLYINGUNDERTHERADAR\nOUTCAST\nCHA554";
                }
                //textMeshPro2.text = "[+] EVERYTHING\n[-] REMOVED BITCOIN MINER";
                textMeshPro2.alignment = TextAlignmentOptions.Top;

                GameObject monitorScreen = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/monitor/monitorScreen");
                if (monitorScreen != null)
                {
                    Renderer renderer = monitorScreen.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = Hello;
                        renderer.material.color = new Color32(144, 86, 230, 255);
                    }
                }
                GameObject Forest = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomBoundaryStones/BoundaryStoneSet_Forest/wallmonitorforestbg");
                if (Forest != null)
                {
                    Renderer renderer = Forest.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = Hello;
                        renderer.material.color = new Color32(144, 86, 230, 255);
                    }
                }

                GameObject Keyboard = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)");
                if (Keyboard != null)
                {
                    Renderer renderer = Keyboard.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = Hello;
                        renderer.material.color = new Color32(144, 86, 230, 255);
                    }
                }
                GameObject City = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomBoundaryStones/BoundaryStoneSet_City/Wallmonitor_Small_Prefab/wallmonitorscreen_small");
                if (City != null)
                {
                    Renderer renderer = City.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = Hello;
                        renderer.material.color = new Color32(144, 86, 230, 255);
                    }
                }
                GameObject Nigg = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/campgroundstructure/scoreboard/REMOVE board");
                if (Nigg != null)
                {
                    Renderer renderer = Nigg.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = Hello;
                        renderer.material.color = new Color32(144, 86, 230, 255);
                    }
                }
            }
            catch
            {
            }
            try
            {
                foreach (ButtonInfo[] btninfo in Buttons.buttons)
                {
                    foreach (ButtonInfo info in btninfo)
                    {

                    }
                }
            }
            catch
            {
            }
        }

        // Functions
        public static void CreateMenu()
        {
            // Menu Holder
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
            menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);

            // Menu Background
            menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(menuBackground.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(menuBackground.GetComponent<BoxCollider>());
            menuBackground.transform.parent = menu.transform;
            menuBackground.transform.rotation = Quaternion.identity;
            menuBackground.transform.localScale = menuSize;
            menuBackground.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
            menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);
            menuBackground.GetComponent<Renderer>().material.color = new Color(0.447f, 0.447f, 0.804f);

            ColorChanger colorChanger = menuBackground.AddComponent<ColorChanger>();
            colorChanger.colorInfo = backgroundColor;
            colorChanger.Start();

            // Canvas
            canvasObject = new GameObject();
            canvasObject.transform.parent = menu.transform;
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 1000f;

            // Title and FPS
            Text text = new GameObject
            {
                transform =
            {
            parent = canvasObject.transform
            }
            }.AddComponent<Text>();
            text.font = currentFont;
            if (buttonsType > 0)
            {
                text.text = PluginInfo.Name + " / " + (pageNumber).ToString();
            }
            else
            {
                text.text = PluginInfo.Name;

            }//text.text = PluginInfo.Name;            text.fontSize = 1;
            text.color = textColors[0];
            text.supportRichText = true;
            text.fontStyle = FontStyle.Normal;//BoldAndItalic;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.28f, 0.05f);
            component.position = TextPos;
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            if (fpsCounter)
            {
                fpsObject = new GameObject
                {
                    transform =
            {
                parent = canvasObject.transform
            }
                }.AddComponent<Text>();
                fpsObject.font = currentFont;
                fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                fpsObject.color = textColors[0];
                fpsObject.fontSize = 1;
                fpsObject.supportRichText = true;
                fpsObject.fontStyle = FontStyle.Normal;
                fpsObject.alignment = TextAnchor.MiddleCenter;
                fpsObject.horizontalOverflow = UnityEngine.HorizontalWrapMode.Overflow;
                fpsObject.resizeTextForBestFit = true;
                fpsObject.resizeTextMinSize = 0;
                RectTransform component2 = fpsObject.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.28f, 0.02f);
                component2.position = new Vector3(0.06f, 0f, 0.135f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }


            if (Main.buttonsType >= 1 && Main.buttonsType <= 10)
            {
                GameObject disconnectbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    disconnectbutton.layer = 2;
                }
                UnityEngine.Object.Destroy(disconnectbutton.GetComponent<Rigidbody>());
                disconnectbutton.GetComponent<BoxCollider>().isTrigger = true;
                disconnectbutton.transform.parent = menu.transform;
                disconnectbutton.transform.rotation = Quaternion.identity;
                disconnectbutton.transform.localScale = ReturnSca;
                disconnectbutton.transform.localPosition = ReturnPos;
                disconnectbutton.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                disconnectbutton.AddComponent<Classes.Button>().relatedText = "Return to Main";

                colorChanger = disconnectbutton.AddComponent<ColorChanger>();
                colorChanger.colorInfo = buttonColors[0]; //backgroundColor;
                colorChanger.Start();

                Text discontext = new GameObject
                {
                    transform =
                            {
                                parent = canvasObject.transform
                            }
                }.AddComponent<Text>();
                discontext.text = "home";
                discontext.font = currentFont;
                discontext.fontSize = 1;
                discontext.color = textColors[0];
                discontext.alignment = TextAnchor.MiddleCenter;
                discontext.resizeTextForBestFit = true;
                discontext.resizeTextMinSize = 0;

                RectTransform rectt = discontext.GetComponent<RectTransform>();
                rectt.localPosition = Vector3.zero;
                rectt.sizeDelta = new Vector2(0.2f, 0.03f);
                rectt.localPosition = ReturnTextPos;
                rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }

           
                GameObject prevButton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    prevButton.layer = 2;
                }
                UnityEngine.Object.Destroy(prevButton.GetComponent<Rigidbody>());
                prevButton.GetComponent<BoxCollider>().isTrigger = true;
                prevButton.transform.parent = menu.transform;
                prevButton.transform.rotation = Quaternion.identity;
                prevButton.transform.localScale = PPsca;
                prevButton.transform.localPosition = PPpos;
                prevButton.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                prevButton.AddComponent<Classes.Button>().relatedText = "PreviousPage";

                colorChanger = prevButton.AddComponent<ColorChanger>();
                colorChanger.colorInfo = buttonColors[0];//backgroundColor;
                colorChanger.Start();

                text = new GameObject
                {
                    transform =
                {
                parent = canvasObject.transform
                }
                }.AddComponent<Text>();
                text.font = currentFont;
                text.text = "⇠";
                text.fontSize = 1;
                text.color = textColors[0];
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                text.resizeTextMinSize = 0;
                component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.2f, 0.03f);
                component.localPosition = PPTpos;
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            


            GameObject nextButton = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                nextButton.layer = 2;
            }
            UnityEngine.Object.Destroy(nextButton.GetComponent<Rigidbody>());
            nextButton.GetComponent<BoxCollider>().isTrigger = true;
            nextButton.transform.parent = menu.transform;
            nextButton.transform.rotation = Quaternion.identity;
            nextButton.transform.localScale = NPsca;
            nextButton.transform.localPosition = NPpos;
            nextButton.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
            nextButton.AddComponent<Classes.Button>().relatedText = "NextPage";

            colorChanger = nextButton.AddComponent<ColorChanger>();
            colorChanger.colorInfo = buttonColors[0];//backgroundColor;
            colorChanger.Start();

            text = new GameObject
            {
                transform =
    {
        parent = canvasObject.transform
    }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = "⇢";
            text.fontSize = 1;
            text.color = textColors[0];
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f);
            component.localPosition = NPTpos;
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            // Mod Buttons
            ButtonInfo[] activeButtons = buttons[buttonsType].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
            for (int i = 0; i < activeButtons.Length; i++)
            {
                CreateButton(i * 0.1f, activeButtons[i]);
            }
        }


        public static void CreateButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = PageButtonSize;
            gameObject.transform.localPosition = new Vector3(buttonpos.x, buttonpos.y, buttonpos.z - offset * buttonspace);
            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;

            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            if (method.enabled)
            {
                colorChanger.colorInfo = buttonColors[1];
            }
            else
            {
                colorChanger.colorInfo = buttonColors[0];
            }
            colorChanger.Start();

            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = method.buttonText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.supportRichText = true;
            text.fontSize = 1;
            if (method.enabled)
            {
                text.color = textColors[1];
            }
            else
            {
                text.color = textColors[0];
            }
            text.alignment = TextAnchor.MiddleCenter;
            text.fontStyle = FontStyle.Normal;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.2f, .03f);
            component.localPosition = new Vector3(buttontpos.x, buttontpos.y, buttontpos.z - (offset / textspace));
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static void RecreateMenu()
        {
            if (menu != null)
            {
                UnityEngine.Object.Destroy(menu);
                menu = null;

                CreateMenu();
                RecenterMenu(rightHanded, UnityInput.Current.GetKey(keyboardButton));
            }
        }

        public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
        {
            if (!isKeyboardCondition)
            {
                if (!isRightHanded)
                {
                    menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    menu.transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                try
                {
                    TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
                }
                catch { }

                GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(false);

                if (TPC != null)
                {
                    TPC.transform.position = new Vector3(-999f, -999f, -999f);
                    TPC.transform.rotation = Quaternion.identity;
                    GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                    bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                    bg.GetComponent<Renderer>().material.color = new Color32((byte)(backgroundColor.colors[0].color.r * 50), (byte)(backgroundColor.colors[0].color.g * 50), (byte)(backgroundColor.colors[0].color.b * 50), 255);
                    GameObject.Destroy(bg, Time.deltaTime);
                    menu.transform.parent = TPC.transform;
                    menu.transform.position = (TPC.transform.position + (Vector3.Scale(TPC.transform.forward, new Vector3(0.5f, 0.5f, 0.5f)))) + (Vector3.Scale(TPC.transform.up, new Vector3(-0.02f, -0.02f, -0.02f)));
                    Vector3 rot = TPC.transform.rotation.eulerAngles;
                    rot = new Vector3(rot.x - 90, rot.y + 90, rot.z);
                    menu.transform.rotation = Quaternion.Euler(rot);

                    if (reference != null)
                    {
                        if (Mouse.current.leftButton.isPressed)
                        {
                            Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                            RaycastHit hit;
                            bool worked = Physics.Raycast(ray, out hit, 100);
                            if (worked)
                            {
                                Classes.Button collide = hit.transform.gameObject.GetComponent<Classes.Button>();
                                if (collide != null)
                                {
                                    collide.OnTriggerEnter(buttonCollider);
                                }
                            }
                        }
                        else
                        {
                            reference.transform.position = new Vector3(999f, -999f, -999f);
                        }
                    }
                }
            }
        }

        public static void CreateReference(bool isRightHanded)
        {
            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if (isRightHanded)
            {
                reference.transform.parent = GorillaTagger.Instance.leftHandTransform;
            }
            else
            {
                reference.transform.parent = GorillaTagger.Instance.rightHandTransform;
            }
            reference.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            buttonCollider = reference.GetComponent<SphereCollider>();

            ColorChanger colorChanger = reference.AddComponent<ColorChanger>();
            colorChanger.colorInfo = backgroundColor;
            colorChanger.Start();
        }

        public static void Toggle(string buttonText)
        {
            int lastPage = ((buttons[buttonsType].Length + buttonsPerPage - 1) / buttonsPerPage) - 1;
            if (buttonText == "PreviousPage")
            {
                pageNumber--;
                if (pageNumber < 0)
                {
                    pageNumber = lastPage;
                }
            } else
            {
                if (buttonText == "NextPage")
                {
                    pageNumber++;
                    if (pageNumber > lastPage)
                    {
                        pageNumber = 0;
                    }
                } else
                {
                    ButtonInfo target = GetIndex(buttonText);
                    if (target != null)
                    {
                        if (target.isTogglable)
                        {
                            target.enabled = !target.enabled;
                            if (target.enabled)
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                                if (target.enableMethod != null)
                                {
                                    try { target.enableMethod.Invoke(); } catch { }
                                }
                            }
                            else
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=red>DISABLE</color><color=grey>]</color> " + target.toolTip);
                                if (target.disableMethod != null)
                                {
                                    try { target.disableMethod.Invoke(); } catch { }
                                }
                            }
                        }
                        else
                        {
                            NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                            if (target.method != null)
                            {
                                try { target.method.Invoke(); } catch { }
                            }
                        }
                    }
                    else
                    {
                        UnityEngine.Debug.LogError(buttonText + " does not exist");
                    }
                }
            }
            RecreateMenu();
        }

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }

        public static ButtonInfo GetIndex(string buttonText)
        {
            foreach (ButtonInfo[] buttons in Buttons.buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.buttonText == buttonText)
                    {
                        return button;
                    }
                }
            }

            return null;
        }

        // Variables
            // Important
                // Objects
                    public static GameObject menu;
                    public static GameObject menuBackground;   
                    public static GameObject reference;
                    public static GameObject canvasObject;

                    public static SphereCollider buttonCollider;
                    public static Camera TPC;
                    public static Text fpsObject;

        // Data
            public static int pageNumber = 0;
            public static int buttonsType = 0;
    }
}
