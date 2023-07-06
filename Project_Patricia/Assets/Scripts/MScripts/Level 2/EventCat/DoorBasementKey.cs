using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBasementKey : MonoBehaviour
{
    [SerializeField] bool into;
    [SerializeField] Animator anim;
    [SerializeField] GameObject textE;

    [Header("Call Other Script")]
    [SerializeField] private Inventary inventory;
    [SerializeField] private KeyGrabShed key;
    [SerializeField] private AudioSource door;
    [SerializeField] private AudioClip clip;

    void Update()
    {
        if (key.key == 1 && into && Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Open", true);
            textE.SetActive(false);
            into = false;
            key.key = 0;
            inventory.bKEy = false;
            door.clip = clip;
            door.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (key.key == 1)
            {
                textE.SetActive(true);
                into = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textE.SetActive(false);
            into = false;
        }
    }


    public void Close()
    {
     
    }
}
