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
    public AudioSource audio;
    public AudioClip clip;

    public enum State
    {
        one, two, three
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
        audio.clip = clip;
        audio.Play();
        text.text = sText;
        yield return new WaitForSeconds(4);
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
}
