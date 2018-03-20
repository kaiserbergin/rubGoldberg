using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntiGravityField : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        Rigidbody rb = getRigidBody(other);
        if (other.gameObject.CompareTag("Grabable")) {
            rb.isKinematic = true;
        }
        rb.useGravity = false;
    }

    private void OnTriggerExit(Collider other) {
        Rigidbody rb = getRigidBody(other);
        if (other.gameObject.CompareTag("Grabable")) {
            rb.isKinematic = false;
        }
        rb.useGravity = true;
    }

    private Rigidbody getRigidBody(Collider other) {
        return other.attachedRigidbody ?? other.transform.parent.GetComponent<Rigidbody>();
    }
}
