using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinyLevel2Best : MonoBehaviour
{
    [SerializeField] private PickableObject pick;
    [SerializeField] Animator anim;
    [SerializeField] bool into;

    private void Update()
    {
        if (!pick.isPickable)
        {
            //anim.SetBool("On", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShinyObjects"))
        {
            if (pick.isPickable)
            {
                anim.SetBool("On", true);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ShinyObjects"))
        {
            anim.SetBool("On", false);
            into = false;
        }
    }
}
