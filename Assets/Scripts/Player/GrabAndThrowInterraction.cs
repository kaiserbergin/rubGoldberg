using UnityEngine;
using System.Collections;

public class GrabAndThrowInterraction : MonoBehaviour {
    private SteamVR_TrackedObject _trackedObject;
    private SteamVR_Controller.Device device;

    public float throwForceModifier = 1.5f;
    public ushort hapticFeedbackPulseForGrab = 2000;

    // Use this for initialization
    void Start() {
        _trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    private void Update() {
        device = SteamVR_Controller.Input((int)_trackedObject.index);
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Throwable")) {
            if(device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
                ThrowObject(other);
            } else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
                GrabObject(other);
            }
        }
    }

    private void GrabObject(Collider other) {
        other.transform.SetParent(gameObject.transform);
        other.GetComponent<Rigidbody>().isKinematic = true;
        device.TriggerHapticPulse(hapticFeedbackPulseForGrab);
    }

    private void ThrowObject(Collider other) {
        other.transform.SetParent(null);
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.velocity = device.velocity * throwForceModifier;
        rb.angularVelocity = device.angularVelocity;
    }
}
