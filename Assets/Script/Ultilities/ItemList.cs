using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class ItemList : ScriptableObject
{
    public List<Item> database;
    
    public void AddItem(Item item) => database.Add(item);    
    
    public void RemoveItemById(string id)
    {
        Item itemRemoving =  database.Where(x => x.Id == id).FirstOrDefault();
        if (itemRemoving != null)
        {
            database.Remove(itemRemoving);
        }
    }

    public Item GetItemById(string id) => database.Where(x => x.Id == id).FirstOrDefault();
    public bool Contains(Item item) => database.Contains(item);
    public bool ContainsById(string itemId) => database.Any(item => item.Id == itemId);
    public int Size() => database.Count;
    public Item GetByIndex(int index) => database[index];
    public void SetByIndex(int index, Item item) => database[index] = item;
}