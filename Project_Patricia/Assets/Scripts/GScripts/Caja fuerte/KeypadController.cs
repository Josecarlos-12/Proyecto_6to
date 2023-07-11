﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;
    [SerializeField] private AudioClip clip;

    public DoorController door;
    public string password;
    public int passwordLimit;
    public TextMeshProUGUI passwordText;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    [Header("Finish")]
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject prota;
    [SerializeField] private Collider col;
    [SerializeField] private StrongBoxCode box;
    [SerializeField] private Animator animBox;
    [SerializeField] private GameObject gameObjects;
    [SerializeField] private Collider colActive;
    public StrongBox sBox;

    public enum Levels
    {
        level3, level1
    }public Levels levels;

    private void Start()
    {
        passwordText.text = "";
    }

    public void PasswordEntry(string number)
    {
        if (number == "Clear")
        {
            Clear();
            return;
        }
        else if(number == "Enter")
        {
            Enter();
            return;
        }

        int length = passwordText.text.ToString().Length;
        if(length<passwordLimit)
        {
            passwordText.text = passwordText.text + number;
        }
    }

    public void Clear()
    {
        passwordText.text = "";
        passwordText.color = Color.white;
    }

    private void Enter()
    {
        if (passwordText.text == password)
        {
            switch (levels)
            {
                case Levels.level3:
                    //door.lockedByPassword = false;
                    print("Abrio");
                    cam.SetActive(false);
                    prota.SetActive(true);
                    col.enabled = false;
                    box.enabled = false;
                    animBox.SetBool("Open", true);
                    print("DD");
                    StartCoroutine("OnObjects");
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    //if (audioSource != null)
                    //  audioSource.PlayOneShot(correctSound);

                    passwordText.color = Color.green;
                    StartCoroutine(waitAndClear());
                    break; 
                case Levels .level1:
                    repeat.SetActive(false);
                    repeatText.texContainer.SetActive(false);
                    repeatText.audio.Stop();
                    repeatText.sText = string.Empty;
                    repeatText.state = RepeatText.State.two;
                    repeat.SetActive(true);
                    repeatText.clip= clip;
                    repeatText.sText = "Mike Schmith: Listo, ahora sigue la caja musical";
                    col.enabled = false;
                    cam.SetActive(false);
                    prota.SetActive(true);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    sBox.Next();
                    passwordText.color = Color.green;
                    break;
            }
            
        }
        else
        {
            //if (audioSource != null)
              //  audioSource.PlayOneShot(wrongSound);

            passwordText.color = Color.red;
            StartCoroutine(waitAndClear());
        }
    }

    public IEnumerator OnObjects()
    {
        yield return new WaitForSeconds(1);
        gameObjects.SetActive(true);
        colActive.enabled = true;
    }

    IEnumerator waitAndClear()
    {
        yield return new WaitForSeconds(0.75f);
        Clear();
    }


}
