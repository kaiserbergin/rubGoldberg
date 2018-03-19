using UnityEngine;
using System.Collections;

public class InventoryManagerSetUp : MonoBehaviour {
    public InventoryManager inventoryManager;

    public Trampoline trampoline;
    public Ramp ramp;
    public Fan fan;
    public MetalPlank metalPlank;
    public AnitGravityFieldGenerator anitGravityFieldGenerator;
    // Use this for initialization
    public void InitializeInventory() {
        inventoryManager.inventorySlots.Add(new InventorySlot(trampoline, 5));
        inventoryManager.inventorySlots.Add(new InventorySlot(ramp, 5));
        inventoryManager.inventorySlots.Add(new InventorySlot(fan, 5));
        inventoryManager.inventorySlots.Add(new InventorySlot(metalPlank, 5));
        inventoryManager.inventorySlots.Add(new InventorySlot(anitGravityFieldGenerator, 5));
    }
}
