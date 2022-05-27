using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallDetecter : MonoBehaviour
{
    public event EventHandler onWallTouched;

    private void OnTriggerEnter(Collider other)
    {
        //alertText = "You are about to cross the boundry of the scene.";
        //alert.GetComponentInChildren<TextMeshProUGUI>().text = alertText;

        onWallTouched?.Invoke(this, EventArgs.Empty);
    }
}
