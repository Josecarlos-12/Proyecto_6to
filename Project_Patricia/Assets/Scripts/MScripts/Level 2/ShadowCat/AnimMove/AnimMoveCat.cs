using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMoveCat : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void Walk()
    {
        anim.SetBool("Walk", true);
    }

    public void Flash()
    {
        anim.SetBool("Flash", true);
    }

    public void Run()
    {
        anim.SetBool("Run", true);
    }
}
