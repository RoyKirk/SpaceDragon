using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour {
    public GameObject defaultButton;

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("PlayerControls");
        Cursor.visible = false;
    }
    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
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
