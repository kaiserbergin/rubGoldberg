using UnityEngine;
using System;
using System.Collections.Generic;

public class Fan : MonoBehaviour, IItem {
    public float _fanForceModifier = 5f;

    private List<Collider> others;
    private Vector3 _force;

    public Guid _itemId { get; private set; }
    public ItemTypes _itemType { get; private set; }

    private void Awake() {
        _itemId = Guid.NewGuid();
        _itemType = ItemTypes.FAN;
    }

    private void Start() {
        others = new List<Collider>();
        _force = transform.forward * _fanForceModifier;
    }

    // Use this for initialization
    private void FixedUpdate() {
        foreach(Collider other in others) {
            Rigidbody _rigidbody = other.attachedRigidbody;
            _rigidbody.useGravity = false;
            _rigidbody.AddForce(_force);
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
