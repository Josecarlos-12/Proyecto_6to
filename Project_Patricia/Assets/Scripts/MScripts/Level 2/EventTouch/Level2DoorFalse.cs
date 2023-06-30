using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2DoorFalse : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private AudioSource[] door;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
        doorAnim.SetBool("Close", true);
    }

    public void Open()
    {
        door[0].Play();
    }

    public void Close()
    {
        door[1].Play();
    }
}
