using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CansTouch : MonoBehaviour
{
    public int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            if(count == 0)
            {
                count++;
            }            
        }
    }
}
