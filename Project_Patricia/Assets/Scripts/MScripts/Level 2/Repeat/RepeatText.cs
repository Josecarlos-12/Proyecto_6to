using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RepeatText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public GameObject texContainer;
    [TextArea(4, 4)] public string sText;
    [SerializeField] private int count;
    public float time = 6;
    public AudioSource audio, audioCharlie;
    public AudioClip clip;
    public AudioClip clip2;

    public enum State
    {
        one, two, three, four, five, six
    }
    public State state;

    private void OnDisable()
    {
        count = 0;   
    }

    private void Update()
    { 
        if(count<3)
        count++;

        if (count == 1)
        {
            switch (state)
            {
                case State.one:
                    StartCoroutine("Repeat");
                    break;
                case State.two:
                    StartCoroutine("Repeat2");
                    break;
                case State.three:
                    StartCoroutine("Repeat3");
                    break;
                case State.four:
                    StartCoroutine("Repeat4");
                    break;
                case State.five:
                    StartCoroutine("Repeat5");
                    break;
                case State.six:
                    StartCoroutine("Repeat6");
                    break;
            }

            
        }
    }

    private IEnumerator Repeat()
    {
        yield return new WaitForSeconds(time);
        audio.clip = clip;
        audio.Play();
        texContainer.SetActive(true);
        text.text = sText;
        yield return new WaitForSeconds(4);
        texContainer.SetActive(false);
        text.text = string.Empty;
        yield return new WaitForSeconds(18);
        yield return Repeat();
    }

    private IEnumerator Repeat2()
    {
        yield return new WaitForSeconds(time);
        texContainer.SetActive(true);
        audio.clip = clip;
        audio.Play();
        text.text = sText;
        yield return new WaitForSeconds(4);
        texContainer.SetActive(false);
        text.text = string.Empty;
        yield return new WaitForSeconds(12);
        yield return Repeat2();
    }

    private IEnumerator Repeat3()
    {
        yield return new WaitForSeconds(20);
        texContainer.SetActive(true);
        if (clip != null)
        {
            audio.clip = clip;
            audio.Play();
        }        
        text.text = sText;
        yield return new WaitForSeconds(4);
        texContainer.SetActive(false);
        text.text = string.Empty;
        yield return Repeat3();
    }

    private IEnumerator Repeat4()
    {
        yield return new WaitForSeconds(6);
        texContainer.SetActive(true);
        if (clip != null)
        {
            audio.clip = clip;
            audio.Play();
        }
        text.text = "Mike Schmith: Llaves, llaves... llaves del ático";
        yield return new WaitForSeconds(3);
        text.text = "Mike Schmith: Deben estar al lado del a entrada";
        yield return new WaitForSeconds(4);
        texContainer.SetActive(false);
        text.text = string.Empty;
        yield return Repeat3();
    }

    private IEnumerator Repeat5()
    {
        yield return new WaitForSeconds(6);
        texContainer.SetActive(true);
        audioCharlie.clip = clip;
        audioCharlie.Play();
        text.text = "Charlie Schmith: ¡Papaaaaaaa! ¡Ayudameeeeeee!";
        yield return new WaitForSeconds(3);
        audio.clip = clip2;
        audio.Play();    
        text.text = "Mike Schmith: ¡Charlie! ¡Ya voy!";
        yield return new WaitForSeconds(4);
        texContainer.SetActive(false);
        text.text = string.Empty;
        yield return Repeat5();
    }

    private IEnumerator Repeat6()
    {
        yield return new WaitForSeconds(6);
        texContainer.SetActive(true);
        audio.clip = clip;
        audio.Play();
        text.text = "Mike Schmith: A Catelyn le encanta las margaritas";
        yield return new WaitForSeconds(5);
        audio.clip = clip2;
        audio.Play();
        text.text = "Mike Schmith: Creo haber visto crecer algunas cerca de la entrada";
        yield return new WaitForSeconds(4);
        texContainer.SetActive(false);
        text.text = string.Empty;
        yield return Repeat6();
    }
}
