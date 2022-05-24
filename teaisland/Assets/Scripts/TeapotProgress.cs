using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeapotProgress : MonoBehaviour
{
    private PlayerInventory playerInventory;

    void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        playerInventory.onItemPicked += PlayerInventory_onItemPicked;
    }

    private void PlayerInventory_onItemPicked(int f)
    {
        UpdateTeaportProgress(f);
    }

    private void UpdateTeaportProgress(int f)
    {
        Debug.Log("UI Updated!" + f);
    }
}
