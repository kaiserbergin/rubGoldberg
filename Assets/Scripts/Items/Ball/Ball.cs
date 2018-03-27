using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour, IItem {
    //Interface Properties
    public Guid ItemId { get; private set; }
    public ItemTypes ItemType { get; private set; }
    public String ItemName { get; set; }
    public ItemIcon3d ItemIcon3d { get; set; }

    //Public facing setters for editor
    public ItemIcon3d itemIcon3D;
    public String itemName;    

    public void Initialize() { 
        ItemName = itemName;
        ItemIcon3d = itemIcon3D;
        ItemType = ItemTypes.BALL;
    }

    private void Awake() {
        ItemId = Guid.NewGuid();
    }
}
