using UnityEngine;
using System.Collections;

public class PlayerTeleporter : Teleporter {
    [Header("UI Representations")]
    public GameObject teleportationDirectionIndicator;
    public GameObject teleportationLocationMarker;

    [Header("Settings")]
    public GameObject player;
    public LayerMask layerMask;

    private Vector3 teleportationCoords;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
