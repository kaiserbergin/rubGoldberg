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
        if(trampolineCount > 0) inventoryManager.AddItem(trampoline, trampolineCount);
        if(rampCount > 0) inventoryManager.AddItem(ramp, rampCount);
        if(fanCount > 0) inventoryManager.AddItem(fan, fanCount);
        if(metalPlankCount > 0) inventoryManager.AddItem(metalPlank, metalPlankCount);
        if(anitGravityFieldGeneratorCount > 0) inventoryManager.AddItem(anitGravityFieldGenerator, anitGravityFieldGeneratorCount);
    }
}
