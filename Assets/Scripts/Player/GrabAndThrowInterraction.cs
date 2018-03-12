using UnityEngine;
using System.Collections;

public class GrabAndThrowInterraction : MonoBehaviour {
    private SteamVR_TrackedObject _trackedObject;
    private SteamVR_Controller.Device _steamController;

    public float _throwForce = 1.5f;
    public ushort _hapticFeedbackPulseForGrab = 2000;

    // Use this for initialization
    void Start() {
        _trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    private void Update() {
        _steamController = SteamVR_Controller.Input((int)_trackedObject.index);
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Throwable")) {
            if(_steamController.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
                ThrowObject(other);
            } else if (_steamController.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
                GrabObject(other);
            }
        }
    }

    private void GrabObject(Collider other) {
        other.transform.SetParent(gameObject.transform);
        other.GetComponent<Rigidbody>().isKinematic = true;
        _steamController.TriggerHapticPulse(_hapticFeedbackPulseForGrab);
    }

    private void ThrowObject(Collider other) {
        other.transform.SetParent(null);
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.velocity = _steamController.velocity * _throwForce;
        rb.angularVelocity = _steamController.angularVelocity;
    }
}
