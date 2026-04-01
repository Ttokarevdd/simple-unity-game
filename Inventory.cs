using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int size = 16;
    public InventorySlot[] slots;

    private void Awake()
    {
        slots = new InventorySlot[size];
        for (int i = 0; i < size; i++)
            slots[i] = new InventorySlot();
    }

    public void AddItem(ItemData item, int amount = 1)
    {
        // Пытаемся стакать
        if (item.stackable)
        {
            foreach (var slot in slots)
            {
                if (slot.CanStack(item))
                {
                    slot.AddItem(item, amount);
                    return;
                }
            }
        }

        // Ищем пустой слот
        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.AddItem(item, amount);
                return;
            }
        }

        Debug.Log("Инвентарь заполнен!");
    }

    public void RemoveItem(int slotIndex, int amount = 1)
    {
        if (slotIndex < 0 || slotIndex >= slots.Length) return;

        if (!slots[slotIndex].IsEmpty)
            slots[slotIndex].Remove(amount);
    }
}
