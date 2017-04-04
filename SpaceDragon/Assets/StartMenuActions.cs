using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartMenuActions : MonoBehaviour {
    public GameObject defaultButton;

    public void StartGame()
    {
        SceneManager.LoadScene("PlayerControls");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(defaultButton);
        }
    }
}
