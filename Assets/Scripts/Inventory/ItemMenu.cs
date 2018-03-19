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

    private void Awake() {
        itemIcons = new List<ItemIcon3d>();
    }

    public void InitializeItemMenu() {
        if (inventoryManager != null) {
            foreach (InventorySlot inventorySlot in inventoryManager.inventorySlots) {
                IItem item = inventorySlot.item;
                ItemIcon3d itemIcon = Instantiate(item.ItemIcon3d) as ItemIcon3d;
                itemIcon.gameObject.SetActive(false);
                itemIcon.transform.SetParent(transform);
                UpdateIconText(itemIcon);
                itemIcons.Add(itemIcon);
            }
        }
    }

    public void OpenMenu() {  
        itemIcons[selectedInventorySlot].gameObject.SetActive(true);
        UpdateIconText(itemIcons[selectedInventorySlot]);
        isVisible = true;
    }

    public void CloseMenu() {
        itemIcons[selectedInventorySlot].gameObject.SetActive(false);
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

    public void UpdateIconText(ItemIcon3d itemIcon) {
        Text iconText = itemIcon.GetComponentInChildren<Text>();
        iconText.text = $"{inventoryManager.inventorySlots[selectedInventorySlot].item.ItemName}:  {inventoryManager.inventorySlots[selectedInventorySlot].count}x";
    }
}
