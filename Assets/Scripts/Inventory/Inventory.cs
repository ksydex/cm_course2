using System.Collections;
using System.Collections.Generic;
using Common;
using JetBrains.Annotations;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public LevelControllerBase levelController;
    public List<string> isFull;
    public GameObject[] slots;
    public GameObject inventory;
    private bool inventoryOn;

    private void Start()
    {
        inventoryOn = false;
    }

    public void Chest()
    {
        if (inventoryOn == false)
        {
            inventoryOn = true;
            inventory.SetActive(true);
        }
        else if (inventoryOn == true)
        {
            inventoryOn = false;
            inventory.SetActive(false);
        }
    }

    public void OnChange()
    {
        levelController.OnInventoryChange();
    }
}