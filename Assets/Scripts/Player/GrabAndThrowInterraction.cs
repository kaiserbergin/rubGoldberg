using UnityEngine;
using System.Collections;

public class GrabAndThrowInterraction : MonoBehaviour {
    private SteamVR_TrackedObject _trackedObject;
    private SteamVR_Controller.Device device;

    public float throwForceModifier = 1.5f;
    public ushort hapticFeedbackPulseForGrab = 2000;

    private Transform heldObject;

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
        if (other.transform.CompareTag("Grabable")) {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
                Debug.Log($"dropping {other.transform.name}");
                DropObject(other);
            } else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
                Debug.Log($"grabbing {other.transform.name}");
                GrabObject(other);
            }
        }
    }

    private void GrabObject(Collider other) {
        heldObject = other.transform;
        heldObject.SetParent(gameObject.transform);
        Rigidbody rb = GetRigidbody(heldObject);
        if(rb != null) {
            rb.isKinematic = true;
        }
        device.TriggerHapticPulse(hapticFeedbackPulseForGrab);
    }

    private void ThrowObject(Collider other) {
        heldObject.SetParent(null);
        Rigidbody rb = GetRigidbody(heldObject);
        rb.isKinematic = false;
        rb.velocity = device.velocity * throwForceModifier;
        rb.angularVelocity = device.angularVelocity;
        heldObject = null;
    }

    private void DropObject(Collider other) {
        heldObject.SetParent(null);
        Rigidbody rb = GetRigidbody(heldObject);
        if(rb != null) {
            rb.isKinematic = false;
            heldObject = null;
        }
    }

    private Rigidbody GetRigidbody(Transform transform) {
        return heldObject.GetComponent<Rigidbody>() ?? heldObject.parent.GetComponent<Rigidbody>();
    }
}
