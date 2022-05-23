using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public event onItemPickedDelegate onItemPicked;
    public delegate void onItemPickedDelegate(int f);

    public InventoryObject inventory;

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            inventory.AddItem(new Item(item.item), 1);

            onItemPicked?.Invoke(25);
            //Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    inventory.Save();
        //}

        //if (Input.GetKeyDown(KeyCode.KeypadEnter))
        //{
        //    inventory.Load();
        //}
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Items.Clear();
    }
}
