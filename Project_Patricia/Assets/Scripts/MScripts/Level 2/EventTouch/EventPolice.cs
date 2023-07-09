using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventPolice : MonoBehaviour
{
    [SerializeField] private GameObject text, dialogue, fuses;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;

    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip clip;
    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;
    [SerializeField] private AudioClip clipRepeat;

    [Header("Call Other Script"),SerializeField] private TasksUILevel2 task;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            repeat.SetActive(false);
            text.SetActive(false);
            task.taskCount = 2;
            col.enabled= false;
            into = false;
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        audioMike.clip= clip;
        audioMike.Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Carajo";
        yield return new WaitForSeconds(1);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Tengo que revisar los fusibles rápido, no me siento bien con todo oscuro";
        yield return new WaitForSeconds(4);
        repeat.SetActive(true);
        repeatText.sText = "Mike Schmith: Debo revisar rápido los fusibles de la cocina";
        repeatText.clip= clipRepeat;
        fuses.SetActive(true);
        dialogue.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = false;
        }
    }
}
