using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoorBathroom : MonoBehaviour
{
    [SerializeField] private Animator animDoor;
    [SerializeField] private GameObject text;
    [SerializeField] private AudioSource audioDoor;
    [SerializeField] private AudioClip clip;
    [SerializeField] private bool into;    
    [SerializeField] private Collider thisColl;
    public bool bActive;

    [Header("Call Other Script")]
    [SerializeField] private EventBathroom active;

    [Header("Dialogue")]
    [SerializeField] private GameObject dialogue;

    [Header("Audio")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip[] clipMike;

    private void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            text.SetActive(false);
            thisColl.enabled= false;
            into= false;
            animDoor.SetBool("Open", false);
            StartCoroutine("Next");
        }   
    }

    public IEnumerator Next()
    {
        yield return new WaitForSeconds(0.4f);
        audioDoor.Play();
        yield return new WaitForSeconds(1.6f);
        mike.clip = clipMike[0];
        mike.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Quizá no le fue muy bien es esa reunión";
        yield return new WaitForSeconds(2f);
        mike.clip = clipMike[1];
        mike.Play();

        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Debería ir a la cocina a prepararle algo de comer";
        yield return new WaitForSeconds(3f);
        dialogue.SetActive(false);
        bActive= true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (active.active)
            {
                text.SetActive(true);
                into = true;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into= false;
        }
    }
}
