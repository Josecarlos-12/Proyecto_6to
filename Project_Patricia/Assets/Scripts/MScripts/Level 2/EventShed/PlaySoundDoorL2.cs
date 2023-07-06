using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundDoorL2 : MonoBehaviour
{
    public AudioSource door;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.clip= clip;
            door.Play();
            Destroy(gameObject);
        }
    }
}
