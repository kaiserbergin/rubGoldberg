using UnityEngine;

public class Icon3dRotator : MonoBehaviour {
    public float rotationTimeInSeconds = 5f;

    // Update is called once per frame
    void Update() {
        transform.rotation = Quaternion.Euler(new Vector3(
            transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y,
            transform.rotation.eulerAngles.z + (Time.deltaTime / rotationTimeInSeconds * 360)
        ));
    }
}
