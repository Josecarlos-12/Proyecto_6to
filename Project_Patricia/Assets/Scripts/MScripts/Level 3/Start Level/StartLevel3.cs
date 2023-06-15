using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartLevel3 : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject charliePenthouse, charlieRoom;
    [SerializeField] private GameObject catBasement;
    [SerializeField] private GameObject touchCharlie;

    [Header("Touch")]
    [SerializeField] private GameObject coll;
    [SerializeField] private Collider thisColl;

    public enum StartDialogue
    {
        starInit, roomCharlie, basement
    }
    public StartDialogue dStart;

    public IEnumerator Start()
    {
        switch (dStart)
        {
            case StartDialogue.starInit:
                yield return new WaitForSeconds(1);
                //charliePenthouse.GetComponent<AudioSource>().Play();
                dialogue.SetActive(true);
                dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papaaaaaaa! ayudaaaa!";
                yield return new WaitForSeconds(3);
                dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Charlie! Ya voy hijo!";
                yield return new WaitForSeconds(3);
                dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: Papaaaaaaa! Por favooooor!";
                yield return new WaitForSeconds(3);
                dialogue.SetActive(false);
                //Activar collider cuarto de charlie
                coll.SetActive(true);
                yield return new WaitForSeconds(2);
                this.gameObject.SetActive(false);
                break;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thisColl.enabled= false;
            switch (dStart)
            {
                case StartDialogue.roomCharlie:
                    StartCoroutine("DialogueOne");
                    break;
                case StartDialogue.basement:
                    StartCoroutine("Basement");
                    break;
            }            
        }
    }

    public IEnumerator DialogueOne()
    {
        yield return new WaitForSeconds(1);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Charlie!";
        yield return new WaitForSeconds(1);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡La puerta no se abre!";
        yield return new WaitForSeconds(2);
        //En ese momento se va a escuchar la voz de Catelyn llamando a Mike desde el sótano
        //catBasement.GetComponent<AudioSource>().Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Miiiiiike!";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Cat?";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Miiiiiikeeee ayúdameeeee!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Caaaat! ¡Esperame!"; 
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
        coll.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public IEnumerator Basement()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Miiiiiike!";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Caaaat!";
        yield return new WaitForSeconds(2);
        // Luego Charlie volverá a llamar a Mike desde el atico
        //charlieRoom.GetComponent<AudioSource>().Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papaaaaaaa! ayudaaaa!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Hijooo!";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
        touchCharlie.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
