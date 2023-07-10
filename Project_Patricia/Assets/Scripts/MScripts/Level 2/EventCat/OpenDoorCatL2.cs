using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorCatL2 : MonoBehaviour
{
    public OpenDoorCustom door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<OpenDoorCustom>() != null)
        {
            door = other.gameObject.GetComponent<OpenDoorCustom>();
        }
    }
}
