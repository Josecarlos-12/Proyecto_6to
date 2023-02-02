using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilioHealth : MonoBehaviour
{

    public int health = 1;
    //public int doDamage = 25;

    public void TakeDamage( int damageAmount)
    {
        health -= damageAmount;
        if ( health <= 0 )
        {
            Destroy(gameObject);
            Debug.Log("Emilio desaparecio");
        }
        if ( health > 1 )
        {
            health = 1;
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player") )
        {
            other.GetComponent<PlayerHealth>().RecieveDamage(doDamage);

        }
    }*/
}
