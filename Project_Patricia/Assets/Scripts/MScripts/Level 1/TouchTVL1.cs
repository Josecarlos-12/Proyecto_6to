using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchTVL1 : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audiTV, mike;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject video;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            video.SetActive(true);
            audiTV.Play();
            col.enabled= false;
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        mike.clip= clip;
        mike.Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Esta chatarra otra vez?";
        yield return new WaitForSeconds(4);
        dialogue.SetActive(false);
        Destroy(gameObject);
    }
}
