using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosLife : MonoBehaviour
{
    [SerializeField] private MoveBoss move;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            print("Toco");
            move.TouchTriBoss();
        }
    }
}
