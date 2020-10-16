using System.Collections;
using System.Collections.Generic;
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
    public List<Item> items = new List<Item>(); // list item in inventory
    public List<GameObject> slots = new List<GameObject>(); // list slot of above items

    private void Start()
    {
        slotAmount = 12;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = GameObject.Find("Slot Panel");
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
            slots[i].name = "slot" + (i + 1);
        }
        AddItem("c973ee37-0c41-4728-930b-f1e391f8e01a");
        AddItem("1640aa26-9aa3-4497-9493-edfbac028152");
    }

    public void AddItem(string itemId)
    {
        Item itemToAdd = itemList.GetItemById(itemId);
        if (itemToAdd == null) return;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == "-1")
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.transform.position = Vector2.zero; // center relative
                itemObj.GetComponent<Image>().sprite = itemToAdd.Icon;
                itemObj.name = itemToAdd.Name;
                break;
            }
        }
    }
}
