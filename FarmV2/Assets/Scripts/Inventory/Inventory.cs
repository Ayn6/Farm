using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Start()
    {
        items.Add(items[0]);
    }

    //public static void CheckWhithOutExist(Item item)
    //{
    //    bool exist = false;
    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        if (item.name == items[i].name)
    //        {
    //            items[i].count += item.count;
    //            exist = true;
    //            break;
    //        }
    //    }
    //    if (!exist)
    //    {
    //        addItemToInventory(item);
    //    }
    //}
    //private static void addItemToInventory(Item item)
    //{
    //    bool added = false;
    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        if (items[i].name == "empty")
    //        {
    //            items[i] = item;
    //            added = true;
    //            break;
    //        }
    //    }
    //    if (!added)
    //    {
    //        items.Add(item);
    //    }
    //}

}
