using UnityEngine;
using System.Collections;

public class ViewCamInterraction : MonoBehaviour {
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    private bool canSelectNewMenuItem;

    public ViewCameraCycler viewCameraCycler;

    // Use this for initialization
    void Start() {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        canSelectNewMenuItem = true;
    }

    // Update is called once per frame
    void Update() {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        //Open and closes menu
        if(viewCameraCycler != null) {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
                if (viewCameraCycler.isCameraMenuRendered) viewCameraCycler.HideCameraMenu();
                else viewCameraCycler.ShowCameraMenu();
            }

            if (viewCameraCycler.isCameraMenuRendered) {
                //Navigating menu via x axis
                if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) {
                    if (canSelectNewMenuItem && device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x > .5f) {
                        viewCameraCycler.ViewNextCam();
                        canSelectNewMenuItem = false;
                    } else if (canSelectNewMenuItem && device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x < -.5f) {
                        viewCameraCycler.ViewPreviousCam();
                        canSelectNewMenuItem = false;
                    } else if (!canSelectNewMenuItem && Mathf.Abs(device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x) <= .5f) {
                        canSelectNewMenuItem = true;
                    }
                }
            }
        }
    }
}
