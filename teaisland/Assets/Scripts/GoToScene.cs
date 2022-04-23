using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public GameObject popup;
    private string sceneDestination;

    public void SetSceneDestination(string destination)
    {
        popup.SetActive(true);
        sceneDestination = destination;
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

    public void OpenPopup()
    {
        popup.SetActive(true);
    }

    public void ClosePopup()
    {
        popup.SetActive(false);
    }
}
