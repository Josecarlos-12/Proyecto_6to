using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventTouchCat : MonoBehaviour
{
    [SerializeField] private GameObject shadowCat;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject[] lightActive; 
    [SerializeField] private GameObject[] allLightActive;
    [SerializeField] private GameObject floor2God, floor2Bad;
    [SerializeField] private TasksUILevel2 task;
    [SerializeField] private GameObject taskGame, boxPolice;
    [SerializeField] private AudioSource audioBack;

    [Header("Audio")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip[] clip;
    [SerializeField] private AudioSource scare;

    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;
    [SerializeField] private AudioClip clipRepeat;


    public enum Touch
    {
        between, cat
    }
    public Touch touch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (touch)
            {
                case Touch.between:
                    repeat.SetActive(false);
                    col.enabled = false;
                    StartCoroutine("Dialogue");
                    break;
                case Touch.cat:
                    scare.Play();
                    col.enabled = false;
                    StartCoroutine("DialogueCat");
                    break;
            }
        }
    }

    public IEnumerator DialogueCat()
    {
        mike.clip = clip[0];
        mike.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Cat?";
        yield return new WaitForSeconds(0.8f);
        shadowCat.SetActive(false);

        yield return new WaitForSeconds(1.2f);
        dialogue.SetActive(false);

        yield return new WaitForSeconds(0.4f);        
        for (int i = 0; i < lightActive.Length; i++)
        {
            lightActive[i].SetActive(false);
        }
        
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < lightActive.Length; i++)
        {
            lightActive[i].SetActive(true);
        }

        yield return new WaitForSeconds(0.2f);
        
        for (int i = 0; i < lightActive.Length; i++)
        {
            lightActive[i].SetActive(false);
        }

        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < lightActive.Length; i++)
        {
            lightActive[i].SetActive(true);
        }

        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < lightActive.Length; i++)
        {
            lightActive[i].SetActive(false);
        }

        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < lightActive.Length; i++)
        {
            lightActive[i].SetActive(true);
        }

        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < lightActive.Length; i++)
        {
            lightActive[i].SetActive(false);
        }

        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < lightActive.Length; i++)
        {
            lightActive[i].SetActive(true);
        }

        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < lightActive.Length; i++)
        {
            lightActive[i].SetActive(false);
        }

        for (int i = 0; i < allLightActive.Length; i++)
        {
            allLightActive[i].SetActive(false);
        }

        
        floor2God.SetActive(false);
        floor2Bad.SetActive(true);

        dialogue.SetActive(true);

        mike.clip = clip[1];
        mike.Play();

        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡¿Quién está en la casa?!";
        yield return new WaitForSeconds(2);

        mike.clip = clip[2];
        mike.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Vete ahora mismo o llamaré a la policía!";
        
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
        boxPolice.SetActive(true);
        yield return new WaitForSeconds(2);
        repeat.SetActive(true);
        repeatText.sText = "Mike Schmith: Necesito el teléfono cuanto antes";
        repeatText.clip = clipRepeat;
        
    }

    public IEnumerator Dialogue()
    {
        mike.clip = clip[0];
        mike.Play();

        audioBack.Stop();
        task.taskCount = 2;
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Cat?";
        yield return new WaitForSeconds(2);
        mike.clip = clip[1];
        mike.Play();


        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Quizá fue a ver a Charlie";
        yield return new WaitForSeconds(4);


        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Bueno, subiré a verlos";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
        shadowCat.SetActive(true);
    }
}
