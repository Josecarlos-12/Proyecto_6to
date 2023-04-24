using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyCharlieDialogue : MonoBehaviour
{
    [SerializeField] GameObject text, otherCol;
    [SerializeField] Collider col;
    [SerializeField] AudioSource audi;

    public enum Dialogues
    {
        one, two, three 
    }
    public Dialogues dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
            switch (dialogue)
            {
                case Dialogues.one:
                    StartCoroutine("Dialogue");
                    break;
                case Dialogues.two:
                    StartCoroutine("Dialogue2");
                    break;
                    case Dialogues.three:
                    StartCoroutine("Dialogue3");
                    break;
            }
        }   
    }

    public IEnumerator Dialogue3()
    {
        audi.Play();
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    public IEnumerator Dialogue2()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith:  No lo entiendo... ¿Qué sucede?";
        yield return new WaitForSeconds(2);
        otherCol.SetActive(true);
        text.SetActive(false);
        Destroy(gameObject);
    }


    public IEnumerator Dialogue()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Charlie? ¡Estás aquí!";
        yield return new WaitForSeconds(2);
        otherCol.SetActive(true);
        text.SetActive(false);
        Destroy(gameObject);
    }
}
