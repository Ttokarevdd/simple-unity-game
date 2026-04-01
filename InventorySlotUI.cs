using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IPointerClickHandler
{
    public int index;
    public InventoryUI ui;

    public void OnPointerClick(PointerEventData eventData)
    {
        ui.OnSlotClicked(index);
    }
}
