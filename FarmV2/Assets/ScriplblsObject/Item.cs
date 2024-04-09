using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public static int TYPEFOOD = 1;

    public string name = "Item";
    public Sprite sprite = null;
    public int type = 1;
    public int count = 1;
    public int price = 1;
    public int lvlOpen = 1;
    public float time = 5f;

}
