using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;
using System.Linq;

public class ItemDatabase : MonoBehaviour
{
    private List<Items> database = new List<Items>();
    private JsonData itemData;

    private void Start() 
    {
        // itemData = JsonMapper.ToObject(
        //     File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemDatabase.json")
        // );
        ConstructDatabaseFromJson();
    }

    public Items GetItemById(string id)
    {
        return database.Where(x => x.Id == id).FirstOrDefault();
    }

    private void ConstructDatabaseFromJson()
    {
        database = JsonMapper.ToObject<List<Items>>(
            File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemDatabase.json")
        );
    }
}
