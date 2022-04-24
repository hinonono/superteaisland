using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{

    //判定互動區域是哪一種種類（調茶/配料）
    public InteractionType interactionType = new InteractionType();

    public float animateSpeed = 0.5f;
    public GameObject popup;
    public Transform box;
    public CanvasGroup background;
    public Text areaName;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {

        popup.SetActive(true);
        background.alpha = 0;
        background.LeanAlpha(1, animateSpeed);

        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, animateSpeed).setEaseOutExpo().delay = 0.1f;

        isTriggered = true;

        Debug.Log("in");
    }

    private void OnTriggerExit(Collider other)
    {
        //background.LeanAlpha(0, animateSpeed);
        //box.LeanMoveLocalY(-Screen.height, animateSpeed).setEaseInExpo();
        //popup.SetActive(false);


        //Debug.Log("start corotine");
        //StartCoroutine(waitAndResetIstriggered());
        Debug.Log("out");
    }

    private IEnumerator waitAndResetIstriggered()
    {
        yield return new WaitForSeconds(3f);
        isTriggered = false;

        Debug.Log("set to false");
        yield return null;
    }

}

public enum InteractionType
{
    tea,
    topping
}
