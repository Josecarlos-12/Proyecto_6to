using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimFlower : MonoBehaviour
{
    [SerializeField] private Animator animCam;
    [SerializeField] private GameObject cam, prota;
    [SerializeField] private Collider col;
    [SerializeField] private Animator animDoor, animDoorV2;    
    [SerializeField] private GameObject switchGog, switchBad;
    [SerializeField] private GameObject[] lightDesactive;
    [SerializeField] private GameObject openDoor, pills;
    

    [Header("Task")]
    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;
    [SerializeField] private AudioClip clipRepeat;
    [SerializeField] private Animator animFlower;

    [Header("Dialogue")]
    [SerializeField] private GameObject text;

    [Header("Audio")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip[] clip;

    [Header("Door Close")]
    [SerializeField] private AudioSource audioDoor;
    [SerializeField] private AudioSource back;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject hud;
    [SerializeField] private AudioSource steeps;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            steeps.Stop();
            hud.SetActive(false);
            animFlower.enabled = false;
            cam.SetActive(true);
            prota.SetActive(false);
            col.enabled = false;
            animCam.enabled = true;
        }
    }

    public IEnumerator Smell()
    {
        mike.clip = clip[0];
        mike.Play();

        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Aahh, me recuerdan a ella";
        pills.SetActive(true);
        yield return new WaitForSeconds(2);
        text.SetActive(false);
    }

    public void Dream()
    {
        audioDoor.clip = audioClip;
        audioDoor.Play();

        animDoor.SetBool("Close", true);
        animDoorV2.SetBool("Close", true);
        StartCoroutine("ChangeMode");
        switchGog.SetActive(false);
        switchBad.SetActive(true);
        openDoor.SetActive(true);

        for (int i = 0; i < lightDesactive.Length; i++)
        {
            lightDesactive[i].SetActive(false);
        }
    }

    public IEnumerator ChangeMode()
    {        
        yield return new WaitForSeconds(3f);        
        text.SetActive(true);
        mike.clip = clip[1];
        mike.Play();
        back.Play();

        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡¿Caaat?!";
        yield return new WaitForSeconds(1f);
        mike.clip = clip[2];
        mike.Play();

        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Agh, no creo que me escuche";
        
        yield return new WaitForSeconds(3f);  
        repeat.SetActive(true);
        repeatText.sText = "Mike Schmith: Debo hallar la forma de entrar";
        repeatText.clip = clipRepeat;

        text.SetActive(false);
    }

    public void Finish()
    {
        hud.SetActive(true);
        cam.SetActive(false);
        prota.SetActive(true);
    }

}
