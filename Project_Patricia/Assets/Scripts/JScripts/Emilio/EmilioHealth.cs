using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilioHealth : MonoBehaviour
{

    public int health = 1;

    public void TakeDamage( int damageAmount)
    {
        health -= damageAmount;
        if ( health <= 0 )
        {
            Debug.Log("Emilio desaparecio");
        }
        if ( health > 1 )
        {
            health = 1;
        }
    }
}
