using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimKeyEvent : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private AudioSource[] sound;
    [SerializeField] private GameObject cam, prota, shadow, boss;
    [SerializeField] private ActiveBoss active;

    [Header("Dialogue")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip[] clip;
    [SerializeField] private GameObject task;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject aim;



    public IEnumerator DialogueOne()
    {
        mike.clip = clip[0];
        mike.Play();

        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Contestaaa!";
        yield return new WaitForSeconds(2);
        text.SetActive(true);
    }

    public IEnumerator AciveSound()
    {
        aim.SetActive(false);
        hud.SetActive(false);
        for (int i = 0; i < sound.Length; i++)
        {
            sound[i].Play();
        }
        yield return new WaitForSeconds(3);
        mike.clip = clip[1];
        mike.Play();

        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Te lo advertí";
        yield return new WaitForSeconds(2);
        hud.SetActive(true);
        aim.SetActive(true);
        task.SetActive(true);
        active.active2 = true;        
        boss.SetActive(true);
        text.SetActive(false);
        cam.SetActive(false);
        prota.SetActive(true);
        Destroy(shadow);
    }
}
