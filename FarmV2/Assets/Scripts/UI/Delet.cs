using UnityEngine;
using UnityEngine.UI;


public class Delet : MonoBehaviour
{
    private UnityEngine.UI.Image itemImage;
    public Sprite newSprite;
    public Inventory Item;
    public Item Empty;
    [SerializeField] private InventorySlots InventorySlots;
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
        Item.items[index] = null;
        
        InventorySlots.Restart();
        
    }
}
