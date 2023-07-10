using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaySoundDoorL2 : MonoBehaviour
{
    public AudioSource door;
    public AudioClip clip;
    [SerializeField] private GameObject dialogue, chart;
    [SerializeField] private Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.clip= clip;
            door.Play();
            col.enabled= false;
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Cat?";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Cat regresa!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Ábreme por favor!";
        yield return new WaitForSeconds(4);
        chart.SetActive(true);
        dialogue.SetActive(false);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
