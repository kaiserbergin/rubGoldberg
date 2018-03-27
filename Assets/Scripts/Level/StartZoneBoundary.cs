using UnityEngine;
using System.Collections;

public class StartZoneBoundary : MonoBehaviour {
    public Ball ball;
    public GrabAndThrowInterraction throwingHand;

    private void OnTriggerStay(Collider other) {
        if(ball != null && throwingHand != null && other.transform.root.GetComponentInChildren<Ball>() != null) {
            throwingHand.canThrowBall = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (ball != null && throwingHand != null && other.transform.root.GetComponentInChildren<Ball>() != null) {
            throwingHand.canThrowBall = false;
        }
    }

}
