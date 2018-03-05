using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
    /// <summary>
    /// Moves a game object to desired location
    /// </summary>
    /// <param name="obj">Game Object to be teleported</param>
    /// <param name="tpLocation">Location to teleport to</param>
    public void Teleport(GameObject obj, Vector3 tpLocation) {
        obj.transform.position = tpLocation;
    }
}
