using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour {

    //Dependencies
    public InventoryManager inventoryManager;

    //Internal tracking
    private List<ItemIcon3d> itemIcons;
    public int selectedInventorySlot = 0;

    //Pulbic facing info
    public bool isVisible = false;

    public void InitializeItemMenu() {
        itemIcons = itemIcons ?? new List<ItemIcon3d>();
        if (inventoryManager != null) {
            foreach (InventorySlot inventorySlot in inventoryManager.inventorySlots) {
                IItem item = inventorySlot.item;
                ItemIcon3d itemIcon = Instantiate(item.ItemIcon3d, transform, false) as ItemIcon3d;
                itemIcon.gameObject.SetActive(false);
                UpdateIconText(inventorySlot, itemIcon);
                itemIcons.Add(itemIcon);
            }
        }
    }

    public void OpenMenu() {  
        itemIcons[selectedInventorySlot].gameObject.SetActive(true);
        UpdateIconText(inventoryManager.inventorySlots[selectedInventorySlot], itemIcons[selectedInventorySlot]);
        isVisible = true;
    }

    public void CloseMenu() {
        itemIcons[selectedInventorySlot].gameObject.SetActive(false);
        UpdateIconText(inventoryManager.inventorySlots[selectedInventorySlot], itemIcons[selectedInventorySlot]);
        isVisible = false;
    }

    public void ViewNextItem() {
        itemIcons[selectedInventorySlot].gameObject.SetActive(false);
        if(selectedInventorySlot == inventoryManager.inventorySlots.Count - 1) {
            selectedInventorySlot = 0;
        } else {
            selectedInventorySlot++;
        }
        itemIcons[selectedInventorySlot].gameObject.SetActive(true);
    }

    public void ViewPreviousItem() {
        itemIcons[selectedInventorySlot].gameObject.SetActive(false);
        if (selectedInventorySlot == 0) {
            selectedInventorySlot = inventoryManager.inventorySlots.Count - 1;
        } else {
            selectedInventorySlot--;
        }
        itemIcons[selectedInventorySlot].gameObject.SetActive(true);
    }

    public void SpawnItem() {
        InventorySlot inventorySlot = inventoryManager.inventorySlots[selectedInventorySlot];
        if (inventorySlot.count > 0) {
            Instantiate(((MonoBehaviour)inventorySlot.item).gameObject, transform.parent.position, Quaternion.Euler(((MonoBehaviour)inventorySlot.item).transform.rotation.eulerAngles));
            inventorySlot.count--;
            UpdateIconText(inventorySlot, itemIcons[selectedInventorySlot]);
        }
    }

    public void UpdateIconText(InventorySlot inventorySlot, ItemIcon3d itemIcon) {
        Text iconText = itemIcon.GetComponentInChildren<Text>();
        iconText.text = $"{inventorySlot.item.ItemName}:  {inventorySlot.count}x";
    }
}
