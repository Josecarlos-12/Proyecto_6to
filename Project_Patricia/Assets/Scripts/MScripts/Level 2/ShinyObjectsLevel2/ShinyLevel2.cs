using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShinyLevel2 : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] bool into;
    public bool on;

    [Header("CookingPot")]
    [SerializeField] private OpenDoorBathroom active;


    [SerializeField]
    enum ObjectGames
    {
        CookingPot, spoons
    }
    [SerializeField] ObjectGames objGames;

    private void Update()
    {
        switch (objGames)
        {
            case ObjectGames.spoons:
                if (on)
                {
                    anim.SetBool("On", true);
                }
                break;
        }
    }

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
