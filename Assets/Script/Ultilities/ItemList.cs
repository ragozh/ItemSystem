using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class ItemList : ScriptableObject
{
    public List<Item> database;
    
    public void AddItem(Item item){
        database.Add(item);
    }
    
    public void RemoveItemById(string id)
    {
        Item itemRemoving =  database.Where(x => x.Id == id).FirstOrDefault();
        if (itemRemoving != null)
        {
            database.Remove(itemRemoving);
        }
    }

    public Item GetItemById(string id)
    {
        return database.Where(x => x.Id == id).FirstOrDefault();
    }
}