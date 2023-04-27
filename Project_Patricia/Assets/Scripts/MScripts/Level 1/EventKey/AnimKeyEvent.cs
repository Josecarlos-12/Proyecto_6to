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

    public IEnumerator DialogueOne()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Contestaaa!";
        yield return new WaitForSeconds(2);
        text.SetActive(true);
    }

    public IEnumerator AciveSound()
    {
        for (int i = 0; i < sound.Length; i++)
        {
            sound[i].Play();
        }
        yield return new WaitForSeconds(3);
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Te lo advertí";
        yield return new WaitForSeconds(2);
        active.active2 = true;
        Destroy(shadow);
        boss.SetActive(true);
        text.SetActive(false);
        cam.SetActive(false);
        prota.SetActive(true);
    }
}
