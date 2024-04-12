using UnityEngine;
using UnityEngine.UI;
using DefaultNamespace;

public class Slot : MonoBehaviour
{
    private Image itemImage;
    private Text count;
    public Sprite newSprite; 
    public Inventory Item;
    public Item Empty;

    public void FillSlot(ItemInstance item)
    {
        itemImage = GetComponentsInChildren<Image>()[1];
        count = GetComponentInChildren<Text>();

        if (item == null || (item != null && item.count <= 0))
        {
            count.text = "";
            itemImage.sprite = newSprite;
        }
        else
        {
            count.text = "x" + item.count.ToString();
            itemImage.sprite = item.item.sprite;
        };

    }

}
