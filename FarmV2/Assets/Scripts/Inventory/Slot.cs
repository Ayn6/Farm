using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Image itemImage;
    private Text count;
   public void FillSlot(Item item)
    {
        itemImage = GetComponentsInChildren<Image>()[1];
        count = GetComponentInChildren<Text>();

        if (item.count > 0) count.text = "x" + item.count.ToString();
        else count.text = "";
        itemImage.sprite = item.sprite;
    }
}
