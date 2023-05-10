using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShinyLevel2 : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] bool into;

    [Header("CookingPot")]
    [SerializeField] private OpenDoorBathroom active;


    [SerializeField]
    enum ObjectGames
    {
        CookingPot,
    }
    [SerializeField] ObjectGames objGames;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShinyObjects"))
        {
            switch (objGames)
            {
                case ObjectGames.CookingPot:
                    if(active.bActive)
                    {
                        anim.SetBool("On", true);
                    }
                    break;
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
