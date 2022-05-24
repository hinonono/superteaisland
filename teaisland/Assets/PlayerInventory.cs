using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public event Action onItemTouched;

    //當Player離開道具偵測區域時會觸發的event
    public event Action onItemExited;

    public event onItemPickedDelegate onItemPicked;
    public delegate void onItemPickedDelegate(int f);

    public InventoryObject inventory;
    public GameObject teaItemPopup;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            teaItemPopup.SetActive(true);
            onItemTouched?.Invoke();

            //inventory.AddItem(new Item(item.item), 1);

            //onItemPicked?.Invoke(25);

            //Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //onItemExited?.Invoke();
    }

    private void Update()
    {

    }

    private void OnApplicationQuit()
    {
        inventory.Container.Items.Clear();
    }
}
