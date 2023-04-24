using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenKey : MonoBehaviour
{
    [SerializeField] KeyGrab numberKey;
    [SerializeField] bool into;
    [SerializeField] Animator anim;
    [SerializeField] GameObject dialogue;


    void Update()
    {
        if(numberKey.numberKey == 1 && into && Input.GetKeyDown(KeyCode.E))
        {
            
            anim.SetBool("Open", true);
            into = false;
            numberKey.numberKey = 0;
        }
    }

    public void Close()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(numberKey.numberKey == 1)
            {
                dialogue.SetActive(true);
                into = true;
            }            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogue.SetActive(false);
            into = false;
        }
    }
}
