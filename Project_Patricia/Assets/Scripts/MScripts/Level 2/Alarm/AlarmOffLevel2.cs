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
    [SerializeField] private GameObject closeDoor;

    private void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            col.enabled= false;
            into=false;
            textE.SetActive(false);
            alarm.Stop();
            animAlarm.SetBool("On", false);
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1.0f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Hmm, no parece que haya nadie...";
        yield return new WaitForSeconds(3f);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Y tampoco escucho nada";
        yield return new WaitForSeconds(2f);
        doorAnim.SetBool("Shiny", true);
        dialogue.SetActive(false);
        closeDoor.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(touch.active)
            {
                into= true;
                textE.SetActive(true);
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
