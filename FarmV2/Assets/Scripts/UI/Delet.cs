using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class Delet : MonoBehaviour
{
    private UnityEngine.UI.Image itemImage;
    public Sprite newSprite;
    public Inventory Item;
    public Item Empty;
    private InventorySlots InventorySlots;
    private Text count;
    public void Del()
    {

        Transform parent = transform.parent;
        Transform firstChild = parent.GetChild(0);
        int index = parent.GetSiblingIndex();

        itemImage = firstChild.GetComponent<UnityEngine.UI.Image>();
        count = parent.GetComponentInChildren<Text>();
        
        itemImage.sprite = newSprite;
        count.text = "";
        Item.items[index] = Empty;
        Item.items[index].count = 0;
        
        InventorySlots.Restart();
        
    }
}
