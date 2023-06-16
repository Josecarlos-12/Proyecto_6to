using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteDoor3 : MonoBehaviour
{
    [SerializeField] private bool into;
    [SerializeField] private GameObject eText, animCam,prota;
    [SerializeField] private Animator door;
    [SerializeField] private Collider col;

    private void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            col.enabled= false;
            eText.SetActive(false);
            into = false;
            prota.SetActive(false);
            animCam.SetActive(true);
            door.SetBool("Open", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = true;
            eText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
            eText.SetActive(false);
        }
    }
}
