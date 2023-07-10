using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorCustom : MonoBehaviour
{
    [Header("Call Other Script")]
    [SerializeField] private TouchDoorCustom front;
    [SerializeField] private TouchDoorCustom behind;
    [SerializeField] private TouchDoorCustom close;
    [SerializeField] private PickUpObject pick;

    [Header("Open Door")]
    public Animator animDoor;
    public bool open, openCat;

    public AudioSource door;
    public AudioClip[] clip;

    private void Update()
    {
        OpenDoor();
        DoorCat();
    }

    public void OpenDoor()
    {
        if (Input.GetKeyDown(KeyCode.E) && front.front && !close.frontM && !close.backM )
        {
            open = true;
            //animDoor.SetBool("Behind", false);
            animDoor.SetBool("Front", true);
        }
        if (Input.GetKeyDown(KeyCode.E) && close.frontM && close.close)
        {
            open = false;
            animDoor.SetBool("Behind", false);
            animDoor.SetBool("Front", false);
        }


        if (Input.GetKeyDown(KeyCode.E) && behind.back && !close.backM && !close.frontM)
        {
            open = true;
            //animDoor.SetBool("Front", false);
            animDoor.SetBool("Behind", true);
        }
        if(Input.GetKeyDown(KeyCode.E) && close.backM && close.close)
        {
            open = false;
            animDoor.SetBool("Front", false);
            animDoor.SetBool("Behind", false);
        }
    }

    public void DoorCat()
    {
        if (front.frontC && !close.frontM && !close.backM)
        {
            openCat= true;
            open = true;
            //animDoor.SetBool("Behind", false);
            animDoor.SetBool("Front", true);
            StartCoroutine("OpenDoorCat");
        }
        if (behind.backC && !close.backM && !close.frontM)
        {
            openCat = true;
            open = true;
            //animDoor.SetBool("Front", false);
            animDoor.SetBool("Behind", true);
            StartCoroutine("OpenDoorCat");
        }
    }

    public IEnumerator OpenDoorCat()
    {
        yield return new WaitForSeconds(2f);
        openCat = false;
    }

    public void OpenSound()
    {
        door.clip = clip[0];
        door.Play();
    }

    public void CloseSound()
    {
        door.clip = clip[1];
        door.Play();
    }

}
