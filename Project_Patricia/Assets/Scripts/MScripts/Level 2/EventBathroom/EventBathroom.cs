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
                shower.Play();
                StartCoroutine("Dialogue");
            }
        }
    }


    public IEnumerator Dialogue()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike: �Prendi� la ducha? �Se va a ba�ar aqu� abajo? Ha de estar muy cansada";
        yield return new WaitForSeconds(5);
        dialogue.SetActive(false);
        active= true;
        this.gameObject.SetActive(false);
    }
}
