using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private List<ShopItem> allItems = new List<ShopItem>();
    private List<Item> allProductList = new List<Item>();
    private Text moneyText;

    void Start()
    {
        moneyText = GetComponentsInChildren<Text>()[0];
        moneyText.text = Player.money + "$";

        allItems = gameObject.GetComponentsInChildren<ShopItem>().ToList();

        fillAllProducts();
        StartCoroutine(fillShop());
    }

    private IEnumerator fillShop()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < allItems.Count; i++)
        {
            allItems[i].UpdateItem(allProductList[i], moneyText);
        }
    }

    private void fillAllProducts()
    {
        allProductList.Clear();
        allProductList.Add(new Item("carrot", "Produckts/carrot", 1, Item.TYPEPFOOD, 10, 1, 5f));
        allProductList.Add(new Item("pear", "Produckts/Pear", 1, Item.TYPEPFOOD, 10, 1, 10f));
        allProductList.Add(new Item("banana", "Produckts/banana", 1, Item.TYPEPFOOD, 10, 2, 60f));
        allProductList.Add(new Item("pumpkin", "Produckts/pumpkin1", 1, Item.TYPEPFOOD, 10, 3, 20f));
        
    }

}