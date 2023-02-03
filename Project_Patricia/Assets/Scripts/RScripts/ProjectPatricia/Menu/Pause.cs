using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public KeyCode PauseButton = KeyCode.Escape    ;
    public bool isPaused=false;
    public GameObject pauseMenuUI;
    public AudioSource pauseSound;

    void Update()
    {
        if (Input.GetKeyDown(PauseButton))
        {
            if(isPaused)
            {
                pauseSound.Play();
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;
                
            }
            else
            {
                pauseSound.Play();
                PauseGame();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;

        AudioSource[] audio= FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audio)
        {
            a.UnPause();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        
        AudioSource[] audio = FindObjectsOfType<AudioSource>();
        
        foreach (AudioSource a in audio)
        {
            a.Pause();
        }
    }
}
