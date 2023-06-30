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
    public bool open;

    public AudioSource door;
    public AudioClip[] clip;

    private void Update()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        if (Input.GetKeyDown(KeyCode.E) && front.front && !close.frontM && !close.backM )
        {
            open = true;
            //animDoor.SetBool("Behind", false);
            animDoor.SetBool("Front", true);
            door.clip = clip[0];
            door.Play();
        }
        if (Input.GetKeyDown(KeyCode.E) && close.frontM && close.close)
        {
            open = false;
            animDoor.SetBool("Behind", false);
            animDoor.SetBool("Front", false);
            door.clip = clip[1];
            door.Play();
        }


        if (Input.GetKeyDown(KeyCode.E) && behind.back && !close.backM && !close.frontM)
        {open = true;
            //animDoor.SetBool("Front", false);
            animDoor.SetBool("Behind", true);
            door.clip = clip[0];
            door.Play();
        }
        if(Input.GetKeyDown(KeyCode.E) && close.backM && close.close)
        {open = false;
            animDoor.SetBool("Front", false);
            animDoor.SetBool("Behind", false);
            door.clip = clip[1];
            door.Play();
        }
    }

}
