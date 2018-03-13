using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntiGravityFieldGenerator : MonoBehaviour {

    private List<Collider> others;

    private void Start() {
        others = new List<Collider>();
    }

    // Use this for initialization
    private void FixedUpdate() {
        foreach (Collider other in others) {
            Rigidbody _rigidbody = other.attachedRigidbody;
            _rigidbody.useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        others.Add(other);
    }

    private void OnTriggerExit(Collider other) {
        Rigidbody _rigidbody = other.attachedRigidbody;
        _rigidbody.useGravity = true;
        others.Remove(other);
    }
}
