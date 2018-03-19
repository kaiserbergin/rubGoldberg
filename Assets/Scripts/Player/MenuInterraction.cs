using UnityEngine;
using System.Collections;

public class MenuInterraction : MonoBehaviour {
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    private bool canSelectNewMenuItem;

    public ItemMenu itemMenu;

    // Use this for initialization
    void Start() {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        canSelectNewMenuItem = true;
    }

    // Update is called once per frame
    void Update() {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        //Open and closes menu
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
            Debug.Log("pressed the joystick");
            if (itemMenu.isVisible) itemMenu.CloseMenu();
            else itemMenu.OpenMenu();
        }

        //Navigating menu via x axis
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) {
            if (canSelectNewMenuItem && device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x > .5f) {
                Debug.Log("should view next");
                itemMenu.ViewNextItem();
                canSelectNewMenuItem = false;
            } else if (canSelectNewMenuItem && device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x < -.5f) {
                Debug.Log("should view previous");
                itemMenu.ViewPreviousItem();
                canSelectNewMenuItem = false;
            } else if (!canSelectNewMenuItem && Mathf.Abs(device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x) <= .5f) {
                canSelectNewMenuItem = true;
            }
        }
    }
}
