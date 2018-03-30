using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
    public float rotationTime = 5f;

    private void Update() {
        float yRotation = Time.deltaTime / rotationTime * 360;
        Vector3 currentRotation = gameObject.transform.rotation.eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(currentRotation + new Vector3(0, yRotation, 0));
    }
}
