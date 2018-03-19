using UnityEngine;
using System.Collections;

public class TestItemMenu : MonoBehaviour {
    public ItemMenu itemMenu;
    public InventoryManagerSetUp inventoryManagerSetUp;

    private void Start() {
        inventoryManagerSetUp.InitializeInventory();
        itemMenu.InitializeItemMenu();
    }
}
