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
    [SerializeField] private GameObject openDoor;
    

    [Header("Task")]
    [SerializeField] private TasksUILevel2 task;
    [SerializeField] private GameObject taskGame;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
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
        yield return new WaitForSeconds(1f);        
        text.SetActive(true);
        mike.clip = clip[1];
        mike.Play();
        back.Play();

        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡¿Caaat?!";
        yield return new WaitForSeconds(1f);
        mike.clip = clip[2];
        mike.Play();

        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Agh, no creo que me escuche";
        task.taskCount = 1;
        taskGame.SetActive(true);
        task.countT = 0;
        task.go = true;
        task.task = "Returns home";
        yield return new WaitForSeconds(3f);        
        text.SetActive(false);
    }

    public void Finish()
    {
        cam.SetActive(false);
        prota.SetActive(true);
    }

}
