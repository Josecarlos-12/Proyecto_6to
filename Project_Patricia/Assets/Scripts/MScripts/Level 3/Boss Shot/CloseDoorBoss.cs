using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class CloseDoorBoss : MonoBehaviour
{
    [SerializeField] private OpenDoorCustom door;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audioDoor;
    [SerializeField] private bool bDoor, player;
    [SerializeField] private List<OpenDoorCustom> doors = new List<OpenDoorCustom>();
    [SerializeField] private List<AudioSource> audios = new List<AudioSource>();

    private void OnDisable()
    {
        doors.Clear();
        audios.Clear();
    }

    private void Update()
    {
        if(player && bDoor)
        {

                for (int i = 0; i < doors.Count; i++)
                {
                    doors[i].open = true;

                    if(doors[i].open == true)
                    {
                        doors[i].open = false;
                        doors[i].animDoor.SetBool("Behind", false);
                        doors[i].animDoor.SetBool("Front", false);
                        for (int x = 0; x < audios.Count; x++)
                        {
                            audios[i].clip= clip;
                            audios[i].Play();
                        }



                    }
                }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Player"))
        {
            player = true;
        }
        if (other.gameObject.CompareTag("Door") )
        {
            bDoor= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = false;
        }
        if (other.gameObject.CompareTag("Door"))
        {
            doors.Add(other.gameObject.GetComponent<OpenDoorCustom>());
            audios.Add(other.gameObject.GetComponent<AudioSource>());
            bDoor = false;
        }
    }
}
