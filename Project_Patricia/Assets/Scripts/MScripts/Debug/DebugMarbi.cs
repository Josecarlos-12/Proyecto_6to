using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMarbi : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Tutorial");
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene("Nivel 1");
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene("Nivel 2");
            Time.timeScale = 1;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
