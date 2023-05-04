using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorBathroom : MonoBehaviour
{
    [SerializeField] private Animator animDoor;
    [SerializeField] private GameObject text;
    [SerializeField] private AudioSource audioDoor;
    [SerializeField] private AudioClip clip;
    [SerializeField] private bool into;
    [SerializeField] private EventBathroom active;
    [SerializeField] private Collider thisColl;

    private void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            audioDoor.clip = clip;            
            text.SetActive(false);
            thisColl.enabled= false;
            into= false;
            animDoor.SetBool("Open", false);
            StartCoroutine("Next");
        }   
    }

    public IEnumerator Next()
    {
        yield return new WaitForSeconds(0.4f);
        audioDoor.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (active.active)
            {
                text.SetActive(true);
                into = true;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into= false;
        }
    }
}
