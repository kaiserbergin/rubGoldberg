using System;
using UnityEngine;
using System.Collections;

public class TutorialButton : MonoBehaviour {
    private SteamVR_TrackedObject _trackedObject;
    private SteamVR_Controller.Device device;

    public static event EventHandler<ButtonClickEvent> OnVRButtonClicked = delegate { };

    public ButtonTypes buttonType;

    private void Update() {
        if(_trackedObject == null) {
            Initialize();
        } else {
            device = SteamVR_Controller.Input((int)_trackedObject.index);
        }        
    }

    private void Initialize() {
        MenuInterractor menuInterractor = transform.root.GetComponentInChildren<MenuInterractor>();
        if(menuInterractor != null) {
            _trackedObject = menuInterractor.gameObject.GetComponent<SteamVR_TrackedObject>();
        }        
    }

    private void OnTriggerStay(Collider other) {
        if (ShouldTrackTouch(other) && device != null && device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
            ButtonClicked();
        }
    }

    protected void ButtonClicked() {
        Debug.Log($"Button clicked with type {buttonType}");
        OnVRButtonClicked(this, new ButtonClickEvent(buttonType));
    }

    private bool ShouldTrackTouch(Collider other) {
        return other.GetComponent<MenuInterractor>() != null &&
            other.GetComponentInChildren<Ball>() == null &&
            other.GetComponentInChildren<IItem>() == null;
    }
}
