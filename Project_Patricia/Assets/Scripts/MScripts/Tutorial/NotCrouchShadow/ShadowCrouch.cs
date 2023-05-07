using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShadowCrouch : MonoBehaviour
{
    [SerializeField] EnemyShed enemyShed;
    [SerializeField] GameObject colliders;
    [SerializeField] Collider col;
    [SerializeField] private PlayerFPSt player;
    [SerializeField] private GameObject dialogue;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") &&   enemyShed.accept)
        {
            if (enemyShed.count < 3)
                enemyShed.count++;

            if (enemyShed.count == 1)
            {
                player.canRun= true;
                enemyShed.touch = true;
                //enemyShed.head.head = false;
                colliders.SetActive(false);
            }
        }
        if (other.gameObject.name== "Mediun" && enemyShed.accept)
        {
            if (enemyShed.count < 3)
                enemyShed.count++;

            if (enemyShed.count == 1)
            {
                player.canRun = true;
                
                //enemyShed.head.head = false;
                col.enabled = false;
                enemyShed.StartCoroutine("Dialogue2");
            }
        }
    }

}
