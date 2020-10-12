
using System;
using System.Collections.Generic;
using UnityEngine;
public class Items
{
    public string Id { get; private set; }
    public string Name { get; set; }
    public int Type { get; set; }
    public int Rarity { get; set; }
    public string Description { get; set; }
    //public Sprite Icon { get; set; }
    public Dictionary<string, float> Stats = new Dictionary<string, float>();
    public List<ItemData> Modifier = new List<ItemData>();
    public Items()
    {}
    public Items(string id, string name, int type, int rarity, string description, //Sprite icon, 
                Dictionary<string, float> stats, List<ItemData> modifier)
    {
        this.Id = id;
        this.Name = name;
        this.Type = type;
        this.Rarity = rarity;
        this.Description = description;
        //this.Icon = icon;
        this.Stats = stats;
        this.Modifier = modifier;
    }
    public Items(Items item)
    {
        this.Id = item.Id;
        this.Name = item.Name;
        this.Type = item.Type;
        this.Rarity = item.Rarity;
        this.Description = item.Description;
        //this.Icon = item.Icon;
        this.Stats = item.Stats;
        this.Modifier = item.Modifier;
    }
}

public class ItemData
{
    public string Name { get; set; }
    public Dictionary<string, float> Data = new Dictionary<string, float>();
    // public ItemData(string name, Dictionary<string, float> data)
    // {
    //     this.Name = name;
    //     this.Data = data;
    // }
    public void setData (Dictionary<string, float> data)
    {
        this.Data = data;
    }

    public Dictionary<string, float> getData ()
    {
        return this.Data;
    }
}
