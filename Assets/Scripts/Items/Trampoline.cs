using System;
using UnityEngine;

public class Trampoline : MonoBehaviour, IItem {

    public Guid _itemId { get; private set; }
    public ItemTypes _itemType { get; private set; }

    private void Awake() {
        _itemId = Guid.NewGuid();
        _itemType = ItemTypes.TRAMPOLINE;
    }
}
