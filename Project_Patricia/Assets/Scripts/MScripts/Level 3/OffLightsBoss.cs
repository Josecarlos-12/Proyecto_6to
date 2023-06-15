using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffLightsBoss : MonoBehaviour
{
    [Header("Call Other Script")]
    [SerializeField] private BossLevel3 boss;

    private void OnTriggerEnter(Collider other)
    {
        if (boss.desactive)
        {
            if (other.gameObject.name == "ReturnEnemy")
            {
                other.gameObject.transform.parent.parent.gameObject.SetActive(false);
            }
        }
    }
}
