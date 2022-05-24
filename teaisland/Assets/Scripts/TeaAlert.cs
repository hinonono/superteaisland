using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeaAlert : MonoBehaviour
{
    private GameObject[] walls;
    private TextMeshProUGUI alertText;

    private void Start()
    {
        alertText = GetComponentInChildren<TextMeshProUGUI>();

        walls = GameObject.FindGameObjectsWithTag("Wall");
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].GetComponent<WallDetecter>().onWallTouched += WallDetecter_onWallTouched;
        }
    }

    private void WallDetecter_onWallTouched(object sender, EventArgs e)
    {
        alertText.text = "You are about to cross the boundry of the scene.";
    }
}
