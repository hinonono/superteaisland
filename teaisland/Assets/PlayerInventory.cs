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

    //專門儲存遇到了什麼item
    private GroundItem ItemMeeted;

    private void Start()
    {
        //訂閱popup的確認和取消event
        teaItemPopup.GetComponent<TeaItemPopup>().onConfirmPressed += TeaItemPopup_onConfirmPressed;
        teaItemPopup.GetComponent<TeaItemPopup>().onCancelPressed += TeaItemPopup_onCancelPressed;
    }

    private void OnTriggerEnter(Collider other)
    {
        teaItemPopup.SetActive(true);
        onItemTouched?.Invoke();


        //設定為遇到的item
        ItemMeeted = other.GetComponent<GroundItem>();
    }

    private void OnTriggerExit(Collider other)
    {
        onItemExited?.Invoke();
    }

    private void Update()
    {

    }

    private void TeaItemPopup_onConfirmPressed()
    {
        Debug.Log("ewfiwjfo");
        if (ItemMeeted)
        {
            inventory.AddItem(new Item(ItemMeeted.item), 1);
            onItemPicked?.Invoke(25);
        }
    }

    private void TeaItemPopup_onCancelPressed()
    {

    }

    private void OnApplicationQuit()
    {
        inventory.Container.Items.Clear();
    }

    private void OnDisable()
    {
        if(teaItemPopup != null)
        {
            teaItemPopup.GetComponent<TeaItemPopup>().onConfirmPressed -= TeaItemPopup_onConfirmPressed;
            teaItemPopup.GetComponent<TeaItemPopup>().onCancelPressed -= TeaItemPopup_onCancelPressed;
        }   
    }
}
