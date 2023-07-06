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
    [SerializeField] private AudioSource frontDoor ,doorClose, mike;
    [SerializeField] private AudioClip close, creak;
    [SerializeField] private AudioClip[] clipMike;
    [SerializeField] private TasksUILevel2 task;

    [SerializeField] private AudioSource door;
    [SerializeField] private AudioClip clip;

    [SerializeField] private GameObject cam, prota;


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
            task.taskCount = 2;
            walk.canWalk = false;
            crouch.crouchCan = false;
            thisColl.enabled= false;
            text.SetActive(false);
            into = false;
            door.clip= clip;
            door.Play();
            animDoor.SetBool("Open", false);
            animHandle.SetBool("On", false);
            StartCoroutine("TrueWalk");
        }
    }

    public IEnumerator TrueWalk()
    {
        //mike.clip= clipMike[0];
        //mike.Play();

        //dialogue.SetActive(true);
        //dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Creo que ya se durmió...";

        cam.SetActive(true);
        prota.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        walk.canWalk = true;
        crouch.crouchCan = true;
        yield return new WaitForSeconds(0.5f);        

        dialogue.SetActive(true);
        mike.clip= clipMike[0];
        mike.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Al parecer todo está bien";
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
        mike.clip = clipMike[1];
        mike.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Ohh, Cat ya llegó de su reunión, pensé que regresaría más tarde";
        yield return new WaitForSeconds(6f);
        mike.clip = clipMike[2];
        mike.Play();

        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Como sea, iré a recibirla";
        yield return new WaitForSeconds(3f);
        active.SetActive(true);
        dialogue.SetActive(false);
        doorCat.SetBool("Open", true);
        this.gameObject.GetComponent<OpenDoorCharlie>().enabled = false;
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
