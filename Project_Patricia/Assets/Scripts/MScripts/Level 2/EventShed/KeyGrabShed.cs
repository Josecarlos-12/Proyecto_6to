using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGrabShed : MonoBehaviour
{
    [SerializeField] private GameObject textE, mike, keyMod;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;
    public int key;
    public bool onLight;

    [Header("Call Other Script")]
    [SerializeField] private Inventary inventory;

    private void Update()
    { 
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(keyMod);
            col.enabled= false;
            into = false;
            textE.SetActive(false);
            key = 1;
            inventory.bKEy = true;
            mike.SetActive(true);
            StartCoroutine("KeyGrab");            
        }
    }

    public IEnumerator KeyGrab()
    {
        yield return new WaitForSeconds(5);
        onLight = true;
        this.gameObject.SetActive(false);
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
            into= false;
            textE.SetActive(false);
        }
    }
}
