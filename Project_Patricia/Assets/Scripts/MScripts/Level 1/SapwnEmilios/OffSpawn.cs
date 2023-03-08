using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffSpawn : MonoBehaviour
{
    public bool into;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into= true;
        }
    }
}
