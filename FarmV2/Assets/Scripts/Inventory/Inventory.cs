using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Item> items = new List<Item>();

    public void CheckIfItemExist(SpriteRenderer item)
    {

        for (int i = 0; i < items.Count; i++)
        {
            if(item.sprite == items[i].sprite)
            {
                items[i].count += 2;
                break;
            }
            else if(items[i].name == "Empty")
            {
                item.sprite = items[i].sprite;
                items[i].count += 2;
            }
        }
    }

    public void AddItemToInventory(Item item)
    {
        item.count++;   
        items.Add(item);
    }

}
