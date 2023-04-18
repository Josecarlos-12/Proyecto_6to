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

    public IEnumerator Dialogue()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Hey, tranquilo... ya no llores";
        yield return new WaitForSeconds(2);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith:  Aquí está papá";
        yield return new WaitForSeconds(2);
        text.SetActive(false);
    }

    public IEnumerator ChageClip()
    {
        audioS.Stop();
        yield return new WaitForSeconds(1);
        audioS.clip = clip;
        audioS.Play();
        audioS.loop= false;
    }

    public void FinAnim()
    {
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
