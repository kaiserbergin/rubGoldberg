using UnityEngine;
using System.Collections;

public class PlayerTeleporter : Teleporter {
    [Header("UI Representations")]
    public LineRenderer teleportationDirectionIndicator;
    public GameObject teleportationLocationMarker;

    [Header("Settings")]
    public GameObject player;
    public LayerMask telportationSurfaceMask;

    [Header("Device")]
    public SteamVR_TrackedObject trackedObject;
    public SteamVR_Controller.Device controllerDevice;

    [Header("Dependencies")]
    public ItemMenu itemMenu;

    private Vector3 teleportationCoords;


    // Use this for initialization
    void Start() {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        teleportationDirectionIndicator = GetComponentInChildren<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        controllerDevice = SteamVR_Controller.Input((int)trackedObject.index);
        if(!itemMenu.isVisible) {
            HandleTeleporterInput();
        }        
    }

    void HandleTeleporterInput() {
        if (controllerDevice.GetPress(SteamVR_Controller.ButtonMask.Trigger)) {
            teleportationDirectionIndicator.gameObject.SetActive(true);
            teleportationLocationMarker.SetActive(true);

            teleportationDirectionIndicator.SetPosition(0, gameObject.transform.position);
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 15, telportationSurfaceMask)) {
                teleportationCoords = hit.point;
                teleportationDirectionIndicator.SetPosition(1, teleportationCoords);
                //aimer position
                teleportationLocationMarker.transform.position = teleportationCoords;
            } else {
                teleportationCoords = transform.forward * 15 + transform.position;
                RaycastHit groundRay;
                if (Physics.Raycast(teleportationCoords, -Vector3.up, out groundRay, 17, telportationSurfaceMask)) {
                    teleportationCoords = groundRay.point;
                }
                teleportationDirectionIndicator.SetPosition(1, transform.forward * 15 + transform.position);
                //aimer position
                teleportationLocationMarker.transform.position = teleportationCoords;

            }
        }
        if (controllerDevice.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
            teleportationDirectionIndicator.gameObject.SetActive(false);
            teleportationLocationMarker.SetActive(false);
            player.transform.position = teleportationCoords;
        }
    }
}
