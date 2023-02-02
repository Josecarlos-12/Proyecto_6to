using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilioDmg : MonoBehaviour
{
    public int doDamage = 25;


    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player") )
        {
            other.GetComponent<PlayerHealth>().RecieveDamage(doDamage);
            Debug.Log("Te estas haciendo daño");
        }
    }
}
