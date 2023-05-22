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
    [SerializeField] private GameObject textE;  

    [Header("Dialogue")]
    //[SerializeField] private AudioSource audioMike;
    [SerializeField] private GameObject text;

    [Header("Call Other Script")]
    [SerializeField] private ShinyLevel2 shiny;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && into)
        {
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = true;
            textE.SetActive(true);
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

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1);
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Qué?";
        yield return new WaitForSeconds(2);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Alguien habrá entrado?";
        yield return new WaitForSeconds(3);
        text.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
