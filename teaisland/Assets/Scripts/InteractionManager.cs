using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{

    public InteractionType interactionType = new InteractionType();

    public float animateSpeed = 0.5f;
    public GameObject popup;
    public Transform box;
    public CanvasGroup background;
    public Text areaName;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered == false)
        {
            popup.SetActive(true);
            background.alpha = 0;
            background.LeanAlpha(1, animateSpeed);

            box.localPosition = new Vector2(0, -Screen.height);
            box.LeanMoveLocalY(0, animateSpeed).setEaseOutExpo().delay = 0.1f;

            Debug.Log("eejgoiwj");
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //background.LeanAlpha(0, animateSpeed);
        //box.LeanMoveLocalY(-Screen.height, animateSpeed).setEaseInExpo().setOnComplete(onComplete);
    }

    void onComplete()
    {
        popup.SetActive(false);
    }
}

public enum InteractionType
{
    tea,
    topping
}
