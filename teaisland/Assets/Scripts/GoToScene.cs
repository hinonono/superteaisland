using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public float animateSpeed = 0.5f;
    public GameObject popup;
    private string sceneDestination;

    public Transform box;
    public CanvasGroup background;
    public Text areaName;

    public void SetSceneDestination(string destination)
    {
        popup.SetActive(true);
        sceneDestination = destination;

        switch (destination)
        {
            case "Map_red":
                areaName.text = "紅茶之境";
                break;

            default:
                areaName.text = "Unknown";
                break;
        }

        background.alpha = 0;
        background.LeanAlpha(1, animateSpeed);

        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, animateSpeed).setEaseOutExpo().delay = 0.1f;
    }

    public void ButtonMoveScene()
    {
        if (sceneDestination != null)
        {
            SceneManager.LoadScene(sceneDestination);
        }
        else
        {
            Debug.Log("Scene Destination is not set yet. Try run SetSceneDestination() first.");
        }
        
    }

    public void ClosePopup()
    {
        background.LeanAlpha(0, animateSpeed);
        box.LeanMoveLocalY(-Screen.height, animateSpeed).setEaseInExpo().setOnComplete(onComplete);
    }

    void onComplete()
    {
        popup.SetActive(false);
    }
}
