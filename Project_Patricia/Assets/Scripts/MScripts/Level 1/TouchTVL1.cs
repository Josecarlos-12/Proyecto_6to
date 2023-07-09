using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTVL1 : MonoBehaviour
{
    [SerializeField] private AudioSource audiTV;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            audiTV.Play();
            Destroy(gameObject);
        }
    }
}
