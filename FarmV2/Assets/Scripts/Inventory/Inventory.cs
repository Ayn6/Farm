using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<ItemInstance> items = new List<ItemInstance>();

    public bool TryAddItem(ItemInstance item, int count = 1)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if(item.item == items[i].item)
            {
                items[i].count += count;
                return true;
            }
            if (items[i].item == null )
            {
                items[i] = item;
                return true;
            }
        }
        
        // Нужно какое-то ограничение на размер инвентаря ( если надо)
        // А то можно делать вот такое:
        items.Add(item);
        // и инвентарь станет резиновым)))

        return false;
    }


}
