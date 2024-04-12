using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour
{
    private Image itemImage;
    private Text count;
    public Sprite newSprite; 
    public Inventory Item;
    public Item Empty;

    public void FillSlot(Item item)
    {
        itemImage = GetComponentsInChildren<Image>()[1];
        count = GetComponentInChildren<Text>();

        if (item.count > 0)
        {
            count.text = "x" + item.count.ToString();
            itemImage.sprite = item.sprite;
        }
        else if(item.count <= 0)
        {
            count.text = "";
            itemImage.sprite = newSprite;
        };

    }

}
