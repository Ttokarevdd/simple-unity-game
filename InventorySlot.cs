using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public ItemData item;
    public int amount;

    public bool IsEmpty => item == null;

    public bool CanStack(ItemData newItem)
    {
        return item != null &&
               item == newItem &&
               item.stackable &&
               amount < item.maxStack;
    }

    public void AddItem(ItemData newItem, int value)
    {
        item = newItem;
        amount += value;
    }

    public void Remove(int value)
    {
        amount -= value;
        if (amount <= 0)
        {
            item = null;
            amount = 0;
        }
    }
}
