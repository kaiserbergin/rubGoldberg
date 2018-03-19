﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntiGravityField : MonoBehaviour {

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
        if(!other.gameObject.CompareTag("Throwable")) {
            other.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        Rigidbody _rigidbody = other.attachedRigidbody;
        _rigidbody.useGravity = true;
        if (!other.gameObject.CompareTag("Throwable")) {
            other.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
        }
        others.Remove(other);
    }
}
