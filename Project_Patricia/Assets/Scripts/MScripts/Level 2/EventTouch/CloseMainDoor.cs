using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloseMainDoor : MonoBehaviour
{
    [SerializeField] private Animator animDoor;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject text, dialogue, dialogueV2, alarmV2;
    [SerializeField] private bool into;

    [SerializeField] private PickableObject pickableObject;
    [SerializeField] private TrashOn trash;

    [Header("Audio")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip clip;

    public enum CloseDoor
    {
        one, two
    }
    public CloseDoor closeDoor;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        switch (closeDoor)
        {
            case CloseDoor.one:
                if (Input.GetKeyUp(KeyCode.E) && into)
                {
                    into = false;
                    text.SetActive(false);
                    col.enabled = false;
                    animDoor.SetBool("Shiny", false);
                    animDoor.SetBool("Close", true);
                    trash.enabled = true;
                    pickableObject.enabled = true;
                    pickableObject.isPickable = true;
                    dialogue.GetComponent<RepeatText>().sText = "Mike Schmith: Bien, ahora siguen los platos";
                    dialogue.SetActive(true);
                    StartCoroutine("One");
                }
                break;
                case CloseDoor.two:
                if (Input.GetKeyUp(KeyCode.E) && into)
                {
                    into = false;
                    text.SetActive(false);
                    col.enabled = false;
                    animDoor.SetBool("Shiny", false);
                    animDoor.SetBool("Close", true);
                    StartCoroutine("Dialogue");
                }
                break;
        }
    }

    public IEnumerator One()
    {
        mike.clip = clip;
        mike.Play();

        dialogueV2.SetActive(true);
        dialogueV2.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: tal vez ha sido un animal";
        yield return new WaitForSeconds(2);
        dialogueV2.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public IEnumerator Dialogue()
    {
        mike.clip = clip;
        mike.Play();

        dialogueV2.SetActive(true);
        dialogueV2.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Espero que esta vez ya no suene...";
        alarmV2.SetActive(true);
        yield return new WaitForSeconds(2);
        dialogueV2.SetActive(false);
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into= true;
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
