using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundLevel2 : MonoBehaviour
{
    [SerializeField] private AudioSource door;
    [SerializeField] private AudioClip[] clip;

    public void Open()
    {
        door.clip = clip[0];
        door.Play();
    }

    public void Close()
    {
        door.clip = clip[1];
        door.Play();
    }
}
