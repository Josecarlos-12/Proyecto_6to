using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoorFlower : MonoBehaviour
{
    [SerializeField] private Animator animDoor;
    [SerializeField] private GameObject text, dialogue;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject doorTrue, doorFalse;

    [Header("Call Other Script")]
    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;
    [SerializeField] private AudioClip clipRepeat;
    [SerializeField] private GameObject taskGame;

    [Header("Audio")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip clip;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if(into && Input.GetKeyUp(KeyCode.E))
        {
            repeatText.audio.Stop();
            repeat.SetActive(false);
            into= false;
            col.enabled= false;
            text.SetActive(false);
            animDoor.SetBool("Close", false);
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(0.4f);
        mike.clip = clip;
        mike.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Ya le había dicho a Cat que en esta casa siempre tiene que haber una luz encendida";
        yield return new WaitForSeconds(4);
        dialogue.SetActive(false);
        doorFalse.SetActive(false);
        doorTrue.SetActive(true);
        yield return new WaitForSeconds(1);
        repeat.SetActive(true);
        repeatText.sText = "Mike Schmith: ¿Cat seguirá en el baño?";
        repeatText.clip = clipRepeat;
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
