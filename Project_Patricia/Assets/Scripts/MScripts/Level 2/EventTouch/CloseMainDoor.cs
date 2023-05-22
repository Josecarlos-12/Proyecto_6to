using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloseMainDoor : MonoBehaviour
{
    [SerializeField] private Animator animDoor;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject text, dialogue;
    [SerializeField] private bool into;

    [SerializeField] private PickableObject pickableObject;
    [SerializeField] private TrashOn trash;

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
            trash.enabled = true;
            pickableObject.enabled = true;
            pickableObject.isPickable= true;
            dialogue.GetComponent<RepeatText>().sText = "Mike Schmith: Bien, ahora siguen los platos";
            dialogue.SetActive(true);
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
