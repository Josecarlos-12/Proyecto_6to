using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchCatPaint : MonoBehaviour
{
    [SerializeField] GameObject cat;
    [SerializeField] AudioSource audioSound;
    [SerializeField] AudioSource audioSound2;
    [SerializeField] Collider col;

    [Header("Chapter")]
    [SerializeField] bool into;
    [SerializeField] Animator animDoor, animPlayer;
    [SerializeField] AudioSource audioDoor;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject eText;
    [SerializeField] Animator chair;
    [SerializeField] GameObject prota, panel, text;
    [SerializeField] GameObject eyes;

    [SerializeField] private GameObject hud;
    public enum Cat
    {
        touch, chapter
    }
    public Cat type;

    private void Update()
    {
        switch (type)
        {
            case Cat.chapter:
                if(into && Input.GetKeyDown(KeyCode.E))
                {
                    hud.SetActive(false);
                    animDoor.SetBool("Open", true);
                    animPlayer.enabled= true;
                    audioDoor.Play();
                    into = false;
                    eText.SetActive(false);
                    col.enabled = false;
                    prota.SetActive(false);
                    cam.SetActive(true);
                }
                break;
        }
    }
    public void EyesCClose()
    {
        eyes.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (type)
            {
                case Cat.touch:
                    col.enabled = false;
                    audioSound.Play();
                    StartCoroutine("DesactiveCat");
                    break;
                case Cat.chapter:
                    into = true;
                    eText.SetActive(true);
                    break;
            }

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (type)
        {
            case Cat.chapter:
                into = false;
                eText.SetActive(false);
                break;
        }
    }

    public IEnumerator DesactiveCat()
    {
        chair.enabled = true;
        yield return new WaitForSeconds(1.1f);
        cat.SetActive(true);
        yield return new WaitForSeconds(1f);
        cat.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public IEnumerator Chapter()
    {
        prota.SetActive(false);
        cam.SetActive(true);
        panel.SetActive(true);
        yield return new WaitForSeconds(1f);
        text.SetActive(true);
        yield return new WaitForSeconds(2f);
        //Cursor.visible= true;
        //Cursor.lockState= CursorLockMode.None;
        SceneManager.LoadScene("Nivel 3");
    }
}
