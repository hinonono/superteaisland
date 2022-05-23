using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallDetecter : MonoBehaviour
{

    private GameObject alert;
    private string alertText;

    private void Awake()
    {
        if (!GameObject.Find("Alert"))
        {
            Debug.Log("Cannot find alert in scene.");
        }

        alert = GameObject.Find("Alert");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        alertText = "You are about to cross the boundry of the scene.";
        alert.GetComponentInChildren<TextMeshProUGUI>().text = alertText;
    }
}
