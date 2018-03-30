using UnityEngine;
using System.Collections;

public class PlayerTeleporter : Teleporter {
    [Header("UI Representations")]
    public LineRenderer teleportationDirectionIndicator;
    public GameObject teleportationLocationMarker;

    [Header("Settings")]
    public GameObject player;
    public LayerMask telportationSurfaceMask;
    public LayerMask boundaryMask;
    public LayerMask platformMask;

    [Header("Device")]
    public SteamVR_TrackedObject trackedObject;
    public SteamVR_Controller.Device controllerDevice;


    private Vector3 teleportationCoords;


    // Use this for initialization
    void Start() {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        teleportationDirectionIndicator = GetComponentInChildren<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        controllerDevice = SteamVR_Controller.Input((int)trackedObject.index);
        HandleTeleporterInput();
    }

    void HandleTeleporterInput() {
        if (controllerDevice.GetPress(SteamVR_Controller.ButtonMask.Trigger)) {
            teleportationDirectionIndicator.gameObject.SetActive(true);
            teleportationLocationMarker.SetActive(true);

            teleportationDirectionIndicator.SetPosition(0, gameObject.transform.position);
            RaycastHit hit;

            //If Raycast hits boundary
            if (Physics.Raycast(transform.position, transform.forward, out hit, 15, platformMask)) {
                teleportationCoords = PlatformCast(hit.point);
            } else if (Physics.Raycast(transform.position, transform.forward, out hit, 15, boundaryMask)) {
                teleportationCoords = BoundaryCast(hit.point);
            } else if (Physics.Raycast(transform.position, transform.forward, out hit, 15, telportationSurfaceMask)) {
                teleportationCoords = hit.point;
                teleportationDirectionIndicator.SetPosition(1, teleportationCoords);
                teleportationLocationMarker.transform.position = teleportationCoords;
            } else {
                teleportationCoords = GroundCast();
            }
        }
        if (controllerDevice.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
            teleportationDirectionIndicator.gameObject.SetActive(false);
            teleportationLocationMarker.SetActive(false);
            player.transform.position = teleportationCoords;
        }
    }

    private Vector3 BoundaryCast(Vector3 hitPoint) {
        RaycastHit groundRay;
        Vector3 teleportationCoords = hitPoint;
        if (Physics.Raycast(hitPoint, -Vector3.up, out groundRay, 100, telportationSurfaceMask)) {
            teleportationCoords = groundRay.point;
        }
        teleportationDirectionIndicator.SetPosition(1, hitPoint);
        teleportationLocationMarker.transform.position = teleportationCoords;

        return teleportationCoords;
    }

    private Vector3 GroundCast() {
        teleportationCoords = transform.forward * 15 + transform.position;
        RaycastHit groundRay;
        if (Physics.Raycast(teleportationCoords, -Vector3.up, out groundRay, 100, telportationSurfaceMask)) {
            teleportationCoords = groundRay.point;
        }
        teleportationDirectionIndicator.SetPosition(1, transform.forward * 15 + transform.position);
        teleportationLocationMarker.transform.position = teleportationCoords;

        return teleportationCoords;
    }

    private Vector3 PlatformCast(Vector3 hitPoint) {
        RaycastHit upwardsRay;
        Vector3 teleportationCoords = hitPoint;
        if (Physics.Raycast(hitPoint, Vector3.up, out upwardsRay, 100, telportationSurfaceMask)) {
            teleportationCoords = upwardsRay.point;
        }
        teleportationDirectionIndicator.SetPosition(1, hitPoint);
        teleportationLocationMarker.transform.position = teleportationCoords;

        return teleportationCoords;
    }
}
