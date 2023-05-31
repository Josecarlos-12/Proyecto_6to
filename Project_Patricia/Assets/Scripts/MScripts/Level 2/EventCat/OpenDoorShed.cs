using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorShed : MonoBehaviour
{
    [SerializeField] private Animator animDoor;
    [SerializeField] private GameObject mike, textE;
    [SerializeField] private Collider col;
    [SerializeField] private bool into;

    private void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            col.enabled= false;
            into = false;
            textE.SetActive(false);
            animDoor.SetBool("On", true);
            mike.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into= true;
            textE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
            textE.SetActive(false);
        }
    }
}
