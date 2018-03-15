using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager {
    public List<InventorySlot> _inventorySlots;
    
    public void AddItem(IItem item) {
        InventorySlot matchedInventorySlot = _inventorySlots.Find(slot => slot._item._itemType.Equals(item._itemType));
        if (matchedInventorySlot != null) {
            matchedInventorySlot.AddCount(1);
        } else {
            _inventorySlots.Add(new InventorySlot(item, 1));
        }
    }

    public void UseItem(IItem item) {
        InventorySlot matchedInventorySlot = _inventorySlots.Find(slot => slot._item._itemType.Equals(item._itemType));
        if (matchedInventorySlot != null && matchedInventorySlot._count > 0) {
            matchedInventorySlot.RemoveCount(1);
        } else {
            throw new System.InvalidOperationException("Cannot use an item that is not in the inventory.");
        }
    }
}
