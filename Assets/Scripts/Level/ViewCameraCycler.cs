using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewCameraCycler : MonoBehaviour {
    public GameObject ViewCameraCollection;
    private Camera[] viewCams;
    private int currentCamIndex;
    public bool isCameraMenuRendered;

    // Use this for initialization
    void Awake() {
        if(ViewCameraCollection != null) {
            viewCams = ViewCameraCollection.GetComponentsInChildren<Camera>();
        }        
        if (viewCams != null && viewCams.Length > 0) currentCamIndex = 0;
    }

    private void Start() {
        if(viewCams != null && viewCams.Length > 0) {
            foreach (Camera camera in viewCams) {
                camera.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }        
    }

    public void ShowCameraMenu() {
        gameObject.SetActive(true);
        viewCams[currentCamIndex].gameObject.SetActive(true);
        isCameraMenuRendered = true;
    }

    public void HideCameraMenu() {
        gameObject.SetActive(false);
        viewCams[currentCamIndex].gameObject.SetActive(false);
        isCameraMenuRendered = false;
    }

    public void ViewNextCam() {
        viewCams[currentCamIndex].gameObject.SetActive(false);
        if (currentCamIndex == viewCams.Length - 1) {
            currentCamIndex = 0;
        } else {
            currentCamIndex++;
        }
        viewCams[currentCamIndex].gameObject.SetActive(true);
    }

    public void ViewPreviousCam() {
        viewCams[currentCamIndex].gameObject.SetActive(false);
        if (currentCamIndex == 0) {
            currentCamIndex = viewCams.Length - 1;
        } else {
            currentCamIndex--;
        }
        viewCams[currentCamIndex].gameObject.SetActive(true);
    }
}
