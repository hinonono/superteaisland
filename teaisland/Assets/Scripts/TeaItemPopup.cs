using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaItemPopup : MonoBehaviour
{
    //控制Pop出現與消失的速度
    public float animateSpeed = 0.5f;

    //自身相關元件
    public Transform box;
    public CanvasGroup background;

    private PlayerInventory playerInventory;

    private void OnEnable()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        playerInventory.onItemTouched += PlayerInventory_onItemTouched;
        playerInventory.onItemTouched += PlayerInventory_onItemExited;
        openPopup();
    }

    private void OnDestroy()
    {
        playerInventory.onItemTouched -= PlayerInventory_onItemTouched;
        playerInventory.onItemTouched -= PlayerInventory_onItemExited;
    }

    private void PlayerInventory_onItemTouched()
    {

    }

    private void PlayerInventory_onItemExited()
    {
        //closePopup();
        //gameObject.SetActive(false);
        
    }

    public void openPopup()
    {
        background.alpha = 0;
        background.LeanAlpha(1, animateSpeed);

        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, animateSpeed).setEaseOutExpo().delay = 0.1f;
    }

    public void closePopup()
    {
        background.LeanAlpha(0, animateSpeed);
        box.LeanMoveLocalY(-Screen.height, animateSpeed).setEaseInExpo().setOnComplete(onComplete);
    }

    void onComplete()
    {
        //popup.SetActive(false);
    }
}
