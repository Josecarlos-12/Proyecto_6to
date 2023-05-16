using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2DoorFalse : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
        doorAnim.SetBool("Close", true);
    }
}
