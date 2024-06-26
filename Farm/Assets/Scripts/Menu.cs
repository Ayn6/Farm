using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject inventoryPrefab;
    public GameObject deskPrefab;
    public GameObject shopPrefab;

    public bool inventoryOpened;
    public bool deskOpened;
    public bool shopOpened;
    private GameObject inventory;
    private GameObject desk;
    private GameObject shop;

    public void openInventory()
    {
        if (deskOpened)
        {
            Destroy(desk);
            deskOpened = false;
        }
        else if (shopOpened)
        {
            Destroy(shop);
            shopOpened = false;
        }
        else
        {
            if (inventoryOpened)
            {
                Destroy(inventory);
                inventoryOpened = false;
            }
            else
            {
                inventory = Instantiate(inventoryPrefab);
                inventory.transform.SetParent(gameObject.transform);
                inventory.GetComponent<RectTransform>().offsetMin = new Vector2(-695, -341);
                inventory.GetComponent<RectTransform>().offsetMax = new Vector2(8, -62);
                inventory.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                inventoryOpened = true;
            }
        }
    }
    public void openShop()
    {
        if (!inventoryOpened && !deskOpened && !shopOpened)
        {
            shop = Instantiate(shopPrefab);
            shop.transform.SetParent(gameObject.transform);
            shop.GetComponent<RectTransform>().offsetMin = new Vector2(-695, -341);
            shop.GetComponent<RectTransform>().offsetMax = new Vector2(-100, -50);
            shop.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            shopOpened = true;
        }
    }
    public void openDesk()
    {
        if (!inventoryOpened && !deskOpened && !shopOpened)
        {
            desk = Instantiate(deskPrefab);
            desk.transform.SetParent(gameObject.transform);
            desk.GetComponent<RectTransform>().offsetMin = new Vector2(-695, -341);
            desk.GetComponent<RectTransform>().offsetMax = new Vector2(-100, -50);
            desk.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            deskOpened = true;
        }
    }
}
