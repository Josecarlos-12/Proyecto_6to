using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetsBossLevel3 : MonoBehaviour
{
    public bool ladder;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            ladder= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            ladder= false;
        }
    }
}
