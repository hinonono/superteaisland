using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Equipment,
    Default
}

public enum Attributes
{
    Agility,
    Intellect,
    Stamina,
    Strength
}

public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(5, 10)]
    public string itemName;

    //will be deprecated
    //[TextArea(5, 10)]
    //public string description;

    [TextArea(2, 10)]
    public string flavor;
    [TextArea(2, 10)]
    public string effect;
    [TextArea(2, 10)]
    public string coordination;



    public ItemBuff[] buffs;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public ItemBuff[] buffs;

    public string flavor;
    public string effect;
    public string coordination;

    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.Id;

        flavor = item.flavor;
        effect = item.effect;
        coordination = item.coordination;

        buffs = new ItemBuff[item.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.buffs[i].min, item.buffs[i].max)
            {
                attribute = item.buffs[i].attribute
            };
        }
    }
}

[System.Serializable]
public class ItemBuff
{
    public Attributes attribute;
    public int value;
    public int min;
    public int max;
    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValue();
    }

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}
