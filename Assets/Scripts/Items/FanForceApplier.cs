using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FanForceApplier : MonoBehaviour {

    public float fanForceModifier = 5f;

    private List<Collider> others;
    private Vector3 force;

    private void Start() {
        others = new List<Collider>();
        force = transform.forward * fanForceModifier;
    }

    // Use this for initialization
    private void FixedUpdate() {
        foreach (Collider other in others) {
            Rigidbody _rigidbody = other.attachedRigidbody;
            _rigidbody.useGravity = false;
            _rigidbody.AddForce(force);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Throwable")) {
            others.Add(other);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Throwable")) {
            Rigidbody _rigidbody = other.attachedRigidbody;
            _rigidbody.useGravity = true;
            others.Remove(other);
        }
    }
}
