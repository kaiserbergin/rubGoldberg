public class InventorySlot {
    public IItem _item;
    public int _count;

    public InventorySlot(IItem item, int count) {
        _item = item;
        _count = count;
    }

    public void AddCount(int count) {
        _count += count;
    }

    public void RemoveCount(int count) {
        _count -= count;
    }
}
