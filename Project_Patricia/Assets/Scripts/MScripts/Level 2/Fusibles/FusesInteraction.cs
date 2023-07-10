using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusesInteraction : MonoBehaviour
{
    [SerializeField] private Animator animCam;
    [SerializeField] private GameObject cam, prota, text;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;
    [SerializeField] private AudioSource background3;
    [SerializeField] private float time, maxTime;
    [SerializeField] private bool less;
    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;

    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            repeat.SetActive(false);
            repeatText.texContainer.SetActive(false);
            repeatText.audio.Stop();
            less= true;
            into = false;
            col.enabled= false;
            text.SetActive(false);
            prota.SetActive(false);
            cam.SetActive(true);
            animCam.enabled= true;
            Cursor.visible=true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (less)
        {
            time += Time.deltaTime;
            if (time > maxTime)
            {
                time = 0;
                background3.volume -= 0.03f;
            }
        }
        if(background3.volume< 0.018f)
        {
            background3.Stop();
            background3.volume = 1;
            enabled= false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = false;
        }
    }
}
