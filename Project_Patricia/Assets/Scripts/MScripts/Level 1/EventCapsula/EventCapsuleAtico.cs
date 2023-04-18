using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventCapsuleAtico : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject capsule, step, key;

    public enum Event
    {
        one, two, three
    }
    public Event eve;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
            switch (eve)
            {
                case Event.one:
                    StartCoroutine("Dialogue");
                    break;
                case Event.two:
                    StartCoroutine("Key");
                    break;

                case Event.three:
                    StartCoroutine("Pad");
                    break;
            }
        }
    }


    public IEnumerator Dialogue()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Wah!";
        yield return new WaitForSeconds(2);
        text.SetActive(false);
        capsule.GetComponent<MeshRenderer>().enabled = false;
        capsule.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(2);
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papá, ayudameee! ";
        yield return new WaitForSeconds(2);
        text.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Tengo mucho miedo! ";
        yield return new WaitForSeconds(2);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Tranquilo hijo, voy a sacarte de aquí ";
        yield return new WaitForSeconds(3);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Iré a buscar las llaves del ático, regreso enseguida ";
        yield return new WaitForSeconds(4);
        step.SetActive(true);
        text.SetActive(false);
        Destroy(gameObject);
    }

    public IEnumerator Key()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Llaves, llaves...";
        yield return new WaitForSeconds(2);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Llaves del ático";
        yield return new WaitForSeconds(2);
        step.SetActive(true);
        text.SetActive(false);
        Destroy(gameObject);
    }

    public IEnumerator Pad()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Y las llaves?";
        yield return new WaitForSeconds(2);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Dónde?";
        key.SetActive(true);
        yield return new WaitForSeconds(2);
        
        text.SetActive(false);
        Destroy(gameObject);
    }
}
