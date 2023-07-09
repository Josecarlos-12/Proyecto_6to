using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private PlayerFPSt walk;
    [SerializeField] private PlayerCrouch crouch;
    [SerializeField] private GameObject eventFindCharlie;

    [Header("Call Other Scripts")]
    [SerializeField] private TasksUILevel2 task;

    [Header("Audios")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioSource piano;
    [SerializeField] private AudioClip[] clip;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        mike.clip = clip[0];
        mike.Play();

        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Hola?, hay alguien...";
        yield return new WaitForSeconds(4);
        text.SetActive(false);
        walk.canWalk= true;
        crouch.crouchCan= true;
        yield return new WaitForSeconds(1);
        mike.clip = clip[1];
        mike.Play();
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Eso fue muy extraño";
        yield return new WaitForSeconds(3);
        mike.clip = clip[2];
        mike.Play();
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Aghh... mi cabeza";
        yield return new WaitForSeconds(3);
        piano.Play();
        text.SetActive(false);
        yield return new WaitForSeconds(9);
        text.SetActive(true);
        mike.clip = clip[3];
        mike.Play();
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Oh, no debo olvidarme de ir a ver a Charlie";
        yield return new WaitForSeconds(5);
        text.SetActive(false);
        task.go = true;
        eventFindCharlie.SetActive(true);
        this.gameObject.GetComponent<StartLevel2>().enabled = false;
    }
}
