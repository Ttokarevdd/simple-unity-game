using UnityEngine;

public enum ItemType
{
    Weapon,
    Consumable,
    Ammo,
    Other
}

[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType type;
    public Sprite icon;

    public bool stackable;
    public int maxStack = 1;
}
