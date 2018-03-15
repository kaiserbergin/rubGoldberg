using System;

public enum ItemTypes {
    BALL,
    FAN,
    METAL_PLANK,
    RAMP,
    TRAMPOLINE,
    ANTI_GRAV_FIELD_GEN
}
public interface IItem {
    Guid _itemId { get; }
    ItemTypes _itemType { get; }
}
