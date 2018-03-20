using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManagerSetUp : MonoBehaviour {
    public InventoryManager inventoryManager;

    public Trampoline trampoline;
    public int trampolineCount;

    public Ramp ramp;
    public int rampCount;

    public Fan fan;
    public int fanCount;

    public MetalPlank metalPlank;
    public int metalPlankCount;

    public AnitGravityFieldGenerator anitGravityFieldGenerator;
    public int anitGravityFieldGeneratorCount;

    // Use this for initialization
    public void InitializeInventory() {
        inventoryManager.AddItem(trampoline, trampolineCount);
        inventoryManager.AddItem(ramp, rampCount);
        inventoryManager.AddItem(fan, fanCount);
        inventoryManager.AddItem(metalPlank, metalPlankCount);
        inventoryManager.AddItem(anitGravityFieldGenerator, anitGravityFieldGeneratorCount);
    }
}
