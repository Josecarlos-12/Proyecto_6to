using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private bool into;
    [SerializeField] private Collider coll;

    [Header("Call Other Script")]
    [SerializeField] private OpenDoorBathroom active;

    [Header("Animation")]
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject prota;
    [SerializeField] private Animator animCooking;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && into)
        {
            //animCooking.SetBool("On", true);
            cam.SetActive(true);
            prota.SetActive(false);
            active.bActive = false;
            coll.enabled = false;
            text.SetActive(false);
            into = false;
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (active.bActive)
            {
                text.SetActive(true);
                into =true; 
            }
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
