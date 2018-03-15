using UnityEngine;
using System.Collections;

public class OculusInputDebugger : MonoBehaviour {
    private SteamVR_TrackedObject _trackedObject;
    private SteamVR_Controller.Device _steamController;

    private bool canSelectNewMenuItem;

    // Use this for initialization
    void Start() {
        _trackedObject = GetComponent<SteamVR_TrackedObject>();
        canSelectNewMenuItem = true;
    }

    // Update is called once per frame
    void Update() {
        _steamController = SteamVR_Controller.Input((int)_trackedObject.index);
        if (_steamController.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
            Debug.Log("SteamVR_Controller.ButtonMask.Touchpad is depressed");
        }
        if (_steamController.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
            Debug.Log("SteamVR_Controller.ButtonMask.Touchpad is lifted up");
        }

        if(_steamController.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) {
            //Debug.Log($"k_EButton_Axis0 x value: {_steamController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x}");
            //Debug.Log($"k_EButton_SteamVR_Touchpad x value: {_steamController.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x}");
            if(canSelectNewMenuItem && Mathf.Abs(_steamController.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x) > .5f) {
                Debug.Log("I'm gonna select the next thing");
                canSelectNewMenuItem = false;
            }
            if(!canSelectNewMenuItem && Mathf.Abs(_steamController.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x) <= .5f) {
                Debug.Log("I'm gonna enable selecting the next thing");
                canSelectNewMenuItem = true;
            }
        }
    }
}
