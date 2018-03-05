using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class XRRigManager : MonoBehaviour {

    public List<XRRig> xrRigs;
    private bool xrRigChosen;

    // Use this for initialization
    void Start() {
        SetXRRig();
    }

    // Update is called once per frame
    void Update() {
        if (!xrRigChosen) {
            SetXRRig();
        }
        if (!UnityEngine.XR.XRDevice.isPresent) {
            xrRigChosen = false;
            //Do code to sync up the CameraRigs states 
            //such as position here
        }
    }

    private void SetXRRig() {
        Debug.Log("MODEL IS: " + UnityEngine.XR.XRDevice.model);
        foreach (XRRig xrRig in xrRigs) {
            Debug.Log("xrRig IS: " + xrRig.model);
            if (UnityEngine.XR.XRDevice.model.Equals(xrRig.model)) {
                Debug.Log("matched");
                xrRig.gameObject.SetActive(true);
                xrRigChosen = true;
            }
        }
    }
}
