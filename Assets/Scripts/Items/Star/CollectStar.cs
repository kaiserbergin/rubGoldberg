using UnityEngine;
using System.Collections;

public class CollectStar : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        MonoBehaviour[] list = other.gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour mb in list) {
            if (mb is Ball && !mb.transform.root.tag.Equals("Player", System.StringComparison.InvariantCultureIgnoreCase)) {
                gameObject.SetActive(false);
            }
        }
    }
}
