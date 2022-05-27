using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintArea : MonoBehaviour
{
    [TextArea(5, 10)]
    public string hintText;

    public event onHintAreaTouchedDelegate onHintAreaTouched;
    public delegate void onHintAreaTouchedDelegate(string text);

    private void OnTriggerEnter(Collider other)
    {
        if (hintText != null)
        {
            onHintAreaTouched?.Invoke(hintText);
            Debug.Log("wfe");
        } else
        {
            Debug.Log("Please set the text of the hint area.");
        }
    }
}
