using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class InventorySlots : MonoBehaviour
{
    private List<Slot> slots = new List<Slot>();
    public Inventory Item;


    private void Start()
    {
        Restart();
    }
    
    public void Restart()
    {
        slots = GetComponentsInChildren<Slot>().ToList();

        for (var idx = 0; idx < slots.Count; idx++)
        {
            var slot = slots[idx];
            if (idx < Item.items.Count)
            {
                slot.FillSlot(Item.items[idx]);
            }
            else
            {
                slot.FillSlot(null);
            }
        }

    }

}
