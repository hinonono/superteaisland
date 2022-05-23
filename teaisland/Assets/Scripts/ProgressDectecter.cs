using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressDectecter : MonoBehaviour
{
    private int progress = 0;
    public GameObject player;

    private void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = progress.ToString();
    }

    private void Update()
    {
        UpdateProgress();
    }

    private void UpdateProgress()
    {

    }
}
