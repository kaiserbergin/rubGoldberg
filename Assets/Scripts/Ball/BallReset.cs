using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {

    private Vector3 _initialPosition;
    private Rigidbody _rigidbody;

    private void Start() {
        _initialPosition = gameObject.transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag.Equals("ground", System.StringComparison.InvariantCultureIgnoreCase)) {
            ResetBall();
        }
    }

    private void ResetBall() {
        gameObject.transform.position = _initialPosition;

        gameObject.transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
