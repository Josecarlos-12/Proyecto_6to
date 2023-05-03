using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorCharlie : MonoBehaviour
{
    [SerializeField] private Collider col, thisColl;
    [SerializeField] private int count;
    [SerializeField] private bool into;
    [SerializeField] private GameObject text;
    [SerializeField] private Animator animDoor, animHandle;


    [Header("Call Other Script")]
    [SerializeField] private EventFindCharlie charlie;
    [SerializeField] private PlayerFPSt walk;
    [SerializeField] private PlayerCrouch crouch;

    void Update()
    {
        if (charlie.activeDorr)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                col.enabled= true;
            }
        }

        if(into && Input.GetKeyDown(KeyCode.E) && col.enabled)
        {
            walk.canWalk = false;
            crouch.crouchCan = false;
            thisColl.enabled= false;
            text.SetActive(false);
            into = false;
            animDoor.SetBool("Open", false);
            animHandle.SetBool("On", false);
            StartCoroutine("TrueWalk");
        }
    }

    public IEnumerator TrueWalk()
    {
        yield return new WaitForSeconds(0.5f);
        walk.canWalk = true;
        crouch.crouchCan = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (col.enabled)
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
            into = false;
        }
    }
}
