using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DialogueDorr : MonoBehaviour
{
    [Header("Dialgoue")]
    [SerializeField] private GameObject dialogue;

    [Header("Call Other Script")]
    [SerializeField] private GrabRifleColl fin;
    public Rifle rifle;

    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;

    public IEnumerator Dialogue()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Ne- necesito aire";
        yield return new WaitForSeconds(7);
        audioMike.clip = clip[0];
        audioMike.Play();
        dialogue.SetActive(false);
        dialogue.GetComponent<TextMeshProUGUI>().text = string.Empty;
    }


    public IEnumerator Crouch()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Que hacía eso ahí...";
        yield return new WaitForSeconds(4);
        audioMike.clip = clip[1];
        audioMike.Play();
        dialogue.SetActive(false);
        dialogue.GetComponent<TextMeshProUGUI>().text = string.Empty;
    }

    public IEnumerator HeadUp()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Quién? Quién está ahí?";
        yield return new WaitForSeconds(2);
        audioMike.clip = clip[2];
        audioMike.Play();
        dialogue.SetActive(false);
        dialogue.GetComponent<TextMeshProUGUI>().text = string.Empty;
    }


    public void Finish()
    {
        fin.prota.SetActive(true);
        fin.cam.SetActive(false);
    }

    public void DialogueTrue()
    {
        rifle.star = true;
    }
}
