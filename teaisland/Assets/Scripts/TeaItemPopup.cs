using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeaItemPopup : MonoBehaviour
{
    //控制Pop出現與消失的速度
    public float animateSpeed = 0.5f;

    //自身相關元件
    public Transform box;
    public CanvasGroup background;
    public GameObject popupTitle;
    public GameObject popupDescription;

    private PlayerInventory playerInventory;

    //Event
    public event Action onConfirmPressed;
    public event Action onCancelPressed;

    private void OnEnable()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        playerInventory.onItemTouched += PlayerInventory_onItemTouched;
        playerInventory.onItemExited += PlayerInventory_onItemExited;
        
    }

    private void OnDestroy()
    {
        playerInventory.onItemTouched -= PlayerInventory_onItemTouched;
        playerInventory.onItemExited -= PlayerInventory_onItemExited;
    }

    private void PlayerInventory_onItemTouched(string itemName, string itemDescription)
    {
        popupTitle.GetComponent<TextMeshProUGUI>().text = itemName;
        popupDescription.GetComponent<TextMeshProUGUI>().text = itemDescription;
        openPopup();
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
        gameObject.SetActive(false);
    }


    //在Editor給確認、取消按鈕選用以下func
    public void confirmPressed()
    {
        onConfirmPressed?.Invoke();
        closePopup();
    }

    public void cancelPressed()
    {
        onCancelPressed?.Invoke();
        closePopup();
    }

    
}
