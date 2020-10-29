using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public ItemList itemList;
    GameObject inventoryPanel;
    GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    private int slotAmount;
    public ItemList inventoryItems; // list item in inventory
    public GameObjectList inventorySlots; // list slot of above items

    private void Start()
    {
        inventoryItems.database = new List<Item>();
        inventorySlots.listData = new List<GameObject>();
        slotAmount = 12;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = GameObject.Find("Slot Panel");
        for (int i = 0; i < slotAmount; i++)
        {
            inventoryItems.AddItem(new Item());
            inventorySlots.listData.Add(Instantiate(inventorySlot));
            inventorySlots.listData[i].GetComponent<SlotController>().index = i;
            inventorySlots.listData[i].transform.SetParent(slotPanel.transform);
            inventorySlots.listData[i].name = "slot" + (i + 1);
        }
        AddItem("c973ee37-0c41-4728-930b-f1e391f8e01a");
        AddItem("1640aa26-9aa3-4497-9493-edfbac028152");
        AddItem("1640aa26-9aa3-4497-9493-edfbac028152", 5);
    }

    public void AddItem(string itemId, int itemAmount = 1)
    {
        Item itemToAdd = itemList.GetItemById(itemId);
        if (itemToAdd == null) return;
        if (itemToAdd.Stackable && IsInInventory(itemToAdd))
        {
            for (int i = 0; i < inventoryItems.Size(); i++)
            {
                if (inventoryItems.GetByIndex(i).Id == itemId)
                {
                    ItemController controller = inventorySlots.listData[i].transform.GetChild(0).GetComponent<ItemController>();
                    controller.amount += itemAmount;
                    controller.transform.GetChild(0).GetComponent<Text>().text = controller.amount.ToString();
                }
            }
        } 
        else
        {
            for (int i = 0; i < inventoryItems.Size(); i++)
            {
                if (inventoryItems.GetByIndex(i).Id == "-1")
                {
                    inventoryItems.SetByIndex(i, itemToAdd);
                    GameObject itemObj = Instantiate(inventoryItem);
                    ItemController itemController = itemObj.GetComponent<ItemController>();
                    itemController.item = itemToAdd;
                    itemController.slotIndex = i;
                    itemObj.transform.SetParent(inventorySlots.listData[i].transform);
                    itemObj.transform.position = Vector2.zero; // center relative
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Icon;
                    itemObj.name = itemToAdd.Name;
                    break;
                }
            }
        }        
    }

    public void RemoveItem(string itemId, int itemAmount = 1)
    {

    }

    private bool IsInInventory(Item item) => inventoryItems.Contains(item);
}
