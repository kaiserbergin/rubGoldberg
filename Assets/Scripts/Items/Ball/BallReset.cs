using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {

    private Vector3 initialPosition;
    private Rigidbody rb;

    //TODO: add this to level manager
    public List<Star> stars;

    private void Start() {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag.Equals("ground", System.StringComparison.InvariantCultureIgnoreCase)) {
            ResetBall();
            ResetStars();
        }
    }

    public void ResetBall() {
        transform.SetParent(null);
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void ResetStars() {
        foreach(Star star in stars) {
            star.gameObject.SetActive(true);
        }
    }
}
