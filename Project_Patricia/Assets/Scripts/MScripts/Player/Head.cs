using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public bool head;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Top"))
        {
            head = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Top"))
        {
            head = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Top"))
        {
            head = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Top"))
        {
            head = false;
        }
    }
}
