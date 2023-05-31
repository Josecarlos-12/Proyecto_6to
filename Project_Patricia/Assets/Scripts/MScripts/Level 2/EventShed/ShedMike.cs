using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShedMike : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private AudioSource audioScare;
    [SerializeField] private Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DeEyes")
        {
            col.enabled= false;
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        audioScare.Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Qué? ¿Tú otra vez?";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡No tengo tiempo para esto!";
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
    }


}
