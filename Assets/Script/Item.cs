
using System;
using System.Collections.Generic;
using UnityEngine;
public class Item
{
    public string Id { get; private set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public int Type { get; set; }
    public int Rarity { get; set; }
    public string Description { get; set; }
    public Sprite Icon { get; set; }
    public Dictionary<string, float> Stats = new Dictionary<string, float>();
    public List<ItemModifiers> Modifier = new List<ItemModifiers>();
    public Item()
    {
        this.Id = "-1";
    }
    public Item(string id, string name, string slug, int type, int rarity, string description, //Sprite icon, 
                Dictionary<string, float> stats, List<ItemModifiers> modifier)
    {
        this.Id = id;
        this.Name = name;
        this.Slug = slug;
        this.Type = type;
        this.Rarity = rarity;
        this.Description = description;
        this.Stats = stats;
        this.Modifier = modifier;
    }
    public Item(Item item)
    {
        this.Id = item.Id;
        this.Name = item.Name;
        this.Slug = item.Slug;
        this.Type = item.Type;
        this.Rarity = item.Rarity;
        this.Description = item.Description;
        //this.Icon = item.Icon;
        this.Stats = item.Stats;
        this.Modifier = item.Modifier;
    }

    public void UpdateIcon()
    {        
        this.Icon = Resources.Load<Sprite>("Image/Items/" + this.Slug);
    }
}

public class ItemModifiers
{
    public string Name { get; set; }
    public Dictionary<string, float> Modifiers = new Dictionary<string, float>();
    public void setModifiers (Dictionary<string, float> modifiers)
    {
        this.Modifiers = modifiers;
    }

    public Dictionary<string, float> getData ()
    {
        return this.Modifiers;
    }
}
