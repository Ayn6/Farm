using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Link", menuName = "Link")]
public class Links : ScriptableObject
{
    public GameObject player;
    public PlayerInformation playerInformation;
    public Inventory playerInventory;
}
