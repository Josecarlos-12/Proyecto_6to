using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventBathroom : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private AudioSource shower;
    [SerializeField] private int count;
    [SerializeField] private Collider coll;
    public bool active;

    [Header("Audio")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip clip;

    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coll.enabled= false;
            count++;

            if(count == 1)
            {
                repeat.SetActive(false);
                //repeatText.audio.Stop();
                //repeatText.texContainer.SetActive(false);
                shower.Play();
                StartCoroutine("Dialogue");
            }
        }
    }


    public IEnumerator Dialogue()
    {
        mike.clip= clip;
        mike.Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Prendió la ducha? ¿Se va a bañar aquí abajo? Ha de estar muy cansada";
        yield return new WaitForSeconds(5);
        dialogue.SetActive(false);
        active= true;
        this.gameObject.SetActive(false);
    }
}
