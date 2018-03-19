using System;
using UnityEngine;

public enum ItemTypes {
    BALL,
    FAN,
    METAL_PLANK,
    RAMP,
    TRAMPOLINE,
    ANTI_GRAV_FIELD_GEN
}
public interface IItem {
    Guid ItemId { get; }
    ItemTypes ItemType { get; }
    String ItemName { get; set; }
    ItemIcon3d ItemIcon3d { get; set; }
}
