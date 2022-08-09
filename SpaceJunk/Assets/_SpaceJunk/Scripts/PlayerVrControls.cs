using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVrControls : MonoBehaviour
{
    // list of devices
    List<UnityEngine.XR.InputDevice> leftHandDevices = new List<UnityEngine.XR.InputDevice>();
    List<UnityEngine.XR.InputDevice> rightHandDevices = new List<UnityEngine.XR.InputDevice>();
    List<UnityEngine.XR.InputDevice> headDevices = new List<UnityEngine.XR.InputDevice>();

    // interactions player can press
    public bool playerHasHeadSet = false;
    public bool playerHasLeftController = false;
    public bool playerHasRightController = false;
    public bool playerLeftTrigger = false;
    public bool playerRightTrigger = false;
    public Vector2 playerLeftStick;
    public Vector2 playerRightStick;
    public bool playerLeftPrimary = false;
    public bool playerRightPrimary = false;
    public bool playerLeftSecondary = false;
    public bool playerRightSecondary = false;
    public bool playerLeftGrab = false;
    public bool playerRightGrab = false;

    // Update is called once per frame
    void Update()
    {
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.Head, headDevices);
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

        // does player have a headset?
        if (headDevices.Count > 0) playerHasHeadSet = true;
        else playerHasHeadSet = false;

        // they have a lefthand controller, what are they pressing?
        if (leftHandDevices.Count > 0)
        {
            leftHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out playerLeftTrigger);
            leftHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out playerLeftStick);
            leftHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out playerLeftPrimary);
            leftHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out playerLeftSecondary);
            leftHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out playerLeftGrab);
            playerHasLeftController = true;
        }
        else playerHasLeftController = false;

        // they have a righthand controller, what are they pressing?
        if (rightHandDevices.Count > 0)
        {
            rightHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out playerRightTrigger);
            rightHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out playerRightStick);
            rightHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out playerRightPrimary);
            rightHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out playerRightSecondary);
            rightHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out playerRightGrab);
            playerHasRightController = true;
        }
        else playerHasRightController = false;
    }
}
