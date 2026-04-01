using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform slotsParent;
    public GameObject slotPrefab;

    private Image[] icons;
    private Text[] amounts;

    void Start()
    {
        int size = inventory.slots.Length;

        icons = new Image[size];
        amounts = new Text[size];

        for (int i = 0; i < size; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotsParent);
            icons[i] = slot.transform.Find("Icon").GetComponent<Image>();
            amounts[i] = slot.transform.Find("Amount").GetComponent<Text>();
        }
    }

    void Update()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            var slot = inventory.slots[i];

            if (slot.IsEmpty)
            {
                icons[i].enabled = false;
                amounts[i].text = "";
            }
            else
            {
                icons[i].enabled = true;
                icons[i].sprite = slot.item.icon;

                amounts[i].text = slot.item.stackable
                    ? slot.amount.ToString()
                    : "";
            }
        }
    }
}
