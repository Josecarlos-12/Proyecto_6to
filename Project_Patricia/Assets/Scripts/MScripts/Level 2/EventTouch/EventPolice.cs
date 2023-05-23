using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventPolice : MonoBehaviour
{
    [SerializeField] private GameObject text, dialogue;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;

    [Header("Call Other Script"),SerializeField] private TasksUILevel2 task;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            col.enabled= false;
            into = false;
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Carajo";
        yield return new WaitForSeconds(1);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Tengo que revisar los fusibles rápido, no me siento bien con todo oscuro";
        yield return new WaitForSeconds(4);
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
