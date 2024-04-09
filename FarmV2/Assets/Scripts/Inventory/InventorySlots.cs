using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySlots : MonoBehaviour
{
    private List<Slot> slots = new List<Slot>();
    public Inventory Item;

    private void Start()
    {
        slots = GetComponentsInChildren<Slot>().ToList();

        int i = 0;

        foreach (Slot slot in slots)
        {
            slot.FillSlot(Item.items[i]);
            i++;
        }
    }
}
