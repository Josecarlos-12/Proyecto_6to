using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosLife : MonoBehaviour
{
    [SerializeField] private MoveBoss move;
    [SerializeField] private TPBossLevel1 bossLevel1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            print("Toco");
            bossLevel1.TouchTriBoss();
        }
    }
}
