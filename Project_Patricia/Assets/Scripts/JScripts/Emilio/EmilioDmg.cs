using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmilioDmg : MonoBehaviour
{
    public int doDamage = 25;


    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player") )
        {
            //if (other.GetComponent<PlayerHealth>().death == false)
            {
                //other.GetComponent<PlayerHealth>().RecieveDamage(doDamage);
            }            
            Debug.Log("Te estas haciendo daño");
        }
    }
}
