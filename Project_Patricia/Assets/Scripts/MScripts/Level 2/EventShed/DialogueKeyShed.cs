using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueKeyShed : MonoBehaviour
{

    [SerializeField] private GameObject dialogue;
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip clip;
    [SerializeField] private Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
            StartCoroutine("KeyDialogue");
        }
    }

    public IEnumerator KeyDialogue()
    {
        mike.clip= clip;
        mike.Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Siempre estuvieron aquí ";
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}

