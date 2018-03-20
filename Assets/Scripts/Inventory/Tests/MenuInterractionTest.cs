using UnityEngine;
using System.Collections;

public class MenuInterractionTest : MonoBehaviour {
    
    public ItemMenu itemMenu;
    public InventoryManagerSetUp inventoryManagerSetUp;

    private bool spawnStarted;

    private void Start() {
        inventoryManagerSetUp.InitializeInventory();
        itemMenu.InitializeItemMenu();        
    }

    private void Update() {
        if (!spawnStarted) {
            StartCoroutine(WaitTime());
            spawnStarted = true;
        }        
    }

    IEnumerator WaitTime() {
        for (int i = 0; i < itemMenu.inventoryManager.inventorySlots.Count; i++) {
            itemMenu.SpawnItem();
            itemMenu.ViewNextItem();
            yield return new WaitForSeconds(2.5f);
        }
    }
}