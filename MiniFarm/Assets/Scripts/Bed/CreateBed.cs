using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBed : MonoBehaviour
{
    public GameObject player;
    public GameObject gardenPrefab;
    public float distance = 2f;

    private GameObject currentGarden;
    private bool canPlant = true;

    [SerializeField] private Inventory playerInventory;
    private bool followPlayerPosition = true;

    private void FixedUpdate()
    {
        if (currentGarden == null && playerInventory.inventory[0].item.type == Item.TYPESHAVE)
        {
            Vector3 spawnPosition = player.transform.position + player.transform.forward * distance;
            currentGarden = Instantiate(gardenPrefab, spawnPosition, Quaternion.identity);
            SetGardenColor(currentGarden, Color.green);
        }

        if (followPlayerPosition && currentGarden != null && playerInventory.inventory[0].item.type == Item.TYPESHAVE)
        {
            currentGarden.transform.position = player.transform.position + player.transform.forward * distance;
        }
        if(playerInventory.inventory[0].item.type != Item.TYPESHAVE)
        {
            Destroy(currentGarden);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (currentGarden != null && (other.CompareTag("Shop") || other.CompareTag("Desk") || other.CompareTag("Bed")) && playerInventory.inventory[0].item.type == Item.TYPESHAVE)
        {
            SetGardenColor(currentGarden, Color.red);
            canPlant = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (currentGarden != null && (other.CompareTag("Shop") || other.CompareTag("Desk") || other.CompareTag("Bed")) && playerInventory.inventory[0].item.type == Item.TYPESHAVE)
        {
            SetGardenColor(currentGarden, Color.green);
            canPlant = true;
        }
    }

    public void Do()
    {
        if (canPlant && playerInventory.inventory[0].item.type == Item.TYPESHAVE)
        {
            SetGarden();
            Destroy(currentGarden);
        }

    }
    private void SetGardenColor(GameObject garden, Color color)
    {
        Renderer gardenRenderer = garden.GetComponent<Renderer>();
        if (gardenRenderer != null)
        {
            gardenRenderer.material.color = color;
        }
    }
    private void SetGarden()
    {
        if (currentGarden != null && canPlant)
        { 
            SetGardenColor(currentGarden, Color.white);
            currentGarden = Instantiate(gardenPrefab, currentGarden.transform.position, Quaternion.identity);
           
            playerInventory.inventory[0].count--;

        }
        if (playerInventory.inventory[0].count <= 0)
        {
            playerInventory.inventory.RemoveAt(0);
            currentGarden = null;
        }
    }
}
