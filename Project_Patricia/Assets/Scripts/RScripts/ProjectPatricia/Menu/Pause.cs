using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public KeyCode PauseButton = KeyCode.Escape    ;
    public bool isPaused=false;
    public GameObject pauseMenuUI;
    public AudioSource pauseSound;
    public bool shoot;

    [SerializeField] private NotesUI note;
    [SerializeField] private DebugMarbi debug;


    private void Start()
    {
        shoot = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(PauseButton) && !note.bNote)
        {
            if(isPaused)
            {
                //pauseSound.Play();
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                debug.NO();
                shoot = true;
            }
            else
            {
                //pauseSound.Play();
                PauseGame();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                shoot= false;
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
