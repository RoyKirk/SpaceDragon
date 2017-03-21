using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour {
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("PlayerControls");
    }
    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
