using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static List<Item> items = new List<Item>();

    public static int lvl = 1;
    public static float lvlProgress = 0;
    public static float[] expMultiplier = new float[8];
    public static List<List<Item>> currentOrders = new List<List<Item>>();

    public static int money = 100;

    void Start()
    {
        currentOrders.Add(new List<Item>());
        currentOrders.Add(new List<Item>());

        items.Add(new Item("plow", "Tools/plow", 0, Item.TYPEPLOW, 0, 0, 0f));
        items.Add(new Item("plow", "Tools/plow", 0, Item.TYPEPLOW, 0, 0, 0f));
        items.Add(new Item("carrot", "Produckts/carrot", 3, Item.TYPEPFOOD, 10, 1, 5f));
        items.Add(new Item("pear", "Produckts/Pear", 3, Item.TYPEPFOOD, 10, 1, 10f));
        items.Add(getEmptyItem());
        items.Add(getEmptyItem());

        expMultiplier[1] = 0.4f;
        expMultiplier[2] = 0.3f;
        expMultiplier[3] = 0.3f;
        expMultiplier[4] = 0.2f;
        expMultiplier[5] = 0.2f;
        expMultiplier[6] = 0.1f;
        expMultiplier[7] = 0.1f;
    }

    public static void addExp(int exp)
    {
        lvlProgress += exp * expMultiplier[exp];

        if (lvlProgress >= 3)
        {
            lvl++;
            lvlProgress = 0;
        }
    }

    public static bool isEnoughItems(List<Item> required)
    {
        int itemsToComplete = required.Count;
        for (int i = 0; i < required.Count; i++)
        {
            foreach (Item item in items)
            {
                if (item.name == required[i].name)
                {
                    if (item.count >= required[i].count)
                    {
                        itemsToComplete--;
                    }
                }
            }
        }
        if (itemsToComplete == 0) return true;
        else return false;
    }

    public static void removeItemWithName(string name, int count)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == name)
            {
                if (items[i].count <= count)
                {
                    items[i] = getEmptyItem();
                }
                else
                {
                    items[i].count -= count;
                }
            }
        }
    }

    public static Item getHandItem()
    {
        return new Item(items[0].name, items[0].imgUrl, items[0].count, items[0].type, items[0].price, items[0].lvlWhenUnlock, items[0].timeToGrow);
    }

    public static Item getEmptyItem()
    {
        return new Item("empty", "Produckts/empty", 0, 0, 0, 0, 0);
    }

    public static void removeItem()
    {
        if (items[0].count == 1)
        {
            items[0] = getEmptyItem();
        }
        else
        {
            items[0].count -= 1;
        }
    }

    public static void checkIfItemExists(Item item)
    {
        bool exist = false;
        for (int i = 0; i < items.Count; i++)
        {
            if (item.name == items[i].name)
            {
                items[i].count += item.count;
                exist = true;
                break;
            }
        }
        if (!exist)
        {
            addItemToInventory(item);
        }
    }

    private static void addItemToInventory(Item item)
    {
        bool added = false;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == "empty")
            {
                items[i] = item;
                added = true;
                break;
            }
        }
        if (!added)
        {
            items.Add(item);
        }
    }
}