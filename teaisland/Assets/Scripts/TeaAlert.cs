using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeaAlert : MonoBehaviour
{
    private GameObject[] walls;
    private GameObject[] hintAreas;
    private TextMeshProUGUI alertText;
    public bool findHintArea;

    private PlayerInventory playerInventory;

    private void Start()
    {
        alertText = GetComponentInChildren<TextMeshProUGUI>();

        walls = GameObject.FindGameObjectsWithTag("Wall");

        if (findHintArea)
        {
            Debug.Log("Tea Alert will search for HintArea in the scene now.");
            hintAreas = GameObject.FindGameObjectsWithTag("HintArea");
            if (hintAreas == null)
            {
                Debug.Log("hintAreas array is empty");
            }
            else
            {
                for (int i = 0; i < hintAreas.Length; i++)
                {
                    hintAreas[i].GetComponent<HintArea>().onHintAreaTouched += HintArea_onHintAreaTouched;
                }
            }
        }
        

        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].GetComponent<WallDetecter>().onWallTouched += WallDetecter_onWallTouched;
        }

        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        playerInventory.onItemPicked += PlayerInventory_onItemPicked;
    }

    private void WallDetecter_onWallTouched(object sender, EventArgs e)
    {
        alertText.text = "You are about to cross the boundry of the scene.";
    }

    private void HintArea_onHintAreaTouched(string text)
    {
        alertText.text = text;
    }

    private void PlayerInventory_onItemPicked(string itemName, int quantity)
    {
        alertText.text = itemName + " * " + quantity + " has added to your inventory!";
    }

    private void OnDisable()
    {
        //for (int i = 0; i < walls.Length; i++)
        //{
        //    walls[i].GetComponent<WallDetecter>().onWallTouched -= WallDetecter_onWallTouched;
        //}
    }

    private void OnDestroy()
    {
        if (findHintArea)
        {
            for (int i = 0; i < hintAreas.Length; i++)
            {
                hintAreas[i].GetComponent<HintArea>().onHintAreaTouched -= HintArea_onHintAreaTouched;
            }
        }

    }
}
