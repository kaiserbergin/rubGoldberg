using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntiGravityField : MonoBehaviour {

    private void OnTriggerStay(Collider other) {
        Rigidbody rb = other.attachedRigidbody;
        if (ShouldBeAffected(other, rb)) {
            if (IsGrabable(other)) {
                rb.isKinematic = true;
            }
            rb.useGravity = false;
        }
       
    }

    private void OnTriggerExit(Collider other) {
        Rigidbody rb = other.attachedRigidbody;
        if (ShouldBeAffected(other, rb)) {
            if (IsGrabable(other)) {
                rb.isKinematic = false;
            }
        }
        if (rb != null) rb.useGravity = true;
    }

    private bool ShouldBeAffected(Collider other, Rigidbody rb) {
        return (IsGrabable(other) || IsThrowable(other)) && !IsHeld(other) && rb != null;
    }

    private bool IsGrabable(Collider other) {
        return other.gameObject.CompareTag("Grabable");
    }
    private bool IsThrowable(Collider other) {
        return other.gameObject.CompareTag("Throwable");
    }
    private bool IsHeld(Collider other) {
        return other.transform.root.CompareTag("Player");
    }
}
