using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeapotProgress : MonoBehaviour
{
    private PlayerInventory playerInventory;
    public int currentProgress = 0;
    private TextMeshProUGUI progressText;

    void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        playerInventory.onItemPicked += PlayerInventory_onItemPicked;
        progressText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void PlayerInventory_onItemPicked(string itemName, int quantity)
    {
        UpdateTeaportProgress(quantity);
    }

    private void UpdateTeaportProgress(int increase)
    {
        if (currentProgress >= 100)
        {
            return;
        }

        currentProgress += increase;
        progressText.text = currentProgress.ToString();
        //Debug.Log("currentProgress = " + currentProgress);
    }
}
