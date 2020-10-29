using UnityEngine;
using UnityEngine.EventSystems;

public class SlotController : MonoBehaviour, IDropHandler
{
    public int index;
    //private Inventory inventory;
    public ItemList inventoryItems;
    public GameObjectList inventorySlots;
    //private void OnEnable() => inventory = GameObject.Find("InventorySystem").GetComponent<Inventory>();
    public void OnDrop(PointerEventData eventData)
    {
        ItemController droppedItemController = eventData.pointerDrag.GetComponent<ItemController>();
        if (inventoryItems.GetByIndex(index).Id != "-1")
        {
            ItemController swapedItemController = this.GetComponentInChildren<ItemController>();
            GameObject dropppedItemSlot = inventorySlots.listData[droppedItemController.slotIndex];
            swapedItemController.transform.SetParent(dropppedItemSlot.transform);
            swapedItemController.transform.position = dropppedItemSlot.transform.position;
            swapedItemController.slotIndex = droppedItemController.slotIndex;
        }
        SwapInventoryItem(index, droppedItemController.slotIndex);
        droppedItemController.transform.SetParent(this.transform);
        droppedItemController.transform.position = this.transform.position;
        droppedItemController.slotIndex = index;
        
    }

    private void SwapInventoryItem(int index1, int index2)
    {
        if (index1 != index2)
        {
            Item temp = inventoryItems.GetByIndex(index1);
            inventoryItems.SetByIndex(index1, inventoryItems.GetByIndex(index2));
            inventoryItems.SetByIndex(index2, temp);
        }
    }
}
