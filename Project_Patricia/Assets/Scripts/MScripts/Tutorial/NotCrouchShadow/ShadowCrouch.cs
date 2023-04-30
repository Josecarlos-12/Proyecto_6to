using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShadowCrouch : MonoBehaviour
{
    [SerializeField] EnemyShed enemyShed;
    [SerializeField] GameObject colliders;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") &&   enemyShed.accept)
        {
            if (enemyShed.count < 3)
                enemyShed.count++;

            if (enemyShed.count == 1)
            {
                enemyShed.touch = true;
                enemyShed.head.head = false;
                colliders.SetActive(false);
            }
        }
    }
}
