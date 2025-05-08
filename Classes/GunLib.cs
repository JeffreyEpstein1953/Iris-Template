using BepInEx;
using ExitGames.Client.Photon;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

namespace GunLib
{
    public class ClientInput
    {
        public static bool GetInputValue(float grabValue)
        {
            return grabValue >= 0.75f;
        }
    }
    public class GunTemplate : MonoBehaviour
    {
        public static int LineCurve = 150;
        private const float PulseSpeed = 2f;
        private const float PulseAmplitude = 0.03f;

        public static GameObject spherepointer;
        public static VRRig LockedPlayer;
        public static Vector3 lr;
        public static Color32 PointerColor = new Color32(233, 30, 99, 255);
        //public static Color32 LineColor = new Color32(233, 30, 99, 255);
        public static Color32 TriggeredPointerColor = Color.green;
        //public static Color32 TriggeredLineColor = Color.green;

        public static RaycastHit nray;
        private static bool lockToggleState = false;
        private static bool wasTriggerPressed = false;
        public static bool useHeadPosition = false;

        public static void StartVrGun(Action action, bool LockOn)
        {
            Vector3 rayOrigin;
            Vector3 rayDirection;

            if (useHeadPosition)
            {
                rayOrigin = GorillaTagger.Instance.headCollider.transform.position;
                rayDirection = (GorillaTagger.Instance.headCollider.transform.forward + Vector3.down * 0.1f).normalized;
            }
            else
            {
                rayOrigin = GorillaTagger.Instance.rightHandTransform.position;
                rayDirection = (-GorillaTagger.Instance.rightHandTransform.up + GorillaTagger.Instance.rightHandTransform.forward * 0.5f).normalized;
            }

            Physics.Raycast(rayOrigin, rayDirection, out nray, float.MaxValue);

            if (spherepointer == null)
            {
                spherepointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                spherepointer.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                var renderer = spherepointer.GetComponent<Renderer>();
                renderer.material.shader = Shader.Find("GUI/Text Shader");

                Collider[] colliders = spherepointer.GetComponents<Collider>();
                foreach (Collider collider in colliders)
                {
                    GameObject.Destroy(collider);
                }

                lr = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
                spherepointer.AddComponent<GunTemplate>().StartCoroutine(PulsePointer(spherepointer));
            }

            bool isTriggerPressed = ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f;

            if (isTriggerPressed && !wasTriggerPressed && LockOn)
            {
                lockToggleState = !lockToggleState;

                if (lockToggleState)
                {
                    LockedPlayer = nray.collider?.GetComponentInParent<VRRig>();
                    if (LockedPlayer != null)
                    {
                        LockedPlayerActorNumber = PhotonView.Get(LockedPlayer.gameObject)?.Owner.ActorNumber;
                    }
                    else
                    {
                        lockToggleState = false;
                    }
                }
                else
                {
                    LockedPlayer = null;
                    LockedPlayerActorNumber = null;
                }
            }
            wasTriggerPressed = isTriggerPressed;

            if (LockedPlayer != null)
            {
                spherepointer.transform.position = LockedPlayer.transform.position;
                spherepointer.GetComponent<Renderer>().material.color = TriggeredPointerColor;
                action();
            }
            else
            {
                spherepointer.transform.position = nray.point;
                spherepointer.GetComponent<Renderer>().material.color = isTriggerPressed ? TriggeredPointerColor : PointerColor;

                if (isTriggerPressed && !LockOn)
                {
                    action();
                }
            }
        }

        public static int? LockedPlayerActorNumber;

        public static void FireAtLockedPlayer()
        {
            if (LockedPlayerActorNumber.HasValue)
            {
                int targetActorNumber = LockedPlayerActorNumber.Value;
                Testung(targetActorNumber);
            }
            else
            {
                Debug.LogWarning("No player locked to fire at.");
            }
        }

        public static void Testung(int targetPlayerActorNumber)
        {

        }

        public static void StartPcGun(Action action, bool LockOn)
        {
            Ray ray = GameObject.Find("Shoulder Camera").activeSelf ? GameObject.Find("Shoulder Camera").GetComponent<Camera>().ScreenPointToRay(UnityInput.Current.mousePosition) : GorillaTagger.Instance.mainCamera.GetComponent<Camera>().ScreenPointToRay(UnityInput.Current.mousePosition);

            if (Mouse.current.rightButton.isPressed)
            {
                if (Physics.Raycast(ray.origin, ray.direction, out nray, float.PositiveInfinity, -32777) && spherepointer == null)
                {
                    if (spherepointer == null)
                    {
                        spherepointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        var renderer = spherepointer.GetComponent<Renderer>();
                        renderer.material.shader = Shader.Find("GUI/Text Shader");
                        spherepointer.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);

                        Collider[] colliders = spherepointer.GetComponents<Collider>();
                        foreach (Collider collider in colliders)
                        {
                            GameObject.Destroy(collider);
                        }

                        lr = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
                        spherepointer.AddComponent<GunTemplate>().StartCoroutine(PulsePointer(spherepointer));
                    }
                }

                bool isLeftMousePressed = Mouse.current.leftButton.isPressed;

                if (isLeftMousePressed && !wasTriggerPressed && LockOn)
                {
                    lockToggleState = !lockToggleState;

                    if (lockToggleState)
                    {
                        LockedPlayer = nray.collider?.GetComponentInParent<VRRig>();
                        if (LockedPlayer != null)
                        {
                            LockedPlayerActorNumber = PhotonView.Get(LockedPlayer.gameObject)?.Owner.ActorNumber;
                        }
                        else
                        {
                            lockToggleState = false;
                        }
                    }
                    else
                    {
                        LockedPlayer = null;
                        LockedPlayerActorNumber = null;
                    }
                }
                wasTriggerPressed = isLeftMousePressed;

                if (LockedPlayer != null)
                {
                    spherepointer.transform.position = LockedPlayer.transform.position;
                    spherepointer.GetComponent<Renderer>().material.color = TriggeredPointerColor;
                    action();
                }
                else
                {
                    spherepointer.transform.position = nray.point;
                    spherepointer.GetComponent<Renderer>().material.color = isLeftMousePressed ? TriggeredPointerColor : PointerColor;

                    if (isLeftMousePressed && !LockOn)
                    {
                        action();
                    }
                }
            }
            else if (spherepointer != null)
            {
                GameObject.Destroy(spherepointer);
                spherepointer = null;
                LockedPlayer = null;
                lockToggleState = false;
            }
        }

        public static void StartBothGuns(Action action, bool locko)
        {
            if (XRSettings.isDeviceActive)
            {
                StartVrGun(action, locko);
            }
            if (!XRSettings.isDeviceActive)
            {
                StartPcGun(action, locko);
            }
        }

        private static IEnumerator PulsePointer(GameObject pointer)
        {
            Vector3 originalScale = pointer.transform.localScale;
            while (true)
            {
                float scaleFactor = 1 + Mathf.Sin(Time.time * PulseSpeed) * PulseAmplitude;
                pointer.transform.localScale = originalScale * scaleFactor;
                yield return null;
            }
        }
    }
}