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
    [SerializeField] private Animator animDoor;

    private void Update()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        if (Input.GetKeyDown(KeyCode.E) && front.front && !close.frontM && !close.backM )
        {
            //animDoor.SetBool("Behind", false);
            animDoor.SetBool("Front", true);
        }
        if (Input.GetKeyDown(KeyCode.E) && close.frontM)
        {
            animDoor.SetBool("Behind", false);
            animDoor.SetBool("Front", false);
        }


        if (Input.GetKeyDown(KeyCode.E) && behind.back && !close.backM && !close.frontM)
        {
            //animDoor.SetBool("Front", false);
            animDoor.SetBool("Behind", true);
        }
        if(Input.GetKeyDown(KeyCode.E) && close.backM)
        {
            animDoor.SetBool("Front", false);
            animDoor.SetBool("Behind", false);
        }
    }

}
