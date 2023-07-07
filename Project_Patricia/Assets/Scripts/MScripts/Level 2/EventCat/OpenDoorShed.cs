using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorShed : MonoBehaviour
{
    [SerializeField] private Animator animDoor, animKey;
    [SerializeField] private GameObject textE;
    [SerializeField] private Collider col;
    [SerializeField] private bool into;
    [SerializeField] private TasksUILevel2 task;

    private void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            task.taskCount = 2;
            col.enabled= false;
            into = false;
            textE.SetActive(false);
            animDoor.SetBool("On", true);
            animKey.SetBool("On", true);
            this.gameObject.SetActive(false);
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
