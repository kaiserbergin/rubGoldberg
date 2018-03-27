using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
    [SerializeField]
    private BallReset ballResetScript;
    [SerializeField]
    private SteamVR_LoadLevel levelLoader;

    private void OnTriggerEnter(Collider other) {
        if(levelLoader != null && AreStarsCollected() && other.transform.root.GetComponentInChildren<Ball>() != null) {
            ballResetScript.gameObject.SetActive(false);
            levelLoader.Trigger();
        }
    }

    private bool AreStarsCollected() {
        foreach(Star star in ballResetScript.stars) {
            if (star.gameObject.activeInHierarchy) return false;
        }
        return true;
    }
}
