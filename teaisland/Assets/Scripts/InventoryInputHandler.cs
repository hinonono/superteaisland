using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInventory))]
public class InventoryInputHandler : MonoBehaviour
{
    //這個script專門handle inventory部分的input

    private Player playerInput;
    private PlayerInventory playerInventory;

    private void Awake()
    {
        playerInput = new Player();

        playerInventory = GetComponent<PlayerInventory>();
    }

    private void OnEnable()
    {
        playerInput.Inventory.SaveInventory.performed += DoSave;
        playerInput.Inventory.SaveInventory.Enable();

        playerInput.Inventory.LoadInventory.performed += DoLoad;
        playerInput.Inventory.LoadInventory.Enable();
    }

    private void OnDisable()
    {
        playerInput.Inventory.SaveInventory.Disable();
        playerInput.Inventory.LoadInventory.Disable();
    }

    private void DoSave(InputAction.CallbackContext obj)
    {
        playerInventory.inventory.Save();
        Debug.Log("inventory saved!");
    }

    private void DoLoad(InputAction.CallbackContext obj)
    {
        playerInventory.inventory.Load();
        Debug.Log("inventory loaded!");

    }

}
