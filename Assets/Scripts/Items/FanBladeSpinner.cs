using UnityEngine;
using System.Collections;

public class FanBladeSpinner : MonoBehaviour {
    public float rotationTime = 1f;

    private void Update() {
        float zRotation = Time.deltaTime / rotationTime * 360;
        Vector3 currentRotation = gameObject.transform.rotation.eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(currentRotation + new Vector3(0, 0, zRotation));
    }
}
