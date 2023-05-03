using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventTouch : MonoBehaviour
{
    [SerializeField]private GameObject eventPill;
    [SerializeField]private GameObject text, eventSleep;
    [SerializeField] private int count;
    [SerializeField, TextArea(4,4)] private string sText,sText2;

    [Header("Audio")]
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip clipOne, clipTwo;

    public enum typesDialgoue
    {
        one, two, three
    }
    public typesDialgoue type;

    void Start()
    {
        eventPill = this.gameObject;
        eventPill.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count++;
            if (count == 1)
            {
                switch (type)
                {
                    case typesDialgoue.one:
                        StartCoroutine("DialogueOne");
                        break; 
                    case typesDialgoue.two:
                        StopCoroutine("DialogueOne");
                        StartCoroutine("DialogueTwo");
                        break;
                    case typesDialgoue.three:
                        StartCoroutine("DialogueThree");
                        break;
                }
                
            }
        }
    }

    public IEnumerator DialogueOne()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = sText;
        audioMike.clip=clipOne;
        audioMike.Play();
        yield return new WaitForSeconds(6);
        text.SetActive(false);
        Destroy(gameObject);
    }

    public IEnumerator DialogueTwo()
    {        
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = sText;
        audioMike.clip = clipOne;
        audioMike.Play();
        yield return new WaitForSeconds(3);
        audioMike.clip = clipTwo;
        audioMike.Play();
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = sText2;
        yield return new WaitForSeconds(2);
        text.SetActive(false);
        Destroy(gameObject);
    }

    public IEnumerator DialogueThree()
    {
        yield return new WaitForSeconds(0);
        Destroy(gameObject);
        Destroy(eventSleep);
    }
}
