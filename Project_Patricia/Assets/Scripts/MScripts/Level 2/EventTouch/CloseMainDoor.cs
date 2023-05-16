using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMainDoor : MonoBehaviour
{
    [SerializeField] private Animator animDoor;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject text;
    [SerializeField] private bool into;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && into)
        {
            into = false;
            text.SetActive(false);
            col.enabled= false;
            animDoor.SetBool("Shiny",false);
            animDoor.SetBool("Close",true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = false;
        }
    }

}
