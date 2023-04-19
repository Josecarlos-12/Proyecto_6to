using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneableSoundKey : MonoBehaviour
{
    [SerializeField] private AudioSource audioS;
    [SerializeReference] private Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
            audioS.Stop();
            Destroy(gameObject);
        }
    }


}
