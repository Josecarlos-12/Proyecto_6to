using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggertDestroy : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private GameObject lanterSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                lanterSound.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
