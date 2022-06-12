using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDetecter : MonoBehaviour
{
    private InventoryObject playerInventory;

    private void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>().inventory;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var i in playerInventory.Container.Items)
            {
                Debug.Log(i.item.Name);
            }
        }

        
    }
}
