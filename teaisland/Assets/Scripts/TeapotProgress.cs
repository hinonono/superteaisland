using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeapotProgress : MonoBehaviour
{
    private PlayerInventory playerInventory;

    void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        playerInventory.onItemPicked += PlayerInventory_onItemPicked1;
    }

    private void PlayerInventory_onItemPicked1(int f)
    {
        UpdateUI(f);
    }

    private void UpdateUI(int f)
    {
        Debug.Log("UI Updated!" + f);
    }
}
