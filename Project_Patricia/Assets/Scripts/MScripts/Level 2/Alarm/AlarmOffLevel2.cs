using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlarmOffLevel2 : MonoBehaviour
{
    [SerializeField] private AudioSource alarm;
    [SerializeField] private Animator animAlarm, doorAnim;
    [SerializeField] private GameObject textE;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private EventTouchLevel2 touch;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject closeDoor, colliderActive, shadowCat;

    [Header("Audio")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private Animator alarmAnim;


    public enum Alarm
    {
        one, two, three
    }
    public Alarm eventAlarm;

    private void Update()
    {
        switch (eventAlarm)
        {
            case Alarm.one:
                if (into && Input.GetKeyDown(KeyCode.E))
                {
                    alarmAnim.SetBool("On", false);
                    col.enabled = false;
                    into = false;
                    textE.SetActive(false);
                    alarm.Stop();
                    animAlarm.SetBool("On", false);
                    StartCoroutine("Dialogue");
                }
                break; 
            case Alarm.two:
                if (into && Input.GetKeyDown(KeyCode.E))
                {
                    alarmAnim.SetBool("On", false);
                    col.enabled = false;
                    into = false;
                    textE.SetActive(false);
                    alarm.Stop();
                    animAlarm.SetBool("On", false);
                    StartCoroutine("Dialogue2");
                }
                break;
            case Alarm.three:
                if (into && Input.GetKeyDown(KeyCode.E))
                {
                    alarmAnim.SetBool("On", false);
                    colliderActive.SetActive(true);
                    col.enabled = false;
                    into = false;
                    textE.SetActive(false);
                    alarm.Stop();
                    animAlarm.SetBool("On", false);
                    StartCoroutine("Dialogue3");
                }
                break;
        }
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1.0f);
        mike.clip = clip[0];
        mike.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Hmm, no parece que haya nadie...";
        yield return new WaitForSeconds(3f);
        mike.clip = clip[1];
        mike.Play();

        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Y tampoco escucho nada";
        yield return new WaitForSeconds(2f);
        doorAnim.SetBool("Shiny", true);
        dialogue.SetActive(false);
        closeDoor.SetActive(true);
    }

    public IEnumerator Dialogue2()
    {
        mike.clip = clip[0];
        mike.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Esta cosa ya se malogró o qué?";
        yield return new WaitForSeconds(3f);
        doorAnim.SetBool("Shiny", true);
        dialogue.SetActive(false);
        closeDoor.SetActive(true);
    }

    public IEnumerator Dialogue3()
    {
        shadowCat.SetActive(true);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Dejaré la puerta como está";
        yield return new WaitForSeconds(2f);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Un poco de aire no estaría mal ";        
        yield return new WaitForSeconds(2f);
        dialogue.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (eventAlarm)
            {
                case Alarm.one:
                    if (touch.active)
                    {
                        into = true;
                        textE.SetActive(true);
                    }
                    break;
                 case Alarm.two:
                    into = true;
                    textE.SetActive(true);
                    break;
                case Alarm.three:
                    into = true;
                    textE.SetActive(true);
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
}
