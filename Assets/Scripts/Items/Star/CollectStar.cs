using UnityEngine;
using System.Collections;

public class CollectStar : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        MonoBehaviour[] list = other.gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour mb in list) {
            if (mb is Ball) {
                gameObject.SetActive(false);
            }
        }
    }
}
