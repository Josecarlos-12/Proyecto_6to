using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDoorCustom : MonoBehaviour
{
    public bool front, back, close;
    public bool frontC, backC, closeC;
    public bool frontM, backM;

    public enum DoorState 
    {
        Front, Back, Close
    }
    public DoorState state;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (state)
            {
                case DoorState.Front:
                    front= true;
                    break; 
                case DoorState.Back:
                    back= true;
                    break; 
                case DoorState.Close:
                    close= true;
                    break;
            }
        }
        if (other.gameObject.CompareTag("Cat"))
        {
            switch (state)
            {
                case DoorState.Front:
                    frontC = true;
                    break;
                case DoorState.Back:
                    backC = true;
                    break;
                case DoorState.Close:
                    closeC = true;
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (state)
            {
                case DoorState.Front:
                    front = false;
                    break;
                case DoorState.Back:
                    back = false;
                    break;
                case DoorState.Close:
                    close = false;
                    break;
            }
        }
        if (other.gameObject.CompareTag("Cat"))
        {
            switch (state)
            {
                case DoorState.Front:
                    frontC = false;
                    break;
                case DoorState.Back:
                    backC = false;
                    break;
                case DoorState.Close:
                    closeC = false;
                    break;
            }
        }
    }

    public void FrontOpen()
    {
        frontM = true;
        backM= false;
    }

    public void Idle()
    {
        frontM = false;
        backM = false;
    }

    public void BehindOpen()
    {
        frontM = false;
        backM = true;
    }
}
