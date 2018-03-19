using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
    public List<InventorySlot> inventorySlots;
    
    public void AddItem(IItem item) {
        InventorySlot matchedInventorySlot = inventorySlots.Find(slot => slot.item.ItemType.Equals(item.ItemType));
        if (matchedInventorySlot != null) {
            matchedInventorySlot.AddCount(1);
        } else {
            inventorySlots.Add(new InventorySlot(item, 1));
        }
    }

    public void AddItem(IItem item, int count) {
        InventorySlot matchedInventorySlot = inventorySlots.Find(slot => slot.item.ItemType.Equals(item.ItemType));
        if (matchedInventorySlot != null) {
            matchedInventorySlot.AddCount(count);
        } else {
            inventorySlots.Add(new InventorySlot(item, count));
        }
    }

    public void UseItem(IItem item) {
        InventorySlot matchedInventorySlot = inventorySlots.Find(slot => slot.item.ItemType.Equals(item.ItemType));
        if (matchedInventorySlot != null && matchedInventorySlot.count > 0) {
            matchedInventorySlot.RemoveCount(1);
        } else {
            throw new System.InvalidOperationException("Cannot use an item that is not in the inventory.");
        }
    }

    public void UseItem(IItem item, int count) {
        InventorySlot matchedInventorySlot = inventorySlots.Find(slot => slot.item.ItemType.Equals(item.ItemType));
        if (matchedInventorySlot != null && matchedInventorySlot.count > count) {
            matchedInventorySlot.RemoveCount(count);
        } else {
            throw new System.InvalidOperationException("Cannot use an item that is not in the inventory.");
        }
    }
}
