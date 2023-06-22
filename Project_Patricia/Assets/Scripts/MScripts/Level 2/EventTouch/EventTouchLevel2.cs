using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EventTouchLevel2 : MonoBehaviour
{
    [SerializeField] private Animator animDoor;
    [SerializeField] private AudioSource alarm;
    [SerializeField] private Collider col;
    [SerializeField] private Animator keyPad;
    public bool active;
    [SerializeField] private bool into;
    [SerializeField] private GameObject textE, alarm2;

    [SerializeField] private PickableObject wine;
    [SerializeField] private TrashOn trashW;

    [Header("Dialogue")]
    //[SerializeField] private AudioSource audioMike;
    [SerializeField] private GameObject text;
    [SerializeField] private string mike;

    [Header("Call Other Script")]
    [SerializeField] private ShinyLevel2 shiny;

    [Header("Audio")]
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip clipMike;

    [SerializeField] private Animator alarmAnim;

    public enum Interaction
    {
        interaction, touch, vino
    }
    public Interaction inte;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        switch (inte)
        {
            case Interaction.interaction:
                if (Input.GetKeyDown(KeyCode.E) && into)
                {
                    alarmAnim.SetBool("On", true);
                    textE.SetActive(false);
                    into = false;
                    active = true;
                    keyPad.SetBool("On", true);
                    col.enabled = false;
                    animDoor.SetBool("Close", false);
                    alarm.Play();
                    StartCoroutine("Dialogue");
                    shiny.on = false;
                }
                break; 
            case Interaction.touch:
                break;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (inte)
            {
                case Interaction.interaction:
                    into = true;
                    textE.SetActive(true);
                    break;
                case Interaction.touch:
                    StartCoroutine("DialogueAlarm2");
                    alarmAnim.SetBool("On", true);
                    alarm.Play();
                    col.enabled = false;
                    animDoor.SetBool("Close", false);
                    keyPad.SetBool("On", true);
                    break;
                case Interaction.vino:
                    col.enabled = false;
                    StartCoroutine("DialogueAlarm3");
                    break;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
            textE.SetActive(false);
        }

    }

    public IEnumerator DialogueAlarm2()
    {
        yield return new WaitForSeconds(1);

        if (audioMike != null)
        {
            audioMike.clip = clipMike;
            audioMike.Play();
        }
        

        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = mike;
        alarmAnim.SetBool("On", true);
        alarm2.SetActive(true);
        yield return new WaitForSeconds(2);
        text.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1);
        audioMike.clip = clipMike;
        audioMike.Play();

        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Qué? ¿Alguien habrá entrado?";
        //yield return new WaitForSeconds(2);
        //text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ";
        yield return new WaitForSeconds(4);
        text.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public IEnumerator DialogueAlarm3()
    {
        yield return new WaitForSeconds(1);
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = mike;
        yield return new WaitForSeconds(2);
        trashW.enabled = true;
        wine.enabled = true;
        wine.isPickable = true;
        text.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
