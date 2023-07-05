using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishAnimLevel3 : MonoBehaviour
{
    [SerializeField] private GameObject mike;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject eyes;
    [SerializeField] private GameObject anim;
    [SerializeField] private GameObject animBack;

    [SerializeField] private AudioSource mikeAudio;
    [SerializeField] private AudioClip[] clip;

    public void ActiveAnim()
    {
        anim.SetActive(true);
        animBack.SetActive(false);
    }

    public void OffMike()
    {
        mike.SetActive(false);
    }

    public IEnumerator Dialogue()
    {
        mikeAudio.clip=clip[0];
        mikeAudio.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: Tranquilo papá, estaremos bien";
        yield return new WaitForSeconds(6);
        mikeAudio.clip = clip[1];
        mikeAudio.Play();

        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: Ya no es necesario que te preocupes más por nosotros";
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
    }

    public IEnumerator MikeFinish()
    {
        mikeAudio.clip = clip[0];
        mikeAudio.Play();        
        yield return new WaitForSeconds(6);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Lo sé";
        yield return new WaitForSeconds(6);
        dialogue.SetActive(false);
    }


    public void Eyes()
    {
        eyes.SetActive(true);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
