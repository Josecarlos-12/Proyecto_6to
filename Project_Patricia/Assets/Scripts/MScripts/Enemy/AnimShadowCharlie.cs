using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimShadowCharlie : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private GameObject cam, prota, pointCamera;
    [SerializeField] private CharlieGoThree go;
    [SerializeField] private SleepMode sleep;
    [SerializeField] private Animator animCharlie;
    [SerializeField] private GameObject hud;

    [Header("Dialogue")]
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clipMike;

    public void WalkCharlie()
    {
        animCharlie.SetBool("Walk", true);
    }

    public IEnumerator Dialogue()
    {
        audioMike.clip = clipMike[0];
        audioMike.Play();

        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Hey, tranquilo... ya no llores";
        yield return new WaitForSeconds(4);

        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Aqu� est� pap�";
        yield return new WaitForSeconds(2);
        text.SetActive(false);
    }

    public IEnumerator ChageClip()
    {
        
        audioS.Stop();
        yield return new WaitForSeconds(1);
        animCharlie.SetBool("Scream", true);
        audioS.clip = clip;
        audioS.volume = 0.5f;
        audioS.Play();
        audioS.loop= false;
    }

    public void FinAnim()
    {
        hud.SetActive(true);
        animCharlie.SetBool("Scream", false);
        prota.transform.position = pointCamera.transform.position;
        prota.transform.rotation = pointCamera.transform.rotation;
        cam.SetActive(false);
        prota.SetActive(true);
        go.go = true;
        StartCoroutine("MoodDreams");
    }

    public IEnumerator MoodDreams()
    {
        sleep.ModeDreams();
        yield return new WaitForSeconds(3);
        sleep.OffDreams();
    }

}
