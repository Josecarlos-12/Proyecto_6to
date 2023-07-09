using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueDorr : MonoBehaviour
{
    [SerializeField] private Animator animDoor;

    [Header("Dialgoue")]
    [SerializeField] private GameObject dialogue;

    [Header("Call Other Script")]
    [SerializeField] private GrabRifleColl fin;
    public Rifle rifle;

    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;
    [SerializeField] private GameObject repeat;

    [Header("Audios")]
    [SerializeField] private AudioSource backgroundSound;
    [SerializeField] private AudioSource sfxSounds, sfxSounds2;
    [SerializeField] private AudioClip breathing, door, horror;
    [SerializeField] private GameObject hud;

    public void BackGround()
    {
        backgroundSound.Play();
    }

    public void Breathing()
    {
        sfxSounds.clip = breathing;
        sfxSounds.Play();
    }

    public void DoorOpen()
    {
        sfxSounds2.clip = door;
        sfxSounds2.Play();
    }

    public void Horror()
    {
        sfxSounds.clip = horror;
        sfxSounds.Play();
    }

    public IEnumerator Dialogue()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Ne- necesito aire";
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSeconds(7);        
        dialogue.SetActive(false);
        dialogue.GetComponent<TextMeshProUGUI>().text = string.Empty;
    }


    public IEnumerator Crouch()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Que hacía eso ahí...";
        audioMike.clip = clip[1];
        audioMike.Play();
        yield return new WaitForSeconds(4);        
        dialogue.SetActive(false);
        dialogue.GetComponent<TextMeshProUGUI>().text = string.Empty;
    }

    public IEnumerator HeadUp()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Quién? Quién está ahí?";
        audioMike.clip = clip[2];
        audioMike.Play();
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Hay un extraño cerca";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Debo avisar a Cat";
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
        dialogue.GetComponent<TextMeshProUGUI>().text = string.Empty;
    }


    public void Finish()
    {
        hud.SetActive(true);
        fin.prota.SetActive(true);
        fin.cam.SetActive(false);
        repeat.SetActive(true);
    }

    public void DialogueTrue()
    {
        rifle.star = true;
    }

    public void ODoorBig()
    {
        animDoor.SetBool("Close", false);
        animDoor.speed = 2;
    }
}
