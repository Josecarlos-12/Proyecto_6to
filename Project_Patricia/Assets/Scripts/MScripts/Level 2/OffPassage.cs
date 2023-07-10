using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffPassage : MonoBehaviour
{
    [SerializeField] private GameObject[] god, bad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0;i < god.Length; i++) 
            {
                god[i].SetActive(false);
            } 
            for (int i = 0;i < bad.Length; i++)
            {
                bad[i].SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
