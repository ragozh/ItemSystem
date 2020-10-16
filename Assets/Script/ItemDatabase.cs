using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class ItemDatabase : MonoBehaviour
{
    public ItemList itemList;
    private JsonData itemData;

    private void Start() 
    {
        // itemData = JsonMapper.ToObject(
        //     File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemDatabase.json")
        // );
        ConstructDatabaseFromJson();
    }

    private void ConstructDatabaseFromJson()
    {
        itemList.database = JsonMapper.ToObject<List<Item>>(
            File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemDatabase.json")
        );
        foreach (Item item in itemList.database)
        {
            if (item.Icon == null) 
                item.UpdateIcon();
        }
    }
}
