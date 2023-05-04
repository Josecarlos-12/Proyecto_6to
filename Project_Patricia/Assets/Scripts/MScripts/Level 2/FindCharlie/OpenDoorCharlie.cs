using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoorCharlie : MonoBehaviour
{
    [SerializeField] private Collider col, thisColl;
    [SerializeField] private int count;
    [SerializeField] private bool into;
    [SerializeField] private GameObject text, active;
    [SerializeField] private Animator animDoor, animHandle, doorCat;


    [Header("Call Other Script")]
    [SerializeField] private EventFindCharlie charlie;
    [SerializeField] private PlayerFPSt walk;
    [SerializeField] private PlayerCrouch crouch;

    [Header("Dialogue")]
    [SerializeField] private GameObject dialogue;

    [Header("Audios")]
    [SerializeField] private GameObject steps;
    [SerializeField] private AudioSource frontDoor ,doorClose;
    [SerializeField] private AudioClip close, creak;


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
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Creo que ya se durmi�";
        yield return new WaitForSeconds(0.5f);
        walk.canWalk = true;
        crouch.crouchCan = true;
        yield return new WaitForSeconds(1.5f);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Al parecer todo est� bien...";
        yield return new WaitForSeconds(3f);
        frontDoor.Play();        
        dialogue.SetActive(false);
        yield return new WaitForSeconds(1f);
        frontDoor.clip = close;
        frontDoor.Play();
        yield return new WaitForSeconds(1f);
        steps.SetActive(true);
        yield return new WaitForSeconds(7f);
        doorClose.Play();
        yield return new WaitForSeconds(1f);
        doorClose.clip = creak;
        doorClose.volume = 0.5f;
        doorClose.Play();
        yield return new WaitForSeconds(1f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Ohh, Cat ya lleg� de su reuni�n, pens� que regresar�a m�s tarde";
        yield return new WaitForSeconds(4f);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Como sea, ir� a recibirla";
        yield return new WaitForSeconds(3f);
        active.SetActive(true);
        dialogue.SetActive(false);
        doorCat.SetBool("Open", true);
        this.gameObject.SetActive(false);
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
